using System;
using System.Windows.Forms;

namespace BuildPrepareHelperTool
{
    static class Program
    {
        //static string rootFolderPath = string.Empty;
        //static string StorageMsBuildsPath = @"\\kr-fs\Storage\Temporary\vkhomyak\MsBuilds\";
        //public static string FolderWithBuildsPath = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
