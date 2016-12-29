namespace StereoVisionWorkbench
{
    partial class StereoForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.leftCamera = new System.Windows.Forms.PictureBox();
            this.rightCamera = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picBoxDisparityMap = new System.Windows.Forms.PictureBox();
            this.toolStripInfo = new System.Windows.Forms.ToolStrip();
            this.toolLblInfo = new System.Windows.Forms.ToolStripLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.speckleRange = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.scrollSpeckleWindow = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.scrollUniqueness = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.prefFilter = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.maxDiff = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.sadWindowScroll = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.minDisparities = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.numDisparities = new System.Windows.Forms.TrackBar();
            this.openGLControl1 = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightCamera)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDisparityMap)).BeginInit();
            this.toolStripInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speckleRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollSpeckleWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollUniqueness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prefFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sadWindowScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minDisparities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisparities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.leftCamera);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rightCamera);
            this.splitContainer1.Size = new System.Drawing.Size(1343, 499);
            this.splitContainer1.SplitterDistance = 677;
            this.splitContainer1.TabIndex = 0;
            // 
            // leftCamera
            // 
            this.leftCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftCamera.Location = new System.Drawing.Point(0, 0);
            this.leftCamera.Name = "leftCamera";
            this.leftCamera.Size = new System.Drawing.Size(677, 499);
            this.leftCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.leftCamera.TabIndex = 0;
            this.leftCamera.TabStop = false;
            // 
            // rightCamera
            // 
            this.rightCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightCamera.Location = new System.Drawing.Point(0, 0);
            this.rightCamera.Name = "rightCamera";
            this.rightCamera.Size = new System.Drawing.Size(662, 499);
            this.rightCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.rightCamera.TabIndex = 0;
            this.rightCamera.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picBoxDisparityMap);
            this.groupBox1.Location = new System.Drawing.Point(0, 505);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 433);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DISPARITY MAP";
            // 
            // picBoxDisparityMap
            // 
            this.picBoxDisparityMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxDisparityMap.Location = new System.Drawing.Point(3, 16);
            this.picBoxDisparityMap.Name = "picBoxDisparityMap";
            this.picBoxDisparityMap.Size = new System.Drawing.Size(671, 414);
            this.picBoxDisparityMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxDisparityMap.TabIndex = 0;
            this.picBoxDisparityMap.TabStop = false;
            // 
            // toolStripInfo
            // 
            this.toolStripInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLblInfo});
            this.toolStripInfo.Location = new System.Drawing.Point(0, 952);
            this.toolStripInfo.Name = "toolStripInfo";
            this.toolStripInfo.Size = new System.Drawing.Size(1734, 25);
            this.toolStripInfo.TabIndex = 1;
            this.toolStripInfo.Text = "toolStrip1";
            // 
            // toolLblInfo
            // 
            this.toolLblInfo.Name = "toolLblInfo";
            this.toolLblInfo.Size = new System.Drawing.Size(86, 22);
            this.toolLblInfo.Text = "toolStripLabel1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.speckleRange);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.scrollSpeckleWindow);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.scrollUniqueness);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.prefFilter);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.maxDiff);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.sadWindowScroll);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.minDisparities);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.numDisparities);
            this.groupBox3.Location = new System.Drawing.Point(1349, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(378, 359);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DISPARITY MAP SETTINGS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(64, 307);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "Speckle Range:";
            // 
            // speckleRange
            // 
            this.speckleRange.Location = new System.Drawing.Point(182, 308);
            this.speckleRange.Maximum = 32;
            this.speckleRange.Name = "speckleRange";
            this.speckleRange.Size = new System.Drawing.Size(175, 45);
            this.speckleRange.TabIndex = 14;
            this.speckleRange.Scroll += new System.EventHandler(this.speckleRange_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(53, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Speckle Window:";
            // 
            // scrollSpeckleWindow
            // 
            this.scrollSpeckleWindow.Location = new System.Drawing.Point(182, 268);
            this.scrollSpeckleWindow.Maximum = 32;
            this.scrollSpeckleWindow.Minimum = 16;
            this.scrollSpeckleWindow.Name = "scrollSpeckleWindow";
            this.scrollSpeckleWindow.Size = new System.Drawing.Size(175, 45);
            this.scrollSpeckleWindow.TabIndex = 12;
            this.scrollSpeckleWindow.Value = 32;
            this.scrollSpeckleWindow.Scroll += new System.EventHandler(this.speckleWindow_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(86, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Uniqueness:";
            // 
            // scrollUniqueness
            // 
            this.scrollUniqueness.Location = new System.Drawing.Point(182, 231);
            this.scrollUniqueness.Maximum = 15;
            this.scrollUniqueness.Minimum = 5;
            this.scrollUniqueness.Name = "scrollUniqueness";
            this.scrollUniqueness.Size = new System.Drawing.Size(175, 45);
            this.scrollUniqueness.TabIndex = 10;
            this.scrollUniqueness.Value = 5;
            this.scrollUniqueness.Scroll += new System.EventHandler(this.scrollUniqueness_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(110, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Pre Filter:";
            // 
            // prefFilter
            // 
            this.prefFilter.Location = new System.Drawing.Point(182, 195);
            this.prefFilter.Maximum = 1000;
            this.prefFilter.Name = "prefFilter";
            this.prefFilter.Size = new System.Drawing.Size(175, 45);
            this.prefFilter.TabIndex = 8;
            this.prefFilter.Value = 10;
            this.prefFilter.Scroll += new System.EventHandler(this.prefFilter_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(110, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Max Diff:";
            // 
            // maxDiff
            // 
            this.maxDiff.Location = new System.Drawing.Point(182, 158);
            this.maxDiff.Maximum = 1000;
            this.maxDiff.Name = "maxDiff";
            this.maxDiff.Size = new System.Drawing.Size(175, 45);
            this.maxDiff.TabIndex = 6;
            this.maxDiff.Value = 10;
            this.maxDiff.Scroll += new System.EventHandler(this.maxDiff_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(76, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "SAD Window:";
            // 
            // sadWindowScroll
            // 
            this.sadWindowScroll.Location = new System.Drawing.Point(182, 123);
            this.sadWindowScroll.Maximum = 11;
            this.sadWindowScroll.Minimum = 3;
            this.sadWindowScroll.Name = "sadWindowScroll";
            this.sadWindowScroll.Size = new System.Drawing.Size(175, 45);
            this.sadWindowScroll.TabIndex = 4;
            this.sadWindowScroll.Value = 3;
            this.sadWindowScroll.Scroll += new System.EventHandler(this.sadWindowScroll_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(70, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Min disparities:";
            // 
            // minDisparities
            // 
            this.minDisparities.Location = new System.Drawing.Point(182, 87);
            this.minDisparities.Maximum = 1000;
            this.minDisparities.Name = "minDisparities";
            this.minDisparities.Size = new System.Drawing.Size(175, 45);
            this.minDisparities.TabIndex = 2;
            this.minDisparities.Scroll += new System.EventHandler(this.minDisparities_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(24, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of disparities:";
            // 
            // numDisparities
            // 
            this.numDisparities.Location = new System.Drawing.Point(182, 52);
            this.numDisparities.Maximum = 1000;
            this.numDisparities.Minimum = 1;
            this.numDisparities.Name = "numDisparities";
            this.numDisparities.Size = new System.Drawing.Size(175, 45);
            this.numDisparities.TabIndex = 0;
            this.numDisparities.Value = 160;
            this.numDisparities.Scroll += new System.EventHandler(this.numDisparities_Scroll);
            // 
            // openGLControl1
            // 
            this.openGLControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.openGLControl1.DrawFPS = false;
            this.openGLControl1.Location = new System.Drawing.Point(684, 521);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl1.Size = new System.Drawing.Size(659, 414);
            this.openGLControl1.TabIndex = 4;
            this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
            // 
            // StereoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1734, 977);
            this.Controls.Add(this.openGLControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.toolStripInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "StereoForm";
            this.Text = "StereoForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StereoForm_FormClosing);
            this.Load += new System.EventHandler(this.StereoForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightCamera)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDisparityMap)).EndInit();
            this.toolStripInfo.ResumeLayout(false);
            this.toolStripInfo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speckleRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollSpeckleWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollUniqueness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prefFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sadWindowScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minDisparities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisparities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox leftCamera;
        private System.Windows.Forms.PictureBox rightCamera;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picBoxDisparityMap;
        private System.Windows.Forms.ToolStrip toolStripInfo;
        private System.Windows.Forms.ToolStripLabel toolLblInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar maxDiff;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar sadWindowScroll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar minDisparities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar numDisparities;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar speckleRange;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar scrollSpeckleWindow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar scrollUniqueness;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar prefFilter;
        private SharpGL.OpenGLControl openGLControl1;
    }
}