using System;

namespace BuildPrepareHelperTool
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ChooseFolderButton = new System.Windows.Forms.Button();
            this.FolderPathTextBox = new System.Windows.Forms.TextBox();
            this.ConsoleField = new System.Windows.Forms.RichTextBox();
            this.PrepareButton = new System.Windows.Forms.Button();
            this.ClearLogBtn = new System.Windows.Forms.Button();
            this.CDNpathTextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.ChooseMsBuildsFolderButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.FinishedFlag = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ChooseLocalFolderForZIPButton = new System.Windows.Forms.Button();
            this.LocalBuildPathTextBox = new System.Windows.Forms.TextBox();
            this.StorageLinkLabel = new System.Windows.Forms.LinkLabel();
            this.LocalZipPathLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // ChooseFolderButton
            // 
            this.ChooseFolderButton.Location = new System.Drawing.Point(16, 34);
            this.ChooseFolderButton.Name = "ChooseFolderButton";
            this.ChooseFolderButton.Size = new System.Drawing.Size(111, 23);
            this.ChooseFolderButton.TabIndex = 0;
            this.ChooseFolderButton.Text = "Choose folder";
            this.ChooseFolderButton.UseVisualStyleBackColor = true;
            this.ChooseFolderButton.Click += new System.EventHandler(this.ChooseProjectButton_Click);
            // 
            // FolderPathTextBox
            // 
            this.FolderPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FolderPathTextBox.Location = new System.Drawing.Point(133, 36);
            this.FolderPathTextBox.Name = "FolderPathTextBox";
            this.FolderPathTextBox.ReadOnly = true;
            this.FolderPathTextBox.Size = new System.Drawing.Size(756, 20);
            this.FolderPathTextBox.TabIndex = 1;
            this.FolderPathTextBox.TextChanged += new System.EventHandler(this.FolderPathTextBox_TextChanged);
            // 
            // ConsoleField
            // 
            this.ConsoleField.BackColor = System.Drawing.SystemColors.WindowText;
            this.ConsoleField.ForeColor = System.Drawing.Color.White;
            this.ConsoleField.Location = new System.Drawing.Point(172, 283);
            this.ConsoleField.Name = "ConsoleField";
            this.ConsoleField.Size = new System.Drawing.Size(708, 196);
            this.ConsoleField.TabIndex = 2;
            this.ConsoleField.Text = "";
            this.ConsoleField.TextChanged += new System.EventHandler(this.ConsoleField_TextChanged);
            // 
            // PrepareButton
            // 
            this.PrepareButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.PrepareButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.PrepareButton.Location = new System.Drawing.Point(19, 283);
            this.PrepareButton.Name = "PrepareButton";
            this.PrepareButton.Size = new System.Drawing.Size(130, 85);
            this.PrepareButton.TabIndex = 3;
            this.PrepareButton.Text = "Prepare";
            this.PrepareButton.UseVisualStyleBackColor = false;
            this.PrepareButton.Click += new System.EventHandler(this.PrepareButton_Click);
            // 
            // ClearLogBtn
            // 
            this.ClearLogBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClearLogBtn.Location = new System.Drawing.Point(19, 446);
            this.ClearLogBtn.Name = "ClearLogBtn";
            this.ClearLogBtn.Size = new System.Drawing.Size(130, 33);
            this.ClearLogBtn.TabIndex = 4;
            this.ClearLogBtn.Text = "Clear log";
            this.ClearLogBtn.UseVisualStyleBackColor = false;
            this.ClearLogBtn.Click += new System.EventHandler(this.ClearLogBtn_Click);
            // 
            // CDNpathTextBox
            // 
            this.CDNpathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CDNpathTextBox.Location = new System.Drawing.Point(133, 104);
            this.CDNpathTextBox.Name = "CDNpathTextBox";
            this.CDNpathTextBox.ReadOnly = true;
            this.CDNpathTextBox.Size = new System.Drawing.Size(756, 20);
            this.CDNpathTextBox.TabIndex = 5;
            this.CDNpathTextBox.TextChanged += new System.EventHandler(this.CDNpath_TextChanged);
            // 
            // ChooseMsBuildsFolderButton
            // 
            this.ChooseMsBuildsFolderButton.Location = new System.Drawing.Point(16, 104);
            this.ChooseMsBuildsFolderButton.Name = "ChooseMsBuildsFolderButton";
            this.ChooseMsBuildsFolderButton.Size = new System.Drawing.Size(111, 36);
            this.ChooseMsBuildsFolderButton.TabIndex = 7;
            this.ChooseMsBuildsFolderButton.Text = "Change Default Storage Path";
            this.ChooseMsBuildsFolderButton.UseVisualStyleBackColor = true;
            this.ChooseMsBuildsFolderButton.Click += new System.EventHandler(this.ChooseMsBuildsFolderButton_Click_1);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(172, 254);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(708, 14);
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // FinishedFlag
            // 
            this.FinishedFlag.AutoSize = true;
            this.FinishedFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FinishedFlag.Location = new System.Drawing.Point(564, 211);
            this.FinishedFlag.Name = "FinishedFlag";
            this.FinishedFlag.Size = new System.Drawing.Size(144, 37);
            this.FinishedFlag.TabIndex = 9;
            this.FinishedFlag.Text = "DONE!!!";
            this.FinishedFlag.Visible = false;
            this.FinishedFlag.Click += new System.EventHandler(this.FinishedFlag_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "1 - Select the project\'s folder";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(16, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(280, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "2 - Select the MSBuilds folder or leave it default";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(16, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(490, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "4 - Click PREPARE button and wait for a few minutes until progress bar become fil" +
    "led";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(16, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(379, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "3 - Select the Local folder to save the final ZIP or leave it default";
            // 
            // ChooseLocalFolderForZIPButton
            // 
            this.ChooseLocalFolderForZIPButton.Location = new System.Drawing.Point(16, 178);
            this.ChooseLocalFolderForZIPButton.Name = "ChooseLocalFolderForZIPButton";
            this.ChooseLocalFolderForZIPButton.Size = new System.Drawing.Size(111, 36);
            this.ChooseLocalFolderForZIPButton.TabIndex = 15;
            this.ChooseLocalFolderForZIPButton.Text = "Change Default Local Path";
            this.ChooseLocalFolderForZIPButton.UseVisualStyleBackColor = true;
            this.ChooseLocalFolderForZIPButton.Click += new System.EventHandler(this.ChooseLocalFolderForZIPButton_Click);
            // 
            // LocalBuildPathTextBox
            // 
            this.LocalBuildPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LocalBuildPathTextBox.Location = new System.Drawing.Point(133, 178);
            this.LocalBuildPathTextBox.Name = "LocalBuildPathTextBox";
            this.LocalBuildPathTextBox.ReadOnly = true;
            this.LocalBuildPathTextBox.Size = new System.Drawing.Size(756, 20);
            this.LocalBuildPathTextBox.TabIndex = 14;
            // 
            // StorageLinkLabel
            // 
            this.StorageLinkLabel.AutoSize = true;
            this.StorageLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.StorageLinkLabel.Location = new System.Drawing.Point(714, 211);
            this.StorageLinkLabel.Name = "StorageLinkLabel";
            this.StorageLinkLabel.Size = new System.Drawing.Size(88, 17);
            this.StorageLinkLabel.TabIndex = 16;
            this.StorageLinkLabel.TabStop = true;
            this.StorageLinkLabel.Text = "Storage Link";
            this.StorageLinkLabel.Visible = false;
            this.StorageLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.StorageLinkLabel_LinkClicked);
            // 
            // LocalZipPathLink
            // 
            this.LocalZipPathLink.AutoSize = true;
            this.LocalZipPathLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LocalZipPathLink.Location = new System.Drawing.Point(714, 229);
            this.LocalZipPathLink.Name = "LocalZipPathLink";
            this.LocalZipPathLink.Size = new System.Drawing.Size(100, 17);
            this.LocalZipPathLink.TabIndex = 17;
            this.LocalZipPathLink.TabStop = true;
            this.LocalZipPathLink.Text = "Local ZIP Path";
            this.LocalZipPathLink.Visible = false;
            this.LocalZipPathLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LocalZipPathLink_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 491);
            this.Controls.Add(this.LocalZipPathLink);
            this.Controls.Add(this.StorageLinkLabel);
            this.Controls.Add(this.ChooseLocalFolderForZIPButton);
            this.Controls.Add(this.LocalBuildPathTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FinishedFlag);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ChooseMsBuildsFolderButton);
            this.Controls.Add(this.CDNpathTextBox);
            this.Controls.Add(this.ClearLogBtn);
            this.Controls.Add(this.PrepareButton);
            this.Controls.Add(this.ConsoleField);
            this.Controls.Add(this.FolderPathTextBox);
            this.Controls.Add(this.ChooseFolderButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PrepareBuildHelperTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChooseFolderButton;
        public System.Windows.Forms.TextBox FolderPathTextBox;
        public System.Windows.Forms.RichTextBox ConsoleField;
        private System.Windows.Forms.Button PrepareButton;
        private System.Windows.Forms.Button ClearLogBtn;
        public System.Windows.Forms.TextBox CDNpathTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.Button ChooseMsBuildsFolderButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label FinishedFlag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ChooseLocalFolderForZIPButton;
        public System.Windows.Forms.TextBox LocalBuildPathTextBox;
        private System.Windows.Forms.LinkLabel StorageLinkLabel;
        private System.Windows.Forms.LinkLabel LocalZipPathLink;
    }
}

