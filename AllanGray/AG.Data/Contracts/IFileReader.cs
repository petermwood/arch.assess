using System.Collections.Generic;

namespace AG.Data.Contracts
{
    public interface IFileReader
    {
        IList<string> Read(string path);
    }
}
