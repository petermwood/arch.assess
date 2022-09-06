using AG.Common.Helpers;
using AG.Data.Contracts;
using AG.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AG.Data.Services.Mocks
{
    public class MockUserBuilder : IMockUserBuilder
    {
        #region Constants

        private const string FOLLOWS = "follows";

        #endregion

        #region Methods

        public IList<User> BuildUsers(IList<string> lines)
        {
            var users = new List<User>();

            foreach (var line in lines)
            {
                var retUsers = BuildUsersFromLine(line, FOLLOWS);

                if (retUsers != null)
                {
                    users.AddRange(retUsers);
                }
            }

            var distinctList = users.GroupBy(x => x.Name)
                .Select(x => x.First())
                .OrderBy(x => x.Name)
                .ToList();

            return distinctList;
        }

        public IList<User> BuildUsersFromLine(string userLine, string criteria)
        {
            if (!StringHelper.Contains(userLine, criteria))
                throw new ArgumentException("Invalid user");

            var users = new List<User>();
            var results = userLine.Split(criteria);

            if (results.Length > 0)
            {
                foreach (var result in results)
                {
                    if (result.Contains(","))
                    {
                        var userResults = BuildUsersFromLine(result, ",");
                        users.AddRange(userResults);
                    }
                    else
                        users.Add(new User(result.Trim()));
                }
            }

            return users;
        }

        #endregion
    }
}
