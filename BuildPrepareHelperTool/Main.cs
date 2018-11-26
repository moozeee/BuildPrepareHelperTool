using BuildsPrepareTool;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace BuildPrepareHelperTool
{
    public class Main
    {
        private Logger _logger;
        private DataManageHelper _dHelper;
        private FileManageHelper _fHelper;
        public string cdnBuildPath;
        public string localBuildsPath;



        public Main(Form1 form)
        {
            _logger = new Logger();
            _logger.MyEvent += form.UpdateConsoleField;
            _dHelper = new DataManageHelper(_logger);
            _fHelper = new FileManageHelper(_logger);
            localBuildsPath = form.FolderPathTextBox.Text;
            cdnBuildPath = form.CDNpath.Text;
        }

        public void PrepareBuild(BackgroundWorker bw)
        {
            if (!Directory.EnumerateDirectories(localBuildsPath).Count().Equals(0))
            {
                bw.ReportProgress(10);
                _logger.WriteToConsole("Please wait for a while...\r\n");
                var BuildNameList = _dHelper.GetProjectInfo(localBuildsPath);
                _fHelper.CopyFoldersToStorage(BuildNameList, cdnBuildPath);
                bw.ReportProgress(60);
                _fHelper.ReplaceBuildFolders(BuildNameList);
                bw.ReportProgress(70);
                _fHelper.DeleteUselessFolders(BuildNameList);
                bw.ReportProgress(80);
                _fHelper.ArchiveEachProjectToZip(BuildNameList);
            }
            else
            {
                _logger.WriteToConsole("Unfrotanutely, Current folder is empty =( Choose another fodler and try again");
            }
        }
    }
}
