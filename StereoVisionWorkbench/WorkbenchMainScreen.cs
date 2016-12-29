using StereoVisionWorkbench.StereoUtillities;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StereoVisionWorkbench
{
    public partial class WorkbenchMainScreen : Form
    {

        StereoForm sForm;
        public event EventHandler FileCalibrationFinished;
        public StereoCalibration CalibrationReady { get; set; }

        public WorkbenchMainScreen()
        {
            InitializeComponent();

        }

        private void WorkbenchMainScreen_Load(object sender, EventArgs e)
        {
            FileCalibrationFinished += WorkbenchMainScreen_FileCalibrationFinished;
            toolStripLblInfo.Visible = false;
            toolStripProgressBar.Visible = false;
            toolStripProgressBar.MarqueeAnimationSpeed = 0;
            toolStripProgressBar.Style = ProgressBarStyle.Blocks;
        }
        private void runStereoScanningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sForm = new StereoForm();
            sForm.CalibrationReady = CalibrationReady;
            sForm.WindowState = FormWindowState.Maximized;
            sForm.MdiParent = this;
            sForm.Show();
            sForm.RunCmd = true;
            sForm.FormClosed += SForm_FormClosed;
        }

        private void SForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sForm.CalibrationReady != null)
            {
                CalibrationReady = sForm.CalibrationReady;
            }
            sForm = null;
        }

        private void startStereoScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sForm != null)
            {
                sForm.RunCmd = true;
            }
        }

        private void stopStereoScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sForm != null)
            {
                sForm.RunCmd = false;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stereoCalibrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sForm = new StereoForm();
            sForm.Calibration = true;
            sForm.MdiParent = this;
            sForm.Show();
            sForm.RunCmd = true;
            sForm.FormClosed += SForm_FormClosed;
        }

        private void setProcessingDirectoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings setingsScreen = new Settings();
            setingsScreen.MdiParent = this;
            setingsScreen.Show();
        }

        private void calibrateFromExistingSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripLblInfo.Visible = true;
            toolStripProgressBar.Visible = true;
            toolStripProgressBar.MarqueeAnimationSpeed = 30;
            toolStripLblInfo.Text = "Calibrating...";
            toolStripProgressBar.Style = ProgressBarStyle.Marquee;
            StereoCalibration.NumDisparities = 160;
            StereoCalibration.MinDisparrities = 0;
            StereoCalibration.SadWindow = 6;
            StereoCalibration.MaxDiff = 10;
            StereoCalibration.PreFilterCapNu = 10;
            StereoCalibration.UniqueneesRatio = 5;
            StereoCalibration.Speckle = 16;
            StereoCalibration.SpeckleRange = 16;
            Task startFileCal = Task.Factory.StartNew(() =>
            {
                CalibrationReady = FileStereoCalibration.ProcessCalibImgsDirs();
                if (CalibrationReady != null)
                {
                    this.Invoke(new Action(() =>
                    {
                        FileCalibrationFinished(this, new EventArgs());
                    }));
                }
            });
        }

        private void WorkbenchMainScreen_FileCalibrationFinished(object sender, EventArgs e)
        {
            toolStripLblInfo.Visible = false;
            toolStripProgressBar.Visible = false;
            toolStripProgressBar.MarqueeAnimationSpeed = 0;
            toolStripProgressBar.Style = ProgressBarStyle.Blocks;
        }

        private void manualSamplesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManualShots m = new ManualShots();
            m.MdiParent = this;
            m.Show();
        }
    }
}
