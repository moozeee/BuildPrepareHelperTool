using BuildsPrepareTool;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

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
        }

        public void UpdateConsoleField(object sender, CustomEventArgs args)
        {
            ConsoleField.Text = (ConsoleField.Text + Environment.NewLine + args.TextForConsoleField);
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
            _main.PrepareBuild();
        }

        private void SetDefaultCDNPathAndBuildPath()
        {
            CDNpath.Text = @"\\kr-fs\Storage\Teams\MS\MS-Builds";
            FolderPathTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Test\";
        }

        private void button2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        public void ConsoleField_TextChanged(object sender, EventArgs e) { }
        public void CDNpath_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void FolderPathTextBox_TextChanged(object sender, EventArgs e)
        {
        }

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

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
