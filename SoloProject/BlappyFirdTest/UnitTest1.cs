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
        public void WhenAUserChangesDifficulty_DifficultyForUserChanges()
        {
            using (var db = new BFContext())
            {
                var before = db.Difficulty.Where(x => x.UsersId == 1).FirstOrDefault().Speed;
                _logic.updateSpeed(1, 100, "increase");
                var after = db.Difficulty.Where(x => x.UsersId == 1).FirstOrDefault().Speed;
                Assert.That(before, Is.Not.EqualTo(after));
            }
        }
        [Test]
        public void WhenAUserChecksLeaderboard_LeaderboardIsReturned()
        {
            using (var db = new BFContext())
            {
                var query = db.Users.Join(db.Scores, 
                    user => user.UsersId, 
                    score => score.UsersId, 
                    (user, score) => 
                    new { username = user.Username, highest = score.HighestScore, created = user.Created }).ToList();
                var testQuery = BlappyFirdLogic.GetLeaderboard();
                Assert.That(query, Is.EqualTo(testQuery));
            }
        }
        [Category("Logic/Game Tier")]
        [Test]
        public void WhenAUserSubmitsFeedback_FeedbackIsRecieved()
        {
            throw new NotImplementedException();
        }

    }
}