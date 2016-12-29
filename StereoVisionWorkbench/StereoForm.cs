using SharpGL;
using StereoVisionWorkbench.StereoUtillities;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StereoVisionWorkbench.StereoUtillities.StereoPair;

namespace StereoVisionWorkbench
{
    public partial class StereoForm : Form, INotifyPropertyChanged
    {
        private bool runCmd;
        public bool RunCmd { get { return RunCmd; } set { runCmd = value; OnRunCommand(value); } }
        public bool Calibration { get; set; }
        private StereoPair stereoPair;
        public StereoCalibration CalibrationReady { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public static OpenGLControl GLControl { get; set; }

        public StereoForm()
        {
            InitializeComponent();

        }
        public void OnRunCommand(bool isRuning)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(isRuning.ToString()));
            if (isRuning)
            {
                stereoPair = new StereoPair(this, leftCamera.Name, rightCamera.Name, picBoxDisparityMap.Name);
                if (CalibrationReady != null)
                {
                    stereoPair.StereoCalibrated = CalibrationReady;
                }
                if (stereoPair != null)
                {
                    if (Calibration)
                    {
                        stereoPair.StereoCalibration = true;

                        stereoPair.StartCalibration += StereoPair_StartCalibration;
                    }
                    stereoPair.StartStereoPair();

                }
            }
            else if (!isRuning)
            {
                if (stereoPair != null)
                {
                    if (stereoPair.StereoPairIsRunning)
                    {
                        stereoPair.StopStereoPair();
                        RunCmd = false;
                    }
                }
            }
        }

        private void StereoPair_StartCalibration(object sender, StereoEventArgs e)
        {
            stereoPair.StopStereoPair();
            CalibrationReady = stereoPair.ProcessCalibImgsDirs();
            toolLblInfo.Text = "Calibration finished please close the window";
        }

        private void StereoForm_Load(object sender, EventArgs e)
        {
            StereoCalibration.NumDisparities = numDisparities.Value;
            StereoCalibration.MinDisparrities = minDisparities.Value;
            StereoCalibration.SadWindow = sadWindowScroll.Value;
            StereoCalibration.MaxDiff = maxDiff.Value;
            StereoCalibration.PreFilterCapNu = prefFilter.Value;
            StereoCalibration.UniqueneesRatio = scrollUniqueness.Value;
            StereoCalibration.Speckle = scrollSpeckleWindow.Value;
            StereoCalibration.SpeckleRange = speckleRange.Value;
            toolLblInfo.Visible = false;
            GLControl = this.openGLControl1;
        }
        private void StereoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (stereoPair != null)
            {

                stereoPair.StopStereoPair();
                stereoPair = null;
                if (Calibration)
                {
                    Calibration = false;
                }
            }
        }

        private void numDisparities_Scroll(object sender, EventArgs e)
        {
            if (numDisparities.Value % 16 != 0)
            {
                //value must be divisable by 16
                if (numDisparities.Value >= 152) numDisparities.Value = 160;
                else if (numDisparities.Value >= 136) numDisparities.Value = 144;
                else if (numDisparities.Value >= 120) numDisparities.Value = 128;
                else if (numDisparities.Value >= 104) numDisparities.Value = 112;
                else if (numDisparities.Value >= 88) numDisparities.Value = 96;
                else if (numDisparities.Value >= 72) numDisparities.Value = 80;
                else if (numDisparities.Value >= 56) numDisparities.Value = 64;
                else if (numDisparities.Value >= 40) numDisparities.Value = 48;
                else if (numDisparities.Value >= 24) numDisparities.Value = 32;
                else numDisparities.Value = 16;
                StereoCalibration.NumDisparities = numDisparities.Value;
            }
        }

        private void speckleRange_Scroll(object sender, EventArgs e)
        {
            if (speckleRange.Value >= 152)
            {
                speckleRange.Value = 160;
            }
            else if (speckleRange.Value >= 136) speckleRange.Value = 144;
            else if (speckleRange.Value >= 120) speckleRange.Value = 128;
            else if (speckleRange.Value >= 104) speckleRange.Value = 112;
            else if (speckleRange.Value >= 88) speckleRange.Value = 96;
            else if (speckleRange.Value >= 72) speckleRange.Value = 80;
            else if (speckleRange.Value >= 56) speckleRange.Value = 64;
            else if (speckleRange.Value >= 40) speckleRange.Value = 48;
            else if (speckleRange.Value >= 24) speckleRange.Value = 32;
            else if (speckleRange.Value >= 8) speckleRange.Value = 16;
            else speckleRange.Value = 0;
            StereoCalibration.SpeckleRange = speckleRange.Value;
        }

        private void sadWindowScroll_Scroll(object sender, EventArgs e)
        {
            if (sadWindowScroll.Value % 2 == 0)
            {
                if (sadWindowScroll.Value==sadWindowScroll.Maximum)
                {
                    sadWindowScroll.Value = sadWindowScroll.Maximum - 2;
                }
                else
                {
                    sadWindowScroll.Value++;
                }
                StereoCalibration.SadWindow = sadWindowScroll.Value;
            }
        }

        private void minDisparities_Scroll(object sender, EventArgs e)
        {
            StereoCalibration.MinDisparrities = minDisparities.Value;
        }

        private void maxDiff_Scroll(object sender, EventArgs e)
        {
            StereoCalibration.MaxDiff = maxDiff.Value;
        }

        private void prefFilter_Scroll(object sender, EventArgs e)
        {
            StereoCalibration.PreFilterCapNu = prefFilter.Value;
        }

        private void scrollUniqueness_Scroll(object sender, EventArgs e)
        {
            StereoCalibration.UniqueneesRatio = scrollUniqueness.Value;
        }

        private void speckleWindow_Scroll(object sender, EventArgs e)
        {
            StereoCalibration.Speckle = scrollSpeckleWindow.Value;
        }
        float rtri = 0;
        float rquad = 0;
        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
           
           
        }
    }
}
