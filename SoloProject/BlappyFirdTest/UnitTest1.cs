using NUnit.Framework;
using System;

namespace BlappyFirdTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Category("Database Tier - Basic CRUD")]
        [Test]
        public void WhenAUserIsAdded_NumberOfUsersIncrements()
        {
            throw new NotImplementedException();
        }
        [Test]
        public void WhenAnAdminIsAdded_NumberOfAdminsIncrements()
        {
            throw new NotImplementedException();
        }
        [Test]
        public void WhenAUsernameIsChanged_DatabaseIsUpdated()
        {
            throw new NotImplementedException();
        }
        [Test]
        public void WhenAnAdminRemovesAUser_NumberOfUsersDecrements()
        {
            throw new NotImplementedException();
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