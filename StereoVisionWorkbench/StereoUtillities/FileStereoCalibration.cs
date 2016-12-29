using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.IO;
using static StereoVisionWorkbench.StereoUtillities.StereoCalibration;

namespace StereoVisionWorkbench.StereoUtillities
{
    public class FileStereoCalibration
    {
        public static StereoCalibration ProcessCalibImgsDirs()
        {
            StereoCalibration stereoCalib = new StereoCalibration();
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
                MultiResult multi=stereoCalib.ProcessFrames(img1, img2);
                if(multi.ProcessedFrame!=null)
                disparityResult =multi .ProcessedFrame;
            }
            if (disparityResult != null)
            {
                return stereoCalib;
            }
            else
                return null;
        }
    }
}
