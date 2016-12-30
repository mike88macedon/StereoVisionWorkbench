namespace StereoVisionWorkbench
{
    partial class Settings
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
            this.lblLeftImgs = new System.Windows.Forms.Label();
            this.lblRightImgsDir = new System.Windows.Forms.Label();
            this.txtLeftImages = new System.Windows.Forms.TextBox();
            this.txtRightImages = new System.Windows.Forms.TextBox();
            this.btnSaveConfiguration = new System.Windows.Forms.Button();
            this.txtPcds = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLeftImgs
            // 
            this.lblLeftImgs.AutoSize = true;
            this.lblLeftImgs.Location = new System.Drawing.Point(19, 25);
            this.lblLeftImgs.Name = "lblLeftImgs";
            this.lblLeftImgs.Size = new System.Drawing.Size(107, 13);
            this.lblLeftImgs.TabIndex = 0;
            this.lblLeftImgs.Text = "Left images directory:";
            // 
            // lblRightImgsDir
            // 
            this.lblRightImgsDir.AutoSize = true;
            this.lblRightImgsDir.Location = new System.Drawing.Point(12, 92);
            this.lblRightImgsDir.Name = "lblRightImgsDir";
            this.lblRightImgsDir.Size = new System.Drawing.Size(114, 13);
            this.lblRightImgsDir.TabIndex = 1;
            this.lblRightImgsDir.Text = "Right images directory:";
            // 
            // txtLeftImages
            // 
            this.txtLeftImages.Location = new System.Drawing.Point(125, 22);
            this.txtLeftImages.Name = "txtLeftImages";
            this.txtLeftImages.Size = new System.Drawing.Size(218, 20);
            this.txtLeftImages.TabIndex = 2;
            // 
            // txtRightImages
            // 
            this.txtRightImages.Location = new System.Drawing.Point(125, 85);
            this.txtRightImages.Name = "txtRightImages";
            this.txtRightImages.Size = new System.Drawing.Size(218, 20);
            this.txtRightImages.TabIndex = 3;
            // 
            // btnSaveConfiguration
            // 
            this.btnSaveConfiguration.Location = new System.Drawing.Point(268, 188);
            this.btnSaveConfiguration.Name = "btnSaveConfiguration";
            this.btnSaveConfiguration.Size = new System.Drawing.Size(75, 23);
            this.btnSaveConfiguration.TabIndex = 4;
            this.btnSaveConfiguration.Text = "Set";
            this.btnSaveConfiguration.UseVisualStyleBackColor = true;
            this.btnSaveConfiguration.Click += new System.EventHandler(this.btnSaveConfiguration_Click);
            // 
            // txtPcds
            // 
            this.txtPcds.Location = new System.Drawing.Point(125, 136);
            this.txtPcds.Name = "txtPcds";
            this.txtPcds.Size = new System.Drawing.Size(218, 20);
            this.txtPcds.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "PCDS:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 245);
            this.Controls.Add(this.txtPcds);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveConfiguration);
            this.Controls.Add(this.txtRightImages);
            this.Controls.Add(this.txtLeftImages);
            this.Controls.Add(this.lblRightImgsDir);
            this.Controls.Add(this.lblLeftImgs);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLeftImgs;
        private System.Windows.Forms.Label lblRightImgsDir;
        private System.Windows.Forms.TextBox txtLeftImages;
        private System.Windows.Forms.TextBox txtRightImages;
        private System.Windows.Forms.Button btnSaveConfiguration;
        private System.Windows.Forms.TextBox txtPcds;
        private System.Windows.Forms.Label label1;
    }
}