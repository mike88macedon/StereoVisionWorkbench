using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace StereoVisionWorkbench.StereoUtillities
{
    public class StereoCalibration
    {
        //chessboard params
        public int Width { get; set; }
        public int Height { get; set; }

        Size patternSize;
        Bgr[] lineColourArr;
        PointF[] leftCorners;
        PointF[] rightCorners;
        static int bufferLength = 20;
        int bufferSavePoint = 0;
        bool startFlag = true;
        MCvPoint3D32f[][] cornersObjectPoints = new MCvPoint3D32f[bufferLength][];
        PointF[][] cornerPointsLeft = new PointF[bufferLength][];
        PointF[][] cornerPointsRight = new PointF[bufferLength][];

        //Calibration parmeters
        Mat IntrinsicMatCam1 = new Mat(3, 3, Emgu.CV.CvEnum.DepthType.Cv64F, 1);
        Mat DistCoefCam1 = new Mat(8, 1, Emgu.CV.CvEnum.DepthType.Cv64F, 1);
        Mat IntrinsicMatCam2 = new Mat(3, 3, Emgu.CV.CvEnum.DepthType.Cv64F, 1);
        Mat DistCoefCam2 = new Mat(3, 3, Emgu.CV.CvEnum.DepthType.Cv64F, 1);

        //extrinsic parameters
        RotationVector3D RotationVector3d = new RotationVector3D();
        Matrix<double> TranslationVector3d = new Matrix<double>(3, 1);

        Matrix<double> fundamental = new Matrix<double>(4, 4); //fundemental output matrix for StereoCalibrate
        Matrix<double> essential = new Matrix<double>(4, 4); //essential output matrix for StereoCalibrate
        Rectangle Rec1 = new Rectangle(); //Rectangle Calibrated in camera 1
        Rectangle Rec2 = new Rectangle(); //Rectangle Caliubrated in camera 2
        Matrix<double> Q = new Matrix<double>(4, 4); //This is what were interested in the disparity-to-depth mapping matrix
        Matrix<double> R1 = new Matrix<double>(3, 3); //rectification transforms (rotation matrices) for Camera 1.
        Matrix<double> R2 = new Matrix<double>(3, 3); //rectification transforms (rotation matrices) for Camera 1.
        Matrix<double> P1 = new Matrix<double>(3, 4); //projection matrices in the new (rectified) coordinate systems for Camera 1.
        Matrix<double> P2 = new Matrix<double>(3, 4); //projection matrices in the new (rectified) coordinate systems for Camera 2.
        private MCvPoint3D32f[] _points; //Computer3DPointsFromStereoPair
        public int NumberOfSamples { get; set; }
        //Frames
        Image<Gray, Byte> grayFrameS1;
        Image<Gray, Byte> grayFrameS2;

        //settings region
        public static int NumDisparities { get; set; }
        public static int MinDisparrities { get; set; }
        public static int SadWindow { get; set; }
        public static int MaxDiff { get; set; }
        public static int PreFilterCapNu { get; set; }
        public static int UniqueneesRatio { get; set; }
        public static int Speckle { get; set; }
        public static int SpeckleRange { get; set; }

        #region Current mode variables
        public enum Mode
        {
            Caluculating_Stereo_Intrinsics,
            Calibrated,
            SavingFrames
        }
        public class MultiResult
        {
            public Image<Gray, short> ProcessedFrame { get; set; }
            public MCvPoint3D32f[] ExtractedPoints { get; set; }
        }
        Mode currentMode = Mode.SavingFrames;
        #endregion

        public StereoCalibration()
        {
            NumberOfSamples = bufferLength;
            Width = 9;
            Height = 7;
            lineColourArr = new Bgr[Width * Height];
            patternSize = new Size(Width, Height);
            Random r = new Random();


            for (int i = 0; i < lineColourArr.Length; i++)
            {
                lineColourArr[i] = new Bgr(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            }
        }

        public MultiResult ProcessFrames(Image<Bgr, Byte> frameS1, Image<Bgr, Byte> frameS2)
        {
            Image<Gray, short> disparityMapResult = null;
            #region FrameAquissition
            grayFrameS1 = frameS1.Convert<Gray, Byte>();
            grayFrameS2 = frameS2.Convert<Gray, Byte>();
            #endregion
            #region Saving Chessboard Corners in Buffer     
            if (currentMode == Mode.SavingFrames)
            {
                leftCorners = new PointF[patternSize.Width * patternSize.Height];
                GCHandle handleLeftCorners = GCHandle.Alloc(leftCorners, GCHandleType.Pinned);
                Matrix<float> pointMatrixLeftCorners = new Matrix<float>(leftCorners.Length, 1, 2, handleLeftCorners.AddrOfPinnedObject(), 2 * sizeof(float));
                rightCorners = new PointF[patternSize.Width * patternSize.Height];
                GCHandle handleRightCorners = GCHandle.Alloc(rightCorners, GCHandleType.Pinned);
                Matrix<float> pointMatrixRightCorners = new Matrix<float>(rightCorners.Length, 1, 2, handleRightCorners.AddrOfPinnedObject(), 2 * sizeof(float));
                //find the chessBoard pattern
                bool paternFoundLeftImg = CvInvoke.FindChessboardCorners(grayFrameS1, patternSize, pointMatrixLeftCorners, Emgu.CV.CvEnum.CalibCbType.AdaptiveThresh);
                bool paternFoundRightImg = CvInvoke.FindChessboardCorners(grayFrameS2, patternSize, pointMatrixRightCorners, Emgu.CV.CvEnum.CalibCbType.AdaptiveThresh);
                //release matrix pointer handles
                handleLeftCorners.Free();
                handleRightCorners.Free();
                if (this.leftCorners != null && rightCorners != null)
                {
                    //make mesurments more accurate by using FindCornerSubPixel
                    grayFrameS1.FindCornerSubPix(new PointF[1][] { leftCorners }, new Size(11, 11), new Size(-1, -1), new MCvTermCriteria(30, 0.01));
                    grayFrameS2.FindCornerSubPix(new PointF[1][] { rightCorners }, new Size(11, 11), new Size(-1, -1), new MCvTermCriteria(30, 0.01));
                    if (startFlag)
                    {
                        //save the calculated points into an array
                        cornerPointsLeft[bufferSavePoint] = leftCorners;
                        cornerPointsRight[bufferSavePoint] = rightCorners;
                        bufferSavePoint++;
                        if (bufferSavePoint == bufferLength)
                        {
                            currentMode = Mode.Caluculating_Stereo_Intrinsics;
                        }
                    }
                    //draw the results from finding corners and edges
                    frameS1.Draw(new CircleF(leftCorners[0], 3), new Bgr(Color.Yellow), 1);
                    frameS2.Draw(new CircleF(leftCorners[0], 3), new Bgr(Color.Yellow), 1);
                    for (int i = 1; i < leftCorners.Length; i++)
                    {
                        //left
                        frameS1.Draw(new LineSegment2DF(leftCorners[i - 1], leftCorners[i]), lineColourArr[i], 2);
                        frameS1.Draw(new CircleF(leftCorners[i], 3), new Bgr(Color.Yellow), 1);
                        //right
                        frameS2.Draw(new LineSegment2DF(rightCorners[i - 1], rightCorners[i]), lineColourArr[i], 2);
                        frameS2.Draw(new CircleF(rightCorners[i], 3), new Bgr(Color.Yellow), 1);
                    }
                    //calibrate the delay bassed on size of buffer
                    //if buffer small you want a big delay if big small delay
                    Thread.Sleep(600);//allow the user to move the board to a different position
                }
                leftCorners = null;
                rightCorners = null;
            }
            #endregion
            #region Calculating Stereo Cameras Relationship
            if (currentMode == Mode.Caluculating_Stereo_Intrinsics)
            {
                //fill the MCvPoint3D32f with correct mesurments
                for (int k = 0; k < bufferLength; k++)
                {
                    //Fill our objects list with the real world mesurments for the intrinsic calculations
                    List<MCvPoint3D32f> objectList = new List<MCvPoint3D32f>();
                    for (int i = 0; i < Height; i++)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            objectList.Add(new MCvPoint3D32f(j * 20.0F, i * 20.0F, 0.0F));
                        }
                    }
                    cornersObjectPoints[k] = objectList.ToArray();
                }
                // If Emgu.CV.CvEnum.CALIB_TYPE == CV_CALIB_USE_INTRINSIC_GUESS and / or CV_CALIB_FIX_ASPECT_RATIO are specified, some or all of fx, fy, cx, cy must be initialized before calling the function
                //if you use FIX_ASPECT_RATIO and FIX_FOCAL_LEGNTH options, these values needs to be set in the intrinsic parameters before the CalibrateCamera function is called. Otherwise 0 values are used as default.
                try
                {
                    CvInvoke.StereoCalibrate(cornersObjectPoints, cornerPointsLeft, cornerPointsRight, IntrinsicMatCam1, DistCoefCam1, IntrinsicMatCam2, DistCoefCam2, frameS1.Size,
                             RotationVector3d, TranslationVector3d, essential, fundamental, Emgu.CV.CvEnum.CalibType.RationalModel, new MCvTermCriteria(0.1e5));
                    MessageBox.Show("Intrinsic Calculation Complete"); //display that the mothod has been succesful
                                                                       //Computes rectification transforms for each head of a calibrated stereo camera.
                                                                       //CvInvoke.StereoRectify(IntrinsicMatCam1, IntrinsicMatCam2, DistCoefCam1, DistCoefCam2, frameS1.Size, RotationVector3d, TranslationVector3d, R1, R2, P1, P2, Q, Emgu.CV.CvEnum.StereoRectifyType.Default, 0, frameS1.Size, ref Rec1, ref Rec2);
                    CvInvoke.StereoRectify(IntrinsicMatCam1, DistCoefCam1, IntrinsicMatCam2, DistCoefCam2, frameS1.Size, RotationVector3d, TranslationVector3d, R1, R2, P1, P2, Q, Emgu.CV.CvEnum.StereoRectifyType.Default, 0, frameS1.Size, ref Rec1, ref Rec2);
                    //This will Show us the usable area from each camera
                    MessageBox.Show("Left: " + Rec1.ToString() + " \nRight: " + Rec2.ToString());
                    currentMode = Mode.Calibrated;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            #endregion
            #region Caluclating disparity map after calibration
            MultiResult multiRes=new MultiResult();
            if (currentMode == Mode.Calibrated)
            {
                multiRes=new MultiResult();
                Image<Gray, short> disparityMap;
                Computer3DPointsFromStereoPair(grayFrameS1, grayFrameS2, out disparityMap, out _points);
                frameS1.Draw(Rec1, new Bgr(Color.LimeGreen), 1);
                frameS2.Draw(Rec2, new Bgr(Color.LimeGreen), 1);
                if (disparityMap != null)
                {
                    disparityMapResult = disparityMap;
                    multiRes.ProcessedFrame = disparityMap;
                }
                if (_points != null)
                {
                    multiRes.ExtractedPoints = _points;
                }
            }
            #endregion
            return multiRes;
        }

        private void Computer3DPointsFromStereoPair(Image<Gray, Byte> left, Image<Gray, Byte> right, out Image<Gray, short> disparityMap, out MCvPoint3D32f[] points)
        {
            disparityMap = null;
            points = null;
            try
            {

                Size size = left.Size;

                disparityMap = new Image<Gray, short>(size);
                //thread safe calibration values


                /*This is maximum disparity minus minimum disparity. Always greater than 0. In the current implementation this parameter must be divisible by 16.*/
                int numDisparities = NumDisparities;//160;// GetSliderValue(Num_Disparities);

                /*The minimum possible disparity value. Normally it is 0, but sometimes rectification algorithms can shift images, so this parameter needs to be adjusted accordingly*/
                int minDispatities = MinDisparrities;//=0// GetSliderValue(Min_Disparities);

                /*The matched block size. Must be an odd number >=1 . Normally, it should be somewhere in 3..11 range*/
                int SAD = SadWindow;//6;//GetSliderValue(SAD_Window);

                /*P1, P2 – Parameters that control disparity smoothness. The larger the values, the smoother the disparity. 
                 * P1 is the penalty on the disparity change by plus or minus 1 between neighbor pixels. 
                 * P2 is the penalty on the disparity change by more than 1 between neighbor pixels. 
                 * The algorithm requires P2 > P1 . 
                 * See stereo_match.cpp sample where some reasonably good P1 and P2 values are shown 
                 * (like 8*number_of_image_channels*SADWindowSize*SADWindowSize and 32*number_of_image_channels*SADWindowSize*SADWindowSize , respectively).*/

                int P1 = 8 * 1 * SAD * SAD;//GetSliderValue(P1_Slider);
                int P2 = 32 * 1 * SAD * SAD;//GetSliderValue(P2_Slider);

                /* Maximum allowed difference (in integer pixel units) in the left-right disparity check. Set it to non-positive value to disable the check.*/
                int disp12MaxDiff = MaxDiff;//10;//GetSliderValue(Disp12MaxDiff);

                /*Truncation value for the prefiltered image pixels. 
                 * The algorithm first computes x-derivative at each pixel and clips its value by [-preFilterCap, preFilterCap] interval. 
                 * The result values are passed to the Birchfield-Tomasi pixel cost function.*/
                int PreFilterCap = PreFilterCapNu;//10;// GetSliderValue(pre_filter_cap);

                /*The margin in percents by which the best (minimum) computed cost function value should “win” the second best value to consider the found match correct. 
                 * Normally, some value within 5-15 range is good enough*/
                int UniquenessRatio = UniqueneesRatio;//GetSliderValue(uniquenessRatio);

                /*Maximum disparity variation within each connected component. 
                 * If you do speckle filtering, set it to some positive value, multiple of 16. 
                 * Normally, 16 or 32 is good enough*/
                int Speckle = StereoCalibration.Speckle;// 32;//GetSliderValue(Speckle_Window);

                /*Maximum disparity variation within each connected component. If you do speckle filtering, set it to some positive value, multiple of 16. Normally, 16 or 32 is good enough.*/
                int SpeckleRange = StereoCalibration.SpeckleRange; //16;//GetSliderValue(specklerange);

                /*Set it to true to run full-scale 2-pass dynamic programming algorithm. It will consume O(W*H*numDisparities) bytes, 
                 * which is large for 640x480 stereo and huge for HD-size pictures. By default this is usually false*/
                //Set globally for ease
                //bool fullDP = true;
                StereoSGBM stereoSolver = new StereoSGBM(minDispatities, numDisparities, SAD, P1, P2, disp12MaxDiff, PreFilterCap, UniquenessRatio, Speckle, SpeckleRange, StereoSGBM.Mode.SGBM);

                //using (StereoBM stereoSolver = new StereoBM(Emgu.CV.CvEnum.STEREO_BM_TYPE.BASIC, 0))
                //{

                stereoSolver.Compute(left, right, disparityMap);//Computes the disparity map using: 
                /*GC: graph cut-based algorithm
                  BM: block matching algorithm
                  SGBM: modified H. Hirschmuller algorithm HH08*/
                points = PointCollection.ReprojectImageTo3D(disparityMap, Q); //Reprojects disparity image to 3D space.
                                                                              // }
                                                                              
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


    }
}
