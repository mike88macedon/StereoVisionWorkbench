using StereoVisionWorkbench.StereoUtillities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StereoVisionWorkbench
{
    public partial class ManualShots : Form
    {
        StereoPair stereoPair;
        public ManualShots()
        {
            InitializeComponent();
        }
        int counter = 1;
        private void ManualShots_Load(object sender, EventArgs e)
        {
            stereoPair = new StereoPair(this, leftCamera.Name, rightCamera.Name, null);
            stereoPair.StartStereoPair();
            stereoPair.StereoCalibration = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string leftImgsstorage = ConfigurationUtil.GetConfigurationValue("leftImages");
            string rightImgsstorage = ConfigurationUtil.GetConfigurationValue("rightImages");

            if (leftCamera.Image!=null&&rightCamera.Image!=null)
            {
                leftCamera.Image.Save(string.Format("{0}\\{1}",leftImgsstorage,string.Format("left{0}.jpg",counter.ToString())));
                rightCamera.Image.Save(string.Format("{0}\\{1}", rightImgsstorage, string.Format("right{0}.jpg", counter.ToString())));
                counter++;
            }
        }

        private void ManualShots_FormClosing(object sender, FormClosingEventArgs e)
        {
            stereoPair.StopStereoPair();
        }
    }
}
