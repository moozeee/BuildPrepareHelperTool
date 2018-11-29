using System;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Drawing;

namespace BuildPrepareHelperTool
{
    public partial class MainForm : Form
    {
        private Main _main;

        public MainForm()
        {
            InitializeComponent();
            SetDefaultCDNPathAndBuildPath();
            _main = new Main(this);
            PrepareButton.BackColor = Color.LightSkyBlue;

            ////BW start
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;  //Tell the user how the process went
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true; //Allow for the process to be cancelled
            ////BW end
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _main.PrepareBuild(backgroundWorker1);
            backgroundWorker1.ReportProgress(100);
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            PrepareButton.Enabled = true;
            ChooseFolderButton.Enabled = true;
            ChooseLocalFolderForZIPButton.Enabled = true;
            ChooseMsBuildsFolderButton.Enabled = true;
            PrepareButton.BackColor = Color.LightSkyBlue;
            if (!_main._params.successfull)
            {
                FinishedFlag.Text = "ERROR";
                FinishedFlag.ForeColor = Color.Red;
            }
            else
            {
                LocalZipPathLink.Visible = true;
                StorageLinkLabel.Visible = true;
            }
            FinishedFlag.Visible = true;
        }

        public void UpdateConsoleField(object sender, CustomEventArgs args)
        {
            ConsoleField.Invoke(new MethodInvoker(delegate
            {
                ConsoleField.Text = ConsoleField.Text + Environment.NewLine + args.TextForConsoleField;
            }));
       }

        private void ChooseProjectButton_Click(object sender, EventArgs e)
        {
            var folderDlg = new CommonOpenFileDialog();
            folderDlg.IsFolderPicker = true;
            if (folderDlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                FolderPathTextBox.Text = folderDlg.FileName;
                _main._params.buildServerBuildsPath = FolderPathTextBox.Text;
            }
            folderDlg.Dispose();
        }

        private void ClearLogBtn_Click(object sender, EventArgs e)
        {
            ConsoleField.Text = "";
            FinishedFlag.Visible = false;
        }

        private void PrepareButton_Click(object sender, EventArgs e)
        {
            if (FinishedFlag.Visible)
            {
                FinishedFlag.Visible = false;
            }
            PrepareButton.Enabled = false;
            ChooseFolderButton.Enabled = false;
            ChooseLocalFolderForZIPButton.Enabled = false;
            ChooseMsBuildsFolderButton.Enabled = false;
            PrepareButton.BackColor = System.Drawing.Color.DarkTurquoise;
            backgroundWorker1.RunWorkerAsync();
        }

        private void SetDefaultCDNPathAndBuildPath()
        {
            CDNpathTextBox.Text = @"\\kr-fs\Storage\Teams\MS\MS-Builds";
            //CDNpathTextBox.Text = @"\\kr-fs\Storage\Temporary\vkhomyak\MsBuilds\";
            FolderPathTextBox.Text = @"\\kr-tfs\AutoBuildsDrop";
            LocalBuildPathTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MyDeliveryBuild";
        }

        private void button2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        public void ConsoleField_TextChanged(object sender, EventArgs e) { }
        public void CDNpath_TextChanged(object sender, EventArgs e){}
        private void FolderPathTextBox_TextChanged(object sender, EventArgs e){}

        private void ChooseMsBuildsFolderButton_Click_1(object sender, EventArgs e)
        {
            var folderDlg = new CommonOpenFileDialog();
            folderDlg.IsFolderPicker = true;
            if (folderDlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                CDNpathTextBox.Text = folderDlg.FileName;
                _main._params.cdnBuildPath = CDNpathTextBox.Text;
            }
            folderDlg.Dispose();
        }

        private void ChooseLocalFolderForZIPButton_Click(object sender, EventArgs e)
        {
            var folderDlg = new CommonOpenFileDialog();
            folderDlg.IsFolderPicker = true;
            if (folderDlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                LocalBuildPathTextBox.Text = folderDlg.FileName;
                _main._params.basicLocalBuildPath = LocalBuildPathTextBox.Text;
            }
            folderDlg.Dispose();
        }

        private void progressBar1_Click(object sender, EventArgs e){}
        private void textBox1_TextChanged(object sender, EventArgs e){}
        private void FinishedFlag_Click(object sender, EventArgs e){}
        private void label1_Click_1(object sender, EventArgs e){}
        private void label2_Click(object sender, EventArgs e){}
        private void pictureBox1_Click(object sender, EventArgs e){}
        private void label3_Click(object sender, EventArgs e) {}

        private void StorageLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.StorageLinkLabel.LinkVisited = true;
            // Navigate to a URL.
            System.Diagnostics.Process.Start(_main._params.cdnBuildPath);
        }

        private void LocalZipPathLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.StorageLinkLabel.LinkVisited = true;
            // Navigate to a URL.
            System.Diagnostics.Process.Start(_main._params.basicLocalBuildPath);
        }
    }
}

