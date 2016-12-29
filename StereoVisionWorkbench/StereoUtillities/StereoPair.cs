﻿using Emgu.CV;
using Emgu.CV.Structure;
using SharpGL;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StereoVisionWorkbench.StereoUtillities.StereoCalibration;

namespace StereoVisionWorkbench.StereoUtillities
{
    public class StereoPair
    {
        private Capture captureCamOne { get; set; }
        private Capture captureCamTwo { get; set; }
        public bool StereoPairIsRunning { get; set; }
        private Image<Bgr, Byte> ImgFrmFstCam { get; set; }
        private Image<Bgr, Byte> ImgFrmScndCam { get; set; }
        private Form ui { get; set; }
        private String PicBoxOne { get; set; }
        private String PicBoxTwo { get; set; }
        private String PicBoxDisparity { get; set; }
        public Task startStereo;
        StereoCalibration sc;
        private int calibrationCounter = 0;
        public bool StereoCalibration { get; set; }
        public StereoCalibration StereoCalibrated { get; set; }
        public MCvPoint3D32f[] Points { get; set; }
        //Creating of EventArgs for the custom Event
        public class StereoEventArgs : EventArgs
        {
            private String message;

            public String Message
            {
                get { return message; }
                set { message = value; }
            }
        }
        public event EventHandler<StereoEventArgs> StartCalibration;

        public StereoPair(Form ui, String pic1, String pic2, String disparity)
        {
            this.ui = ui;
            PicBoxOne = pic1;
            PicBoxTwo = pic2;
            PicBoxDisparity = disparity;
            StereoForm.GLControl.OpenGLDraw += GLControl_OpenGLDraw;
        }

        private void GLControl_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            Task drawTAsk = Task.Factory.StartNew(() => {
                StereoForm.GLControl.Invoke(new Action(() => {
                    OpenGL gl = StereoForm.GLControl.OpenGL;
                    gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);  
                    gl.LoadIdentity();                                                                           
                    gl.Translate(-1.5f, 0.0f, -6.0f);             
                  
                    if (Points!=null)
                    {

                        gl.Begin(OpenGL.GL_POINTS);
                        foreach (MCvPoint3D32f item in Points)
                        {
                            gl.Vertex(item.X/100.00, item.Y/100.0, item.Z/100.0);
                            gl.Color(1.0f, 0.0f, 0.0f);         // Red
                        }
                        gl.End();
                        gl.Flush();
                    }
                }));

            });
        }

        public void StartStereoPair()
        {

            if (StereoCalibration)
            {
                sc = new StereoCalibration();
            }
            captureCamOne = new Capture(0);
            captureCamTwo = new Capture(1);
            StereoPairIsRunning = true;
            startStereo = Task.Factory.StartNew(() =>
            {
                while (StereoPairIsRunning)
                {
                    ProcessStereoFrame();
                    if (!StereoPairIsRunning)
                    {
                        break;
                    }
                }
            });

        }
        private void SaveCalibrationImgs(Image<Bgr, Byte> ImgFrmFstCam, Image<Bgr, Byte> ImgFrmScndCam)
        {
            Thread.Sleep(1000);
            calibrationCounter++;
            string filePathLeft = ConfigurationUtil.GetConfigurationValue("leftImages");
            string filePathRight = ConfigurationUtil.GetConfigurationValue("rightImages");
            ImgFrmFstCam.Save(filePathLeft + "\\" + "left" + calibrationCounter + ".jpg");
            ImgFrmScndCam.Save(filePathRight + "\\" + "right" + calibrationCounter + ".jpg");
        }
        public StereoCalibration ProcessCalibImgsDirs()
        {
            string filePathLeft = ConfigurationUtil.GetConfigurationValue("leftImages");
            string filePathRight = ConfigurationUtil.GetConfigurationValue("rightImages");

            string[] filePaths = Directory.GetFiles(filePathLeft);
            Array.Sort(filePaths, new AlphanumComparatorFast());

            string[] filePaths1 = Directory.GetFiles(filePathRight);
            Array.Sort(filePaths1, new AlphanumComparatorFast());
            Image<Gray, short> disparityResult = null;
            for (int i = 0; i < filePaths.Length; i++)
            {
                Image<Bgr, Byte> img1 = new Image<Bgr, Byte>(filePaths[i]);
                Image<Bgr, Byte> img2 = new Image<Bgr, Byte>(filePaths1[i]);
                disparityResult = sc.ProcessFrames(img1, img2).ProcessedFrame;
            }
            if (disparityResult != null)
            {
                StereoCalibrated = sc;
            }
            return StereoCalibrated;
        }
        private void ProcessStereoFrame()
        {
            try
            {
                ImgFrmFstCam = this.captureCamOne.QueryFrame().ToImage<Bgr, Byte>();
                if (ImgFrmFstCam != null)
                {
                    if (ui.Controls.Find(PicBoxOne, true)[0] != null)
                    {
                        (ui.Controls.Find(PicBoxOne, true)[0] as PictureBox).Invoke(new Action(() =>
                        {
                            try
                            {
                                (ui.Controls.Find(PicBoxOne, true)[0] as PictureBox).Image = ImgFrmFstCam.ToBitmap();
                            }
                            catch (Exception innerException)
                            {
                                Debug.WriteLine(innerException.Message);
                            }
                        }));
                    }
                }

                ImgFrmScndCam = this.captureCamTwo.QueryFrame().ToImage<Bgr, Byte>();
                if (ImgFrmScndCam != null)
                {
                    if (ui.Controls.Find(PicBoxTwo, true)[0] != null)
                    {
                        (ui.Controls.Find(PicBoxOne, true)[0] as PictureBox).Invoke(new Action(() =>
                        {
                            try
                            {
                                (ui.Controls.Find(PicBoxTwo, true)[0] as PictureBox).Image = ImgFrmScndCam.ToBitmap();
                            }
                            catch (Exception innerException)
                            {
                                Debug.WriteLine(innerException.Message);
                            }
                        }));
                    }
                }
                if (StereoCalibration)
                {
                    if (calibrationCounter != sc.NumberOfSamples)
                    {
                        SaveCalibrationImgs(ImgFrmFstCam, ImgFrmScndCam);
                    }
                    else
                    {
                        StereoPairIsRunning = false;
                        StereoCalibration = false;
                        //raise calibration start
                        StereoEventArgs args = new StereoEventArgs();
                        args.Message = "RUN CALIBRATION";
                        StartCalibration(this, args);

                    }

                }

                if (StereoCalibrated != null)
                {
                    MultiResult multi = StereoCalibrated.ProcessFrames(ImgFrmFstCam, ImgFrmScndCam);
                    Image<Gray, short> disparityResult = multi.ProcessedFrame;
                    Points = multi.ExtractedPoints;
                    if (ui.Controls.Find(PicBoxDisparity, true)[0] != null)
                    {
                        (ui.Controls.Find(PicBoxDisparity, true)[0] as PictureBox).Invoke(new Action(() =>
                        {
                            try
                            {
                                (ui.Controls.Find(PicBoxDisparity, true)[0] as PictureBox).Image = disparityResult.ToBitmap();
                            }
                            catch (Exception innerException)
                            {
                                Debug.WriteLine(innerException.Message);
                            }
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void StopStereoPair()
        {
            try
            {
                StereoPairIsRunning = false;

                if (captureCamOne != null)
                {
                    captureCamOne.Pause();
                    captureCamOne.Dispose();

                }
                if (captureCamTwo != null)
                {
                    captureCamTwo.Pause();
                    captureCamTwo.Dispose();
                }
                startStereo.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                StereoPairIsRunning = false;
            }
        }

    }
}