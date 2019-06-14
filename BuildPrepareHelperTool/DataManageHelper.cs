using BuildPrepareHelperTool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BuildsPrepareTool
{
    public class DataManageHelper
    {
        private Logger _logger;
        private Main _main;
        public bool isWin10flag = false;

        public DataManageHelper(Logger log, Main main)
        {
            _logger = log;
            _main = main;
        }
        List<string> AvailableProjects = new List<string>
        {
            "Jigsaw_8.1", "Mahjong_8.1", "Minesweeper_8.1", "Solitaire_8.1", "Sudoku", "Mahjong", "Treasure Hunt"
        };

        public bool CheckTheCondiotionsForBuildPrepare()
        {
            try
            {
                var directories = Directory.GetDirectories(_main._params.buildServerBuildsPath, "*");
                var correctFolderCounter = 0;
                foreach (string item in directories)
                {
                    var folderInProject = item.Substring(item.LastIndexOf(@"\"));
                    if (!folderInProject.Contains("_Release")
                        && ((folderInProject.Contains("debug") || folderInProject.Contains("Release") || folderInProject.Contains("ReleaseWithLog"))
                        || (folderInProject.Contains("debug") || folderInProject.Contains("profile") || folderInProject.Contains("release"))
                        || (folderInProject.Contains("Debug") || folderInProject.Contains("Profile") || folderInProject.Contains("Release"))))
                    {
                        correctFolderCounter++;
                        if (correctFolderCounter == 3)
                        {
                            _logger.WriteToConsole("Project " + _main._params.buildServerBuildsPath + " was found =)");
                            return true;
                        }
                    }
                    else
                    {
                        _logger.WriteToConsole("Unfortunately, Current folder is empty =( Choose another folder and try again");
                        break;
                    }
                }
            }
            catch (DirectoryNotFoundException e)
            {
                _logger.WriteToConsole("Unfortunately, Current folder is empty =( Choose another folder and try again");
                return false;
            }
            return false;
        }

        //Method determines the Release folder in local project for creating the folder
        public string GetNecessaryNameForStorage(string project)
        {
            var name = "";
            var ReleasePath = "";
            string[] InReleasePathFolders = new string[0];
            string[] FoldersInRoot = Directory.GetDirectories(project + "\\");

            foreach (string folder in FoldersInRoot)
            {
                if (folder.Contains("W10") && folder.Contains("RELEASE") && folder.Contains("Release") && !folder.Contains("Log"))
                {
                    ReleasePath = folder;
                    try
                    {
                        InReleasePathFolders = Directory.GetDirectories(ReleasePath);
                    }
                    catch (DirectoryNotFoundException e)
                    {
                        _logger.WriteToConsole("There is no build in folder. Please check it and try again");
                        break;
                    }
                }
                if (folder.Contains("elease") && !folder.Contains("RELEASE") && !folder.Contains("rofile") && !folder.Contains("ebug"))
                {
                    ReleasePath = folder;
                    try
                    {
                        if (folder.Contains("TreasureHunt"))
                        {
                            InReleasePathFolders = Directory.GetDirectories(ReleasePath);
                        }
                        else
                        {
                            InReleasePathFolders = Directory.GetDirectories(ReleasePath + "\\Package_release\\");
                        }
                    }
                    catch (DirectoryNotFoundException e)
                    {
                        _logger.WriteToConsole("There is no build in folder. Please check it and try again");
                        break;
                    }
                }
                if (InReleasePathFolders.Length > 0)
                {
                    foreach (string i in InReleasePathFolders)
                    {
                        if (!folder.Contains("W10") && i.Contains("_Test"))
                        {
                            var basicName = i.Substring(i.LastIndexOf(@"\") + 1);
                            name = basicName.Substring(0, basicName.Length - 5);
                            break;
                        }
                        else
                        {
                            name = i.Substring(i.LastIndexOf(@"\") + 1);
                            isWin10flag = true;
                            break;
                        }
                    }
                    break;
                }
            }
            return name;
        }

        //Method determines the necessary folder to place the build on KR-FS/Storage
        public string GetNecessaryFolderName(string ProjectName)
        {
            var ProjectFolder = "";
            if (isWin10flag)
            {
                ProjectFolder = AvailableProjects[5];
            }
            else
            {
                switch (ProjectName)
                {
                    case string jigsaw when jigsaw.Contains("Jigsaw"):
                        return ProjectFolder = AvailableProjects[0];
                    case string mj when mj.Contains("MJ"):
                        return ProjectFolder = AvailableProjects[1];
                    case string mj when mj.Contains("Mahjong"):
                        return ProjectFolder = AvailableProjects[1];
                    case string msw when msw.Contains("Minesweeper"):
                        return ProjectFolder = AvailableProjects[2];
                    case string Sltr when Sltr.Contains("Sltr"):
                        return ProjectFolder = AvailableProjects[3];
                    case string sudoku when sudoku.Contains("Sudoku"):
                        return ProjectFolder = AvailableProjects[4];
                    case string th when th.Contains("TreasureHunt"):
                        return ProjectFolder = AvailableProjects[6];
                }
            }
            return ProjectFolder;
        }

        //Methods builds root folder paths for Profile and Release by current path
        public List<string> GetFinalDirectories(string path)
        {
            var buildFinalPaths = new List<string>();

            var ProfilePath = path + @"\profile\Package_profile\" + _main._fHelper._folderNamePart + "_Profile_Test";
            var ReleasePath = path + @"\release\Package_release\" + _main._fHelper._folderNamePart + "_Test";

            buildFinalPaths.Add(ProfilePath);
            buildFinalPaths.Add(ReleasePath);
            return buildFinalPaths;
        }
    }
}    
