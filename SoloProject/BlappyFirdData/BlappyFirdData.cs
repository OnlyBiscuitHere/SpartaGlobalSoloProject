using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace FlappyBirdData 
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ScoreId { get; set; }
        public virtual List<Scores> Scores { get; set; }
        public virtual List<Difficulty> Difficulty { get; set; }
    }
    public class Scores
    {
        public int Id { get; set; }
        public int RecentScore { get; set; }
        public int HighestScore { get; set; }
        public int LowestScore { get; set; }
        public ICollection<Users> Users { get; set; }
    }
    public class Difficulty
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string DifficultyState { get; set; }
        public ICollection<Users> Users { get; set; }
    }
    public class BusinessSide : DbContext
    {
        public BusinessSide()
        {

        }
        public BusinessSide(DbContextOptions<BusinessSide> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Scores> Scores { get; set; }
        public DbSet<Difficulty> Difficulty { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }

}


