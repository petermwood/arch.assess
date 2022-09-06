using AG.Data.Contracts;
using AG.Data.Services;
using AG.Infrastructure;
using System.IO;
using Xunit;

namespace AG.Tests.FileReaderTests
{
    public class FileReaderTests
    {
        #region Fields

        private string _filePath = @"C:\dev\github\assessments\johanccs\Docs\";

        #endregion

        [Fact]
        public void Read_File_Lines()
        {
            _filePath = Path.Combine(_filePath, "user.txt");

            IFileReader reader = new FileReader();

            var results = reader.Read(_filePath);

            Assert.NotNull(results);
        }
    }
}
