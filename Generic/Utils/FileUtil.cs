using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutomationTest.Generic.Utils
{
    public static class FileUtil
    {
        /// <summary>
        /// Create new file.
        /// </summary>
        /// <param name="path"></param>
        public static void CreateFile(string path)
        {
            FileStream fileStream = File.Create(path);
            fileStream.Close();
            fileStream.Dispose();
        }

        /// <summary>
        /// Delete specified file.
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteFile(string path)
        {
            LogUtil.Trace("Delete file =>" + path);
            try
            {
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Attributes.ToString().IndexOf("ReadOnly") != -1)
                {
                    fileInfo.Attributes = FileAttributes.Normal;
                }
                File.GetAccessControl(path);
                File.Delete(path);
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to delete file >>" + path, ex);
            }
        }


        public static void DeleteFiles(string path)
        {
                              
        }

        /// <summary>
        /// Copy files from source directory to destination directory.
        /// </summary>
        /// <param name="sourceDir"></param>
        /// <param name="destDir"></param>
        public static void CopyFiles(string sourceDir, string destDir)
        {
            LogUtil.Trace("Copy files from " + sourceDir + " to " + destDir);
            if (!Directory.Exists(destDir))
            {
                DirectoryUtil.CreateFolder(destDir);
            }

            foreach (string file in Directory.GetFileSystemEntries(sourceDir))
            {
                if (File.Exists(file))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    CopyFile(file, Path.Combine(destDir, fileInfo.Name));
                }
                else
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(file);
                    string subDir = Path.Combine(destDir, directoryInfo.Name);
                    DirectoryUtil.CreateFolder(subDir);
                    try
                    {
                        if (directoryInfo.GetFiles().Length != 0)
                        {
                            CopyFiles(directoryInfo.FullName, subDir);
                        } 
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Fail to copy files under directory >>" + directoryInfo.FullName + "to directory >>" + subDir, ex);
                    }
                }
            }
        }

        /// <summary>
        /// Copy source file to specified destination.
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="destFileName"></param>
        /// <param name="overwrite"></param>
        public static void CopyFile(string sourceFileName, string destFileName, bool overwrite=true)
        {
            LogUtil.Trace("Copy file from " + sourceFileName + " to " + destFileName);
            try
            {
                File.Copy(sourceFileName, destFileName, overwrite);  
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to copy file >>" + sourceFileName+" to >>" + destFileName, ex);
            }        
        }

        /// <summary>
        /// Append text to specified file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contents"></param>
        public static void AppendText(string path, string contents, bool useFileStream = false)
        {
            if (useFileStream == false)
            {
                File.AppendAllText(path, contents + "\r\n");
            }
            else
            {
                AppendTextByFileStream(path, contents);
            }
        }       

        /// <summary>
        /// Read all text from specified text.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ReadAllText(string path, bool useFileStream=false)
        {
            if (useFileStream == false)
            {
                return File.ReadAllText(path);
            }
            else
            {
                return ReadAllTextByFileStream(path);
            }
        }

        /// <summary>
        /// Read line from specified text.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IEnumerable<string> ReadLines(string path)
        {
            return File.ReadLines(path);
        }

        /// <summary>
        /// Append text to specified file by file stream reader.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contents"></param>
        private static void AppendTextByFileStream(string path, string contents)
        {
            FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write);
            byte[] contentsByte = Encoding.UTF8.GetBytes(contents + "\r\n");

            fileStream.Write(contentsByte, 0, contentsByte.Length);

            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
        }

        /// <summary>
        /// Read all text from specified file by file stream reader.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string ReadAllTextByFileStream(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            int fileStreamLength = (int)fileStream.Length;
            byte[] contentsByte = new byte[fileStreamLength];

            int bytesNo = fileStream.Read(contentsByte,0, fileStreamLength);
            string contents = System.Text.Encoding.UTF8.GetString(contentsByte);

            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
            return contents;
        }

    }
}
