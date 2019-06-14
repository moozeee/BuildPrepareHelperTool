using BuildPrepareHelperTool;
using BuildPrepareHelperTool.models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace BuildsPrepareTool
{
    public class FileManageHelper
    {
        private Logger _logger;
        private Main _main;
        public string _folderNamePart;

        public FileManageHelper(Logger log, Main main)
        {
            _logger = log;
            _main = main;
        }

        //Method makes the copy of the Project from the local Test to the Storage
        public void CopyFoldersToStorageAndLocally(string buildPath, string cdnPath, string basicLocalPath)
        {
            var fileName = _main._dHelper.GetNecessaryNameForStorage(buildPath);
            _folderNamePart = fileName;
            var currentFolderModel = CreateFolders(buildPath, fileName, cdnPath, basicLocalPath);
            try
            {
                FileSystem.CopyDirectory(buildPath, currentFolderModel.finalLocalFolderPath);
                _logger.WriteToConsole("Local Build's Path: " + currentFolderModel.finalLocalFolderPath);
                FileSystem.CopyDirectory(buildPath, currentFolderModel.finalStorageFolderPath);
                _logger.WriteToConsole("Build's Path to the Storage: " + currentFolderModel.finalStorageFolderPath);
            }
            catch (DirectoryNotFoundException e)
            {
                _logger.WriteToConsole(
                    "Unfortunately, Current folder is not exist =( Choose another folder and try again");
            }
        }

        //Method creates folder with project version in name in kr-fs/Storage
        public FinalBuildDirectoriesModel CreateFolders(string ProjectName, string name, string cdnPath, string basicLocalPath)
        {
            var projectName = _main._dHelper.GetNecessaryFolderName(ProjectName);
            string additionalName = String.Empty;
            if (projectName.Contains("Jigsaw"))
            {
                additionalName = "MSFTJigsaw_";
            }
            var finalFolderName = ProjectName.Substring(ProjectName.LastIndexOf("\\") + 1);
            var projectVersion = "";
            var _finalStorageFolderPath = "";
            var _finalLocalFolderPath = basicLocalPath;
            var currentDate = DateTime.Today.ToString("ddMMyy");

            if (_main._dHelper.isWin10flag)
            {
                projectVersion = name.Substring(name.IndexOf("_") + 1);
                var Win10_final_dir_name = ProjectName.Substring(ProjectName.LastIndexOf(@"\") + 1);
                var Win10_ver = projectVersion.Substring(0, 3);
                _finalStorageFolderPath = cdnPath + @"\Win10\" + projectName + @"\" + Win10_ver + @"\" + currentDate + @"\" + Win10_final_dir_name;
            }
            else
            {
                projectVersion = name.Substring(name.LastIndexOf("_") + 1);
                _finalStorageFolderPath = cdnPath + @"\" + projectName + @"\" + additionalName + projectVersion + @"\" + finalFolderName;
            }

            _finalLocalFolderPath = _finalLocalFolderPath + "\\" +finalFolderName;

            var currentDiretoryModel = new FinalBuildDirectoriesModel
            {
                finalLocalFolderPath = _finalLocalFolderPath,
                finalStorageFolderPath = _finalStorageFolderPath
            };
            _main._params.finalLocalBuildPath = currentDiretoryModel.finalLocalFolderPath;
            _main._params.linkToStorageBuild = currentDiretoryModel.finalStorageFolderPath;
            return currentDiretoryModel;
        }

        //Methods builds paths for final Profile and Release builds for each project
        public void ReplaceBuildFolders(string LocalBuildPath)
        {
            if (!_main._dHelper.isWin10flag && !_main._params.buildServerBuildsPath.Contains("TreasureHunt"))
            {
                var finalBuildPaths = _main._dHelper.GetFinalDirectories(LocalBuildPath);
                foreach (string buildPath in finalBuildPaths)
                {
                    if (buildPath.Contains(@"\release\"))
                    {
                        var currentReleaseFolderPath = buildPath;
                        var newReleaseFolder = buildPath.Substring(0, buildPath.IndexOf(@"release") + 7);
                        MoveContentsOfDirectory(currentReleaseFolderPath, newReleaseFolder);
                    }
                    else
                    {
                        var currentProfileFolderPath = buildPath;
                        var newProfileFolder = currentProfileFolderPath.Substring(0, currentProfileFolderPath.IndexOf(@"profile") + 7);
                        MoveContentsOfDirectory(currentProfileFolderPath, newProfileFolder);
                    }
                }
                _logger.WriteToConsole("All files from Package_profile and Package_release folders were moved one level higher ");
            }
            else
            {
                RenameFoldersInProject(LocalBuildPath);
            }
        }

        private void RenameFoldersInProject(string LocalBuildPath)
        {
            var baseDirectories = Directory.GetDirectories(LocalBuildPath, "*");
            foreach (string buildPath in baseDirectories)
            {
                var inRootDirectories = Directory.GetDirectories(buildPath, "*");
                foreach (string curDir in inRootDirectories)
                {
                    if (curDir.Contains("_Test"))
                    {
                        var finDir = curDir.Substring(0, curDir.LastIndexOf("_"));
                        Directory.Move(curDir, finDir);
                    }
                }
            }
        }

        //Method moves the content from one target directory to another
        private void MoveContentsOfDirectory(string source, string target)
        {
            var finalDir = CreateDirectoryByPath(target, source);
            foreach (var file in Directory.EnumerateFiles(source))
            {
                var dest = Path.Combine(target + @"\" + finalDir, Path.GetFileName(file));
                File.Move(file, dest);
            }

            foreach (var dir in Directory.EnumerateDirectories(source))
            {
                var dest = Path.Combine(target + @"\" + finalDir, Path.GetFileName(dir));
                Directory.Move(dir, dest);
            }

            // optional
            Directory.Delete(source);
        }

        //Method creates the new directory by target path
        private string CreateDirectoryByPath(string target, string source)
        {
            var PathWithTestEnding = target + source.Substring(source.LastIndexOf(@"\")).ToString();
            var finalPath = PathWithTestEnding.Remove(PathWithTestEnding.Length - 5);
            var finalDir = Directory.CreateDirectory(finalPath);
            return finalDir.ToString();
        }

        public void DeleteUselessFolders(string LocalBuildPath)
        {
            if (!_main._dHelper.isWin10flag)
            {
                List<string> FoldersToDelete = new List<string>();
                FoldersToDelete.Add(LocalBuildPath + @"\debug\");
                FoldersToDelete.Add(LocalBuildPath + @"\profile\Package_profile");
                FoldersToDelete.Add(LocalBuildPath + @"\profile\x86_ARM");
                FoldersToDelete.Add(LocalBuildPath + @"\release\Package_release");
                FoldersToDelete.Add(LocalBuildPath + @"\release\x86_ARM");
                foreach (string line in FoldersToDelete)
                {
                    DeleteFolder(line);
                }
                DeleteAllFilesInFoldersWithinCurrentDirectory(LocalBuildPath);
            }
            else
            {
                DeleteFolder(LocalBuildPath + @"\debug\");
            }
            _logger.WriteToConsole(@"Useless directories were successfully deleted. Going to Archive project to ZIP.");
        }

        private void DeleteAllFilesInFoldersWithinCurrentDirectory(string LocalBuildPath)
        {
            var RootDirectories = Directory.GetDirectories(LocalBuildPath);
            foreach (string folder in RootDirectories)
            {
                var FolderForDeleting = new DirectoryInfo(folder);
                foreach (FileInfo file in FolderForDeleting.GetFiles())
                {
                    file.Delete();
                }
            }
        }

        public void ClearFolderAfterZip(string LocalBuildPath)
        {
            DeleteFolder(LocalBuildPath);
            _logger.WriteToConsole("Local folder was successfully cleared\r\n");
        }

        //Methods deletes folder by current path
        private void DeleteFolder(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                //Logger(path + " folder was successfully deleted");
            }
            //else
            //Logger("Directory " + path + " wasn't found");
        }

        //Methods archives folders from list
        public void ArchiveEachProjectToZip(string LocalBuildPath)
        {
            var CurrentBuildsPath = LocalBuildPath;
            var TargetFolder = LocalBuildPath + ".zip";
            ZipFile.CreateFromDirectory(CurrentBuildsPath, TargetFolder);
            _logger.WriteToConsole("Build was successfully archived." + "Path to zip file: " + TargetFolder);
            _main._params.successfull = true;
        }
    }
}
