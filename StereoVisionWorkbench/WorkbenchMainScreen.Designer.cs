namespace StereoVisionWorkbench
{
    partial class WorkbenchMainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runStereoScanningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stereoCalibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibrateFromExistingSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStereoScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopStereoScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setProcessingDirectoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInfo = new System.Windows.Forms.ToolStrip();
            this.toolStripLblInfo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.manualSamplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.commandsToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(913, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runStereoScanningToolStripMenuItem,
            this.stereoCalibrationToolStripMenuItem,
            this.calibrateFromExistingSourceToolStripMenuItem,
            this.manualSamplesToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // runStereoScanningToolStripMenuItem
            // 
            this.runStereoScanningToolStripMenuItem.Name = "runStereoScanningToolStripMenuItem";
            this.runStereoScanningToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.runStereoScanningToolStripMenuItem.Text = "Run Stereo Scanning";
            this.runStereoScanningToolStripMenuItem.Click += new System.EventHandler(this.runStereoScanningToolStripMenuItem_Click);
            // 
            // stereoCalibrationToolStripMenuItem
            // 
            this.stereoCalibrationToolStripMenuItem.Name = "stereoCalibrationToolStripMenuItem";
            this.stereoCalibrationToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.stereoCalibrationToolStripMenuItem.Text = "Stereo Calibration";
            this.stereoCalibrationToolStripMenuItem.Click += new System.EventHandler(this.stereoCalibrationToolStripMenuItem_Click);
            // 
            // calibrateFromExistingSourceToolStripMenuItem
            // 
            this.calibrateFromExistingSourceToolStripMenuItem.Name = "calibrateFromExistingSourceToolStripMenuItem";
            this.calibrateFromExistingSourceToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.calibrateFromExistingSourceToolStripMenuItem.Text = "Calibrate From Existing Source";
            this.calibrateFromExistingSourceToolStripMenuItem.Click += new System.EventHandler(this.calibrateFromExistingSourceToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStereoScanToolStripMenuItem,
            this.stopStereoScanToolStripMenuItem});
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.commandsToolStripMenuItem.Text = "Commands";
            // 
            // startStereoScanToolStripMenuItem
            // 
            this.startStereoScanToolStripMenuItem.Name = "startStereoScanToolStripMenuItem";
            this.startStereoScanToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.startStereoScanToolStripMenuItem.Text = "Start Stereo Scan";
            this.startStereoScanToolStripMenuItem.Click += new System.EventHandler(this.startStereoScanToolStripMenuItem_Click);
            // 
            // stopStereoScanToolStripMenuItem
            // 
            this.stopStereoScanToolStripMenuItem.Name = "stopStereoScanToolStripMenuItem";
            this.stopStereoScanToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.stopStereoScanToolStripMenuItem.Text = "Stop Stereo Scan";
            this.stopStereoScanToolStripMenuItem.Click += new System.EventHandler(this.stopStereoScanToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setProcessingDirectoriesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // setProcessingDirectoriesToolStripMenuItem
            // 
            this.setProcessingDirectoriesToolStripMenuItem.Name = "setProcessingDirectoriesToolStripMenuItem";
            this.setProcessingDirectoriesToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.setProcessingDirectoriesToolStripMenuItem.Text = "Set Processing directories";
            this.setProcessingDirectoriesToolStripMenuItem.Click += new System.EventHandler(this.setProcessingDirectoriesToolStripMenuItem_Click);
            // 
            // toolInfo
            // 
            this.toolInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLblInfo,
            this.toolStripProgressBar});
            this.toolInfo.Location = new System.Drawing.Point(0, 536);
            this.toolInfo.Name = "toolInfo";
            this.toolInfo.Size = new System.Drawing.Size(913, 25);
            this.toolInfo.TabIndex = 5;
            this.toolInfo.Text = "toolStrip1";
            // 
            // toolStripLblInfo
            // 
            this.toolStripLblInfo.Name = "toolStripLblInfo";
            this.toolStripLblInfo.Size = new System.Drawing.Size(86, 22);
            this.toolStripLblInfo.Text = "toolStripLabel1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 22);
            // 
            // manualSamplesToolStripMenuItem
            // 
            this.manualSamplesToolStripMenuItem.Name = "manualSamplesToolStripMenuItem";
            this.manualSamplesToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.manualSamplesToolStripMenuItem.Text = "Manual Samples";
            this.manualSamplesToolStripMenuItem.Click += new System.EventHandler(this.manualSamplesToolStripMenuItem_Click);
            // 
            // WorkbenchMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 561);
            this.Controls.Add(this.toolInfo);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WorkbenchMainScreen";
            this.Text = "STEREO VISION WORKBENCH";
            this.Load += new System.EventHandler(this.WorkbenchMainScreen_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolInfo.ResumeLayout(false);
            this.toolInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runStereoScanningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stereoCalibrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startStereoScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopStereoScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setProcessingDirectoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calibrateFromExistingSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolInfo;
        private System.Windows.Forms.ToolStripLabel toolStripLblInfo;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripMenuItem manualSamplesToolStripMenuItem;
    }
}

