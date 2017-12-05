using AngryBirds.Models;
using AngryBirds.Controllers;
using System.Data.Entity;
using System.Linq;
using System;

namespace AngryBirds
{
    class Program
    {

        static AngryBirdsContext context = new AngryBirdsContext();


        static void Main(string[] args)
        {
            
            View views = new View();

            views.Start();
            views.Menu();


            Console.ReadLine();
        }
    }

    public class AngryBirdsContext : DbContext
    {

        public const string ConnectionString = (@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AngryBirdsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                                                  

        public AngryBirdsContext() : base(ConnectionString) { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Score> Score { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Score>().HasRequired(s => s.Player);
            modelBuilder.Entity<Score>().HasRequired(s => s.Level);

            modelBuilder.Entity<Player>().HasMany(p => p.Scores).WithRequired(s => s.Player).WillCascadeOnDelete(false);
            modelBuilder.Entity<Level>().HasMany(l => l.Scores).WithRequired(s => s.Level).WillCascadeOnDelete(false);
            

            base.OnModelCreating(modelBuilder);
        }
    }


}
