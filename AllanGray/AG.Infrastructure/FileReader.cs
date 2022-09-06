using AG.Common.Helpers;
using AG.Data.Contracts;
using System;
using System.Collections.Generic;
using System.IO;

namespace AG.Infrastructure
{
    public class FileReader : IFileReader
    {
   
        #region Methods

        public IList<string> Read(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException($"{filePath} not found");

                if (!FileHelper.ValidateFile(filePath))
                    return null;

                var results = ReadLines(filePath);

                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private IList<string> ReadLines(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                var line = string.Empty;
                var lines = new List<string>();

                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }

                return lines;
            }
        }

        #endregion

    }
}
