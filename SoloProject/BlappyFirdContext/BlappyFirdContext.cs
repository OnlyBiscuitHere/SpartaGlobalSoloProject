using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BlappyFirdContext
{
    public partial class Users
    {
        public int UsersId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? Created { get; set; }
        public virtual Scores Scores { get; set; }
        public virtual Difficulty Difficulty { get; set; }
        public override string ToString()
        {
            return $"{UsersId} - {Username} - {Password} - {Created}";
        }

    }
    public partial class Scores
    {
        public int ScoresId { get; set; }
        public int RecentScore { get; set; }
        public int HighestScore { get; set; }
        public int UsersId { get; set; }
        public List<Users> Users { get; set; }
    }
    public partial class Difficulty
    {
        public int DifficultyId { get; set; }
        public int UsersId { get; set; }
        public int Speed { get; set; }
        public List<Users> Users { get; set; }
    }
    public class BFContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Scores> Scores { get; set; }
        public DbSet<Difficulty> Difficulty { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}