using AG.Data.Entities;
using System.Collections.Generic;

namespace AG.Data.Contracts
{
    public interface IMockUserBuilder
    {
        IList<User> BuildUsers(IList<string> lines);

        IList<User> BuildUsersFromLine(string userLine, string criteria);
    }
}
