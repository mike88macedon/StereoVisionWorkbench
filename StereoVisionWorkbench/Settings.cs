using System;
using System.Windows.Forms;

namespace StereoVisionWorkbench
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.txtLeftImages.Text = ConfigurationUtil.GetConfigurationValue("leftImages");
            this.txtRightImages.Text = ConfigurationUtil.GetConfigurationValue("rightImages");
            this.txtPcds.Text = ConfigurationUtil.GetConfigurationValue("pcds");
        }

        private void btnSaveConfiguration_Click(object sender, EventArgs e)
        {
            ConfigurationUtil.SaveConfigrationValue("leftImages", this.txtLeftImages.Text);
            ConfigurationUtil.SaveConfigrationValue("rightImages", this.txtRightImages.Text);
            ConfigurationUtil.SaveConfigrationValue("pcds", this.txtPcds.Text);
        }
    }
}
