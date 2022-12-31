namespace GTASASettingsChanger
{
    partial class AppWindow
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
            this.components = new System.ComponentModel.Container();
            this.SystemTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonAutoStart = new System.Windows.Forms.Button();
            this.buttonSP = new System.Windows.Forms.Button();
            this.buttonSAMP = new System.Windows.Forms.Button();
            this.buttonMTA = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSPPath = new System.Windows.Forms.Label();
            this.labelSAMPPath = new System.Windows.Forms.Label();
            this.labelMTAPath = new System.Windows.Forms.Label();
            this.buttonSecondVersion = new System.Windows.Forms.Button();
            this.labelSecondVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SystemTrayIcon
            // 
            this.SystemTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.SystemTrayIcon.Visible = true;
            this.SystemTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SystemTrayIconDoubleClick);
            // 
            // buttonAutoStart
            // 
            this.buttonAutoStart.Location = new System.Drawing.Point(64, 32);
            this.buttonAutoStart.Name = "buttonAutoStart";
            this.buttonAutoStart.Size = new System.Drawing.Size(143, 23);
            this.buttonAutoStart.TabIndex = 0;
            this.buttonAutoStart.Text = "Add to AutoStart";
            this.buttonAutoStart.UseVisualStyleBackColor = true;
            this.buttonAutoStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSP
            // 
            this.buttonSP.Location = new System.Drawing.Point(15, 75);
            this.buttonSP.Name = "buttonSP";
            this.buttonSP.Size = new System.Drawing.Size(111, 23);
            this.buttonSP.TabIndex = 1;
            this.buttonSP.Text = "Add 1.00 Settings";
            this.buttonSP.UseVisualStyleBackColor = true;
            this.buttonSP.Click += new System.EventHandler(this.buttonSP_Click);
            // 
            // buttonSAMP
            // 
            this.buttonSAMP.Location = new System.Drawing.Point(15, 190);
            this.buttonSAMP.Name = "buttonSAMP";
            this.buttonSAMP.Size = new System.Drawing.Size(111, 23);
            this.buttonSAMP.TabIndex = 2;
            this.buttonSAMP.Text = "Add SAMP Settings";
            this.buttonSAMP.UseVisualStyleBackColor = true;
            this.buttonSAMP.Click += new System.EventHandler(this.buttonSAMP_Click);
            // 
            // buttonMTA
            // 
            this.buttonMTA.Location = new System.Drawing.Point(15, 247);
            this.buttonMTA.Name = "buttonMTA";
            this.buttonMTA.Size = new System.Drawing.Size(111, 23);
            this.buttonMTA.TabIndex = 3;
            this.buttonMTA.Text = "Add MTA Settings";
            this.buttonMTA.UseVisualStyleBackColor = true;
            this.buttonMTA.Click += new System.EventHandler(this.buttonMTA_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(50, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelTitle.Size = new System.Drawing.Size(174, 13);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "GTA San Andreas Settings Handler";
            // 
            // labelSPPath
            // 
            this.labelSPPath.AutoSize = true;
            this.labelSPPath.Location = new System.Drawing.Point(15, 101);
            this.labelSPPath.Name = "labelSPPath";
            this.labelSPPath.Size = new System.Drawing.Size(65, 13);
            this.labelSPPath.TabIndex = 5;
            this.labelSPPath.Text = "SP Settings:";
            // 
            // labelSAMPPath
            // 
            this.labelSAMPPath.AutoSize = true;
            this.labelSAMPPath.Location = new System.Drawing.Point(15, 216);
            this.labelSAMPPath.Name = "labelSAMPPath";
            this.labelSAMPPath.Size = new System.Drawing.Size(81, 13);
            this.labelSAMPPath.TabIndex = 6;
            this.labelSAMPPath.Text = "SAMP Settings:";
            // 
            // labelMTAPath
            // 
            this.labelMTAPath.AutoSize = true;
            this.labelMTAPath.Location = new System.Drawing.Point(15, 273);
            this.labelMTAPath.Name = "labelMTAPath";
            this.labelMTAPath.Size = new System.Drawing.Size(74, 13);
            this.labelMTAPath.TabIndex = 7;
            this.labelMTAPath.Text = "MTA Settings:";
            // 
            // buttonSecondVersion
            // 
            this.buttonSecondVersion.Location = new System.Drawing.Point(15, 128);
            this.buttonSecondVersion.Name = "buttonSecondVersion";
            this.buttonSecondVersion.Size = new System.Drawing.Size(111, 23);
            this.buttonSecondVersion.TabIndex = 8;
            this.buttonSecondVersion.Text = "Add 1.01 Settings";
            this.buttonSecondVersion.UseVisualStyleBackColor = true;
            this.buttonSecondVersion.Click += new System.EventHandler(this.buttonSecondVersion_Click);
            // 
            // labelSecondVersion
            // 
            this.labelSecondVersion.AutoSize = true;
            this.labelSecondVersion.Location = new System.Drawing.Point(12, 154);
            this.labelSecondVersion.Name = "labelSecondVersion";
            this.labelSecondVersion.Size = new System.Drawing.Size(72, 13);
            this.labelSecondVersion.TabIndex = 9;
            this.labelSecondVersion.Text = "1.01 Settings:";
            // 
            // AppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 321);
            this.Controls.Add(this.labelSecondVersion);
            this.Controls.Add(this.buttonSecondVersion);
            this.Controls.Add(this.labelMTAPath);
            this.Controls.Add(this.labelSAMPPath);
            this.Controls.Add(this.labelSPPath);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonMTA);
            this.Controls.Add(this.buttonSAMP);
            this.Controls.Add(this.buttonSP);
            this.Controls.Add(this.buttonAutoStart);
            this.Name = "AppWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon SystemTrayIcon;
        private System.Windows.Forms.Button buttonAutoStart;
        private System.Windows.Forms.Button buttonSP;
        private System.Windows.Forms.Button buttonSAMP;
        private System.Windows.Forms.Button buttonMTA;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSPPath;
        private System.Windows.Forms.Label labelSAMPPath;
        private System.Windows.Forms.Label labelMTAPath;
        private System.Windows.Forms.Button buttonSecondVersion;
        private System.Windows.Forms.Label labelSecondVersion;
    }
}

