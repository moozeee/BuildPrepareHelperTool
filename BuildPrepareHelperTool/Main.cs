using BuildsPrepareTool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public void PrepareBuild()
        {
            if(!Directory.EnumerateDirectories(localBuildsPath).Count().Equals(0))
            {
                _logger.WriteToConsole("Please wait for a while...\r\n");
                var BuildNameList = _dHelper.GetProjectInfo(localBuildsPath);
                Thread thread = new Thread(()=> test(BuildNameList, cdnBuildPath));
                thread.Start();
                //_fHelper.CopyFoldersToStorage(BuildNameList, cdnBuildPath);
                //_fHelper.ReplaceBuildFolders(BuildNameList);
                //_fHelper.DeleteUselessFolders(BuildNameList);
                // _fHelper.ArchiveEachProjectToZip(BuildNameList);
            }
            else
            {
                _logger.WriteToConsole("Unfrotanutely, Current folder is empty =( Choose another fodler and try again");
            }
        }

        private void test(List<string> BuildNameList, string cdnBuildPath)
        {
            _fHelper.CopyFoldersToStorage(BuildNameList, cdnBuildPath);
            _fHelper.ReplaceBuildFolders(BuildNameList);
            _fHelper.DeleteUselessFolders(BuildNameList);
        }
    }
}
