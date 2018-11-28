using BuildsPrepareTool;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace BuildPrepareHelperTool
{
    public class Main
    {
        private Logger _logger;
        public DataManageHelper _dHelper;
        public FileManageHelper _fHelper;
        public Params _params;



        public Main(MainForm form)
        {
            _logger = new Logger();
            _logger.MyEvent += form.UpdateConsoleField;
            _params = new Params();
            _dHelper = new DataManageHelper(_logger, this);
            _fHelper = new FileManageHelper(_logger, this);
            _params.buildServerBuildsPath = form.FolderPathTextBox.Text;
            _params.cdnBuildPath = form.CDNpathTextBox.Text;
            _params.basicLocalBuildPath = form.LocalBuildPathTextBox.Text;
        }


        public void PrepareBuild(BackgroundWorker bw)
        {
            if (_dHelper.CheckTheCondiotionsForBuildPrepare())
            {
                _logger.WriteToConsole("Chosen build looks correct. Going to Copy it to the MsBuilds. Please wait for a while...");
                bw.ReportProgress(10);
                _fHelper.CopyFoldersToStorageAndLocally(_params.buildServerBuildsPath, _params.cdnBuildPath, _params.basicLocalBuildPath);
                bw.ReportProgress(70);
                _fHelper.ReplaceBuildFolders(_params.finalLocalBuildPath);
                bw.ReportProgress(80);
                _fHelper.DeleteUselessFolders(_params.finalLocalBuildPath);
                bw.ReportProgress(90);
                _fHelper.ArchiveEachProjectToZip(_params.finalLocalBuildPath);
                _fHelper.ClearFolderAfterZip(_params.finalLocalBuildPath);
            }
        }
    }
}
