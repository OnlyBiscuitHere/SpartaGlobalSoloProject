using NUnit.Framework;
using System;
using BlappyFird;
using BlappyFirdContext;
using System.Linq;

namespace BlappyFirdTest
{
    public class Tests
    {
        private BlappyFirdLogic _logic = new BlappyFirdLogic();
        [SetUp]
        public void Setup()
        {
        }
        [Category("Database Tier - Basic CRUD")]
        [Test]
        public void WhenAUserIsAdded_NumberOfUsersIncrements()
        {
            using (var db = new BFContext())
            {
                var query = db.Users;
                var beforeCount = query.Count();
                _logic.addUser("Testing", "Tester", DateTime.Now);
                var afterCount = query.Count();
                Assert.That(afterCount > beforeCount, Is.EqualTo(true));
            }
        }
        [Test]
        public void WhenAUsernameIsChanged_DatabaseIsUpdated()
        {
            throw new NotImplementedException();
        }
        [Test]
        public void WhenAnAdminRemovesAUser_NumberOfUsersDecrements()
        {
            using (var db = new BFContext())
            {
                _logic.addUser("Testing", "Tester", DateTime.Now);
                var query = from u in db.Users where u.Username == "Testing" select u;
                var beforeCount = query.Count();
                _logic.deleteUser(query.FirstOrDefault().UsersId);
                var afterCount = query.Count();
                Assert.That(afterCount < beforeCount, Is.EqualTo(true));
            }
        }
        [Test]
        public void WhenAUserFinishesARound_ScoreIsUpdated()
        {
            throw new NotImplementedException();
        }
        [Category("Database Tier - Advacned CRUD")]
        [Test]
        public void WhenAnInvalidUsernameOrPasswordIsInputted_MessageBoxIsShown()
        {
            throw new NotImplementedException();
        }
        [Test]
        public void WhenAUserWantsToSeeLeaderBoard_LeaderBoardIsOutputted()
        {
            throw new NotImplementedException();
        }
        [Test]
        public void WhenAnAdminWantsToViewUserData_UserDataIsOutputted()
        {
            throw new NotImplementedException();
        }

        [Category("Logic/Game Tier")]
        [Test]
        public void WhenAUserSubmitsFeedback_FeedbackIsRecieved()
        {
            throw new NotImplementedException();
        }
        public void WhenAUserWantsToSeeTheControlsForTheGame_MethodIsCalled()
        {
            throw new NotImplementedException();
        }
    }
}