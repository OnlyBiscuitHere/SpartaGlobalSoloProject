using System;
using System.Linq;
using System.Collections.Generic;
using BlappyFirdContext;
using System.Diagnostics;

namespace BlappyFird
{
    public class BlappyFirdLogic
    {
        public Users selectedUser { get; set; }
        public void setSelectedUser(object selectedItem)
        {
            selectedUser = (Users)selectedItem;
        }
        public int score {get; set;}
        public int returnUser(string username)
        {
            using (var db = new BFContext())
            {
                var query = db.Users.Where(x => x.Username == username);
                return query.FirstOrDefault().UsersId;
            }
        }
        public void addUser(string username, string password, DateTime date)
        {
            var newUser = new Users() { Username = username, Password = password, Created = date };
            var newUserDifficulty = new Difficulty() { UsersId = newUser.UsersId, Speed = 100 };
            var newUserScore = new Scores() { UsersId = newUser.UsersId, RecentScore = 0 };
            using (var db = new BFContext())
            {
                db.Users.Add(newUser);
                db.Difficulty.Add(newUserDifficulty);
                db.Scores.Add(newUserScore);
                db.SaveChanges();
            }
        }
        public bool deleteUser(int id)
        {
            using (var db = new BFContext())
            {
                var query = from u in db.Users where u.UsersId == id select u;
                if (query == null)
                {
                    return false;
                }
                db.Users.RemoveRange(query.FirstOrDefault());
                db.SaveChanges();
            }
            return true;
        }
        public List<Users> printAllUsers()
        {
            using (var db = new BFContext())
            {
                return db.Users.ToList(); 
            }
        }
        public bool checkUser(string username, string password)
        {
            using (var db = new BFContext())
            {
                var query = db.Users.Where(x => x.Username == username && x.Password == password);
                if (query.Count() == 1)
                    return true;
                else
                    return false;
            }
        }
        public bool updateUser(int userId, string username, string password)
        {
            using (var db = new BFContext())
            {
                var user = db.Users.Where(u => u.UsersId == userId).FirstOrDefault();
                if (user == null)
                {
                    Debug.WriteLine($"User: {userId} not found");
                    return false;
                }
                user.Username = username;
                user.Password = password;
                try
                {
                    db.SaveChanges();
                    selectedUser = user;
                }
                catch(Exception e)
                {
                    Debug.WriteLine($"Error updating {userId}");
                    return false;
                }
                return true;
            }
        }
        public void updateScore(int userId, int score)
        {
            using (var db = new BFContext())
            {
                var query = db.Scores.Where(x => x.UsersId == userId);
                if (query.Count() == 1)
                {
                    if (query.FirstOrDefault().HighestScore < score)
                    {
                        query.FirstOrDefault().HighestScore = score;
                    }
                    query.FirstOrDefault().RecentScore = score;
                }
                else
                {
                    Scores newScore = new Scores() { UsersId = userId, RecentScore = score, HighestScore = score };
                    db.Scores.Add(newScore);
                }
                db.SaveChanges();
            }
        }
        public void createSpeed(int userId)
        {
            using (var db = new BFContext())
            {
                Difficulty newUser = new Difficulty() { Speed = 0 };
                db.Difficulty.Add(newUser);
                db.SaveChanges();
            }
        }
        public int getSpeed(int userId)
        {
            using (var db = new BFContext())
            {
                var query = db.Difficulty.Where(x => x.UsersId == userId);
                if (query.Count() == 1)
                {
                    return query.FirstOrDefault().Speed;
                }
                else
                    return 100;
            }
        }
        public void updateSpeed(int userId, int speed, string difficulty)
        {
            using (var db = new BFContext())
            {
                var query = db.Difficulty.Where(x => x.UsersId == userId);
                if (query.Count() == 1)
                {
                    if (difficulty == "increase")
                    {
                        switch (speed)
                        {
                            case 50:
                                query.FirstOrDefault().Speed = 10;
                                break;
                            case 100:
                                query.FirstOrDefault().Speed = 50;
                                break;
                            case 150:
                                query.FirstOrDefault().Speed = 100;
                                break;
                        }
                    }
                    else
                    {
                        switch (speed)
                        {
                            case 50:
                                query.FirstOrDefault().Speed = 100;
                                break;
                            case 10:
                                query.FirstOrDefault().Speed = 50;
                                break;
                            case 100:
                                query.FirstOrDefault().Speed = 150;
                                break;
                        }
                    }
                }
                db.SaveChanges();
            }
        }
        public class Query
        {
            public virtual string Username { get; set; }
            public virtual int Highscore { get; set; }
            public virtual DateTime? Created { get; set; }
        }

        public static List<Query> GetLeaderboard()
        {
            using (var db = new BFContext())
            {
                var query = from user in db.Users
                            join score in db.Scores on user.UsersId equals score.UsersId
                            where user.Username != "admin"
                            orderby score.HighestScore descending
                            select new Query{ Username = user.Username, Highscore = score.HighestScore, Created = user.Created};
                return query.ToList();
            }
        }
    }
}
