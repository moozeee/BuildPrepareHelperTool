using BuildsPrepareTool;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Threading;

namespace BuildPrepareHelperTool
{
    public partial class Form1 : Form
    {
        private Main _main;

        public Form1()
        {
            InitializeComponent();
            SetDefaultCDNPathAndBuildPath();
            _main = new Main(this);

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
            FinishedFlag.Visible = true;
            PrepareButton.Enabled = true;
        }
        //-------------------------------------------------------------------------------------------------------//

        public void UpdateConsoleField(object sender, CustomEventArgs args)
        {
            ConsoleField.Invoke(new MethodInvoker(delegate
            {
                ConsoleField.Text = ConsoleField.Text + Environment.NewLine + args.TextForConsoleField;
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            //Show the FolderBrowserDialog
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                FolderPathTextBox.Text = folderDlg.SelectedPath;
                _main.localBuildsPath = FolderPathTextBox.Text;
            }
            folderDlg.Dispose();
        }

        private void ClearLogBtn_Click(object sender, EventArgs e)
        {
            ConsoleField.Text = "";
        }

        private void PrepareButton_Click(object sender, EventArgs e)
        {
            if (FinishedFlag.Visible)
            {
                FinishedFlag.Visible = false;
            }
            PrepareButton.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void SetDefaultCDNPathAndBuildPath()
        {
            CDNpath.Text = @"\\kr-fs\Storage\Teams\MS\MS-Builds";
            FolderPathTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Test\";
        }

        private void button2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        public void ConsoleField_TextChanged(object sender, EventArgs e) { }
        public void CDNpath_TextChanged(object sender, EventArgs e){}
        private void FolderPathTextBox_TextChanged(object sender, EventArgs e){}

        private void button1_Click_1(object sender, EventArgs e)
        {
            var folderDlg = new CommonOpenFileDialog();
            folderDlg.IsFolderPicker = true;
            if (folderDlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                CDNpath.Text = folderDlg.FileName;
                _main.cdnBuildPath = CDNpath.Text;
            }
            folderDlg.Dispose();
        }

        private void progressBar1_Click(object sender, EventArgs e){}

        private void textBox1_TextChanged(object sender, EventArgs e){}

        private void FinishedFlag_Click(object sender, EventArgs e){}

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
