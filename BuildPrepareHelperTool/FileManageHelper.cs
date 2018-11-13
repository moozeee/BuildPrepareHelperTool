using BuildPrepareHelperTool;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace BuildsPrepareTool
{
    public class FileManageHelper
    {
        private Logger _logger;
        private DataManageHelper _dHelper;

        public FileManageHelper(Logger log)
        {
            _logger = log;
            _dHelper = new DataManageHelper(_logger);
        }


        //Method makes the copy of the Project from the local Test to the Storage
        public void CopyFoldersToStorage(List<string> list, string cdnPath)
        {
            list.ForEach(item =>
            {
                var fileName = _dHelper.GetNecessaryNameForStorage(item);
                var finalPath = CreateFolderInNetworkDrive(item, fileName, cdnPath);
                FileSystem.CopyDirectory(item, finalPath);
                _logger.WriteToConsole("\r\nBuilds Path to the Storage: " + finalPath + "\r\n");
            });
        }
        
        //Method creates folder with project version in name in kr-fs/Storage
        public string CreateFolderInNetworkDrive(string ProjectName, string name, string cdnPath)
        {
            var projectName = _dHelper.GetNecessaryFolderName(ProjectName);
            var projectVersion = name.Substring(name.LastIndexOf("_") + 1);
            var finalFolderPath = "";
            var currentDate = DateTime.Today.ToString("ddMMyyyy");

            if (_dHelper.isWin10flag)
            {
                var Win10_final_dir_name = ProjectName.Substring(ProjectName.LastIndexOf(@"\") + 1);
                var Win10_ver = projectVersion.Substring(0, 3);
                finalFolderPath = cdnPath + @"\" + projectName + "\\" + Win10_ver + "\\" + currentDate + "\\" + Win10_final_dir_name + "\\";
            }
            else
            {
                var finalFolderName = ProjectName.Substring(ProjectName.IndexOf("Test\\") + 5);
                finalFolderPath = cdnPath + @"\" + projectName + "\\" + projectVersion + "\\" + finalFolderName + "\\";

            }
            DirectoryInfo directoryInfo = Directory.CreateDirectory(finalFolderPath);
            return finalFolderPath;
        }

        //Methods builds paths for final Profile and Release builds for each project
        public void ReplaceBuildFolders(List<string> List)
        {
            if (!_dHelper.isWin10flag)
            {
                foreach (string item in List)
                {
                    var finalBuildPaths = _dHelper.GetFinalDirectories(item);
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
                    _logger.WriteToConsole("All files from Package_profile and Package_release folders were moved one level higher \r\n");
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

        public void DeleteUselessFolders(List<string> list)
        {
            if (!_dHelper.isWin10flag)
            {
                foreach (string item in list)
                {
                    List<string> FoldersToDelete = new List<string>();
                    FoldersToDelete.Add(item + @"\debug\");
                    FoldersToDelete.Add(item + @"\profile\Package_profile");
                    FoldersToDelete.Add(item + @"\profile\x86_ARM");
                    FoldersToDelete.Add(item + @"\release\Package_release");
                    FoldersToDelete.Add(item + @"\release\x86_ARM");
                    foreach (string line in FoldersToDelete)
                    {
                        DeleteFolder(line);
                    }
                }
            }
            else
            {
                DeleteFolder(list[0] + @"\debug\");
            }
            _logger.WriteToConsole("Useless directories were successfully deleted");
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
        public void ArchiveEachProjectToZip(List<string> list)
        {
            list.ForEach(item =>
            {
                var CurrentBuildsPath = item;
                var TargetFolder = item + ".zip";
                ZipFile.CreateFromDirectory(CurrentBuildsPath, TargetFolder);
                _logger.WriteToConsole(item + " folder was successfully archived.\r\n" + "Path to zip file: " + TargetFolder);
            });
        }
    }
}
