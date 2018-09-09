using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutomationTest.Generic.Utils
{
    public static class DirectoryUtil
    {
        /// <summary>
        /// Create folder under specified path.
        /// </summary>
        /// <param name="path"></param>
        public static void CreateFolder(string path)
        {
            Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Create specified folder, delete it if it already existed.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="deleteExist"></param>
        public static void CreateFolder(string path, bool deleteExist)
        {
            if (Directory.Exists(path) && deleteExist == true)
            {
                DeleteFolder(path);
            }

            if (!Directory.Exists(path))
            {
                CreateFolder(path);
            }
        }

        /// <summary>
        /// Delete specified folder.
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteFolder(string path)
        {
            Directory.Delete(path, true);
        }

        /// <summary>
        /// Clear folder under specfied path.
        /// </summary>
        /// <param name="path"></param>
        public static void EmptyFolder(string path)
        {
            Log.Trace("Empty folder =>" + path);
            foreach (string file in Directory.GetFileSystemEntries(path))
            {
                if (File.Exists(file))
                {
                    FileUtil.DeleteFile(file);
                }
                else
                {
                    try
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(file);
                        if (directoryInfo.GetFiles().Length != 0)
                        {
                            EmptyFolder(directoryInfo.FullName);
                        }
                        Log.Trace("Delete directory =>" + file);
                        Directory.Delete(file, true);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Fail to delete directory >>" + file, ex);
                    }
                }
            }
        }

        public static void CreateTempFolder()
        { }

        public static void GetCurrentDirectory()
        { }

        /// <summary>
        /// Get current solution directory.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentSolutionDirectory()
        {
            string currentDir = Directory.GetCurrentDirectory();
            return GetDirectory(".sln", currentDir);
        }

        /// <summary>
        /// Get current project directory.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentProjectDirectory()
        {
            string currentDir = Directory.GetCurrentDirectory();
            return GetDirectory(".csproj", currentDir);
        }

        /// <summary>
        /// Get directory which contains file, begin searching from specified path.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="searchPath"></param>
        /// <returns></returns>
        public static string GetDirectory(string file, string searchPath, bool reverseSearch = true)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(searchPath);
            foreach (FileInfo fileInfo in dirInfo.GetFiles())
            {
                if (fileInfo.Name.Contains(file))
                {
                    return dirInfo.FullName;
                }
            }
            if (reverseSearch == true)
            {
                dirInfo = dirInfo.Parent;
            }
            else
            {
                foreach (DirectoryInfo subDirInfo in dirInfo.GetDirectories())
                {
                    return GetDirectory(file, subDirInfo.FullName);
                }
            }
            return GetDirectory(file, dirInfo.FullName);
        }

        /// <summary>
        /// Get directory of specified project under specified solution.
        /// </summary>
        /// <param name="solutionDir"></param>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public static string GetProjectDirectory(string solutionDir, string projectName)
        {
            return GetDirectory(projectName, solutionDir, false);
        }

        public static void CopyFolderTo()
        { }
    }
}
