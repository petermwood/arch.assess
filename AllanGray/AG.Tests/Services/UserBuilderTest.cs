using AG.Data.Contracts;
using AG.Data.Entities;
using AG.Data.Services.Mocks;
using System.Collections.Generic;
using Xunit;

namespace AG.Tests.Services
{
    public class UserBuilderTest
    {
        #region Readonly Fields

        private readonly List<string> _userLines;
        private readonly IMockUserBuilder _userBuilder;

        #endregion

        #region Constants

        private const string FOLLOWS = "follows";

        #endregion

        #region Ctor

        public UserBuilderTest()
        {
            _userLines = new List<string>();
            _userLines.Add("Ward follows Alan");
            _userLines.Add("Alan follows Martin");
            _userLines.Add("Ward follows Martin, Alan");

            _userBuilder = new MockUserBuilder();
        }

        #endregion

        #region Methods

        [Fact]
        public void Create_Users_Should_Not_Be_Null()
        {
            var results = _userBuilder.BuildUsers(_userLines);

            Assert.NotNull(results);
        }

        [Fact]
        public void Create_Users_Should_Contain_Three_Tweets()
        {
            var results = _userBuilder.BuildUsers(_userLines);

            Assert.True(results.Count == 3);
        }

        [Fact]
        public void Create_Users_Should_TypeOf_ListOf_User()
        {
            var results = _userBuilder.BuildUsers(_userLines);

            Assert.True(results.GetType() == typeof(List<User>));
        }

        [Fact]
        public void Create_Single_User_Should_Not_Be_Null()
        {
            var result = _userBuilder.BuildUsersFromLine(_userLines[0], FOLLOWS);

            Assert.NotNull(result);
        }

        [Fact]
        public void Create_Single_User_Should_Be_TYpeOf_User()
        {
            var result = _userBuilder.BuildUsersFromLine(_userLines[0], FOLLOWS);

            Assert.True(result[0].GetType() == typeof(User));
        }

        #endregion
    }
}
