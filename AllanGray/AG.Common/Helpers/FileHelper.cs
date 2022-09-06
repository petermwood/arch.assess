using System.IO;

namespace AG.Common.Helpers
{
    public static class FileHelper
    {
        public static string BuildFilePath(string folder, string file)
        {
            return Path.Combine(folder, file);
        }

        public static bool ValidateFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;

            if (!File.Exists(filePath))
                return false;

            return true;
        }
    }
}
