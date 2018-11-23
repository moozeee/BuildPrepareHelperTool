using System;

namespace BuildPrepareHelperTool
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ChooseFolderButton = new System.Windows.Forms.Button();
            this.FolderPathTextBox = new System.Windows.Forms.TextBox();
            this.ConsoleField = new System.Windows.Forms.RichTextBox();
            this.PrepareButton = new System.Windows.Forms.Button();
            this.ClearLogBtn = new System.Windows.Forms.Button();
            this.CDNpath = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ChooseFolderButton
            // 
            this.ChooseFolderButton.Location = new System.Drawing.Point(12, 1);
            this.ChooseFolderButton.Name = "ChooseFolderButton";
            this.ChooseFolderButton.Size = new System.Drawing.Size(111, 23);
            this.ChooseFolderButton.TabIndex = 0;
            this.ChooseFolderButton.Text = "Choose folder";
            this.ChooseFolderButton.UseVisualStyleBackColor = true;
            this.ChooseFolderButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // FolderPathTextBox
            // 
            this.FolderPathTextBox.Location = new System.Drawing.Point(129, 4);
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
            this.ConsoleField.Location = new System.Drawing.Point(183, 136);
            this.ConsoleField.Name = "ConsoleField";
            this.ConsoleField.Size = new System.Drawing.Size(702, 205);
            this.ConsoleField.TabIndex = 2;
            this.ConsoleField.Text = "";
            this.ConsoleField.TextChanged += new System.EventHandler(this.ConsoleField_TextChanged);
            // 
            // PrepareButton
            // 
            this.PrepareButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.PrepareButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.PrepareButton.Location = new System.Drawing.Point(32, 136);
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
            this.ClearLogBtn.Location = new System.Drawing.Point(32, 308);
            this.ClearLogBtn.Name = "ClearLogBtn";
            this.ClearLogBtn.Size = new System.Drawing.Size(130, 33);
            this.ClearLogBtn.TabIndex = 4;
            this.ClearLogBtn.Text = "Clear log";
            this.ClearLogBtn.UseVisualStyleBackColor = false;
            this.ClearLogBtn.Click += new System.EventHandler(this.ClearLogBtn_Click);
            // 
            // CDNpath
            // 
            this.CDNpath.Location = new System.Drawing.Point(129, 43);
            this.CDNpath.Name = "CDNpath";
            this.CDNpath.ReadOnly = true;
            this.CDNpath.Size = new System.Drawing.Size(756, 20);
            this.CDNpath.TabIndex = 5;
            this.CDNpath.TextChanged += new System.EventHandler(this.CDNpath_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "Change Default Storage Path";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(183, 107);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(702, 23);
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 353);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CDNpath);
            this.Controls.Add(this.ClearLogBtn);
            this.Controls.Add(this.PrepareButton);
            this.Controls.Add(this.ConsoleField);
            this.Controls.Add(this.FolderPathTextBox);
            this.Controls.Add(this.ChooseFolderButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
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
        public System.Windows.Forms.TextBox CDNpath;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}

