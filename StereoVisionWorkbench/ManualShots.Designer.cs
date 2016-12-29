namespace StereoVisionWorkbench
{
    partial class ManualShots
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
            this.leftCamera = new System.Windows.Forms.PictureBox();
            this.rightCamera = new System.Windows.Forms.PictureBox();
            this.takeShot = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.leftCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // leftCamera
            // 
            this.leftCamera.Location = new System.Drawing.Point(8, 8);
            this.leftCamera.Name = "leftCamera";
            this.leftCamera.Size = new System.Drawing.Size(677, 499);
            this.leftCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.leftCamera.TabIndex = 1;
            this.leftCamera.TabStop = false;
            // 
            // rightCamera
            // 
            this.rightCamera.Location = new System.Drawing.Point(691, 8);
            this.rightCamera.Name = "rightCamera";
            this.rightCamera.Size = new System.Drawing.Size(662, 499);
            this.rightCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.rightCamera.TabIndex = 2;
            this.rightCamera.TabStop = false;
            // 
            // takeShot
            // 
            this.takeShot.Location = new System.Drawing.Point(8, 523);
            this.takeShot.Name = "takeShot";
            this.takeShot.Size = new System.Drawing.Size(213, 23);
            this.takeShot.TabIndex = 3;
            this.takeShot.Text = "TAKE SHOT";
            this.takeShot.UseVisualStyleBackColor = true;
            this.takeShot.Click += new System.EventHandler(this.button1_Click);
            // 
            // ManualShots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 655);
            this.Controls.Add(this.takeShot);
            this.Controls.Add(this.rightCamera);
            this.Controls.Add(this.leftCamera);
            this.Name = "ManualShots";
            this.Text = "ManualShots";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManualShots_FormClosing);
            this.Load += new System.EventHandler(this.ManualShots_Load);
            ((System.ComponentModel.ISupportInitialize)(this.leftCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightCamera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox leftCamera;
        private System.Windows.Forms.PictureBox rightCamera;
        private System.Windows.Forms.Button takeShot;
    }
}