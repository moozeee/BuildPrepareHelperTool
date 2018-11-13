using BuildPrepareHelperTool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BuildsPrepareTool
{
    public class DataManageHelper
    {
        private Logger logger;
        public DataManageHelper(Logger log)
        {
            logger = log;
        }
        List<string> AvailableProjects = new List<string>
        {
            "Jigsaw_8.1", "Mahjong_8.1", "Minesweeper_8.1", "Solitaire_8.1", "Sudoku", "Mahjong_Win10"
        };
        

        public bool isWin10flag;
        public List<string> GetProjectInfo(string folderWithBuildsPath)
        {
            List<string> BuildNames = new List<string>();
            //Program.FolderWithBuildsPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Test\";
            
            var directories = Directory.GetDirectories(folderWithBuildsPath, "*");
            foreach (string item in directories)
            {
                BuildNames.Add(item);
                logger.WriteToConsole(item + " was successfully found");
            }
            return BuildNames;
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
                    InReleasePathFolders = Directory.GetDirectories(ReleasePath);
                }
                if (folder.Contains("elease") && !folder.Contains("RELEASE") && !folder.Contains("rofile") && !folder.Contains("ebug"))
                {
                    ReleasePath = folder;
                    InReleasePathFolders = Directory.GetDirectories(ReleasePath + "\\Package_release\\");
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
                }
            }
            return ProjectFolder;
        }

        //Methods builds root folder paths for Profile and Release by current path
        public List<string> GetFinalDirectories(string path)
        {
            var buildFinalPaths = new List<string>();
            var ProfilePath = path + @"\profile\Package_profile\"; //Tuple1
            var ReleasePath = path + @"\release\Package_release\"; //Tuple2
            var tempProfilePath = GetDirectoriesInside(ProfilePath);
            var tempReleasePath = GetDirectoriesInside(ReleasePath);
            if (tempProfilePath.Count == 1 && tempReleasePath.Count == 1)
            {
                ProfilePath = tempProfilePath.First();
                ReleasePath = tempReleasePath.First();
                buildFinalPaths.Add(ProfilePath);
                buildFinalPaths.Add(ReleasePath);
                logger.WriteToConsole("Release and Profile folders were found");
            }
            else
            {
                logger.WriteToConsole("There are too many folders in profile or release folders");
            }
            return buildFinalPaths;
        }

        //Methods gets the list of directories inside the current path
        public List<string> GetDirectoriesInside(string path)
        {
            var directories = Directory.GetDirectories(path, "*");
            var CurrentBuildPath = new List<string>();
            foreach (string item in directories)
            {
                CurrentBuildPath.Add(item);
                //Logger(item);
            }
            return CurrentBuildPath;
        }
    }
}    
