using System;
using System.Linq;
using System.Collections.Generic;
using BlappyFirdContext;


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
            using (var db = new BFContext())
            {
                db.Users.Add(newUser);
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
        public void createSpeed(int userId)
        {
            using (var db = new BFContext())
            {
                Difficulty hard = new Difficulty() { Speed = 10 };
                Difficulty medium = new Difficulty() { Speed = 500 };
                Difficulty easy = new Difficulty() { Speed = 600 };
                db.Difficulty.Add(hard);
                db.Difficulty.Add(medium);
                db.Difficulty.Add(easy);
                db.SaveChanges();
            }
        }
        public void updateScore(int userId, int score)
        {
            using (var db = new BFContext())
            {
                Scores newScore = new Scores() { UsersId = userId, RecentScore = score };
                db.Scores.Add(newScore);
            }
        }
    }
}
