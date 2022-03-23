using System.Collections.Generic;
using System.IO;

namespace Byui.Game.Services
{
    /// <summary>
    /// Defines convenience methods for working with directories and files.
    /// </summary>
    public class FileUtil
    {
        public static List<string> GetFilepaths(string directory, string[] searchPatterns)
        {
            List<string> filepaths = new List<string>();
            foreach (string searchPpattern in searchPatterns)
            {
                string[] files = Directory.GetFiles(directory, searchPpattern);
                filepaths.AddRange(files);
            }
            return filepaths;
        }

        private FileUtil() { }
    }
}