using System.Collections.Generic;

namespace AG.Data.Contracts
{
    public interface IBuilder<T> where T : class
    {
        IList<T> Build(string filePath);
    }
}
