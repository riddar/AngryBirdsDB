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

        public const string ConnectionString = (@"Data Source=(localdb)\MSSQLLocalDB;
                                                  Initial Catalog = AngryBirds; 
                                                  Integrated Security = True; 
                                                  Connect Timeout = 30; 
                                                  Encrypt=False;
                                                  TrustServerCertificate=True;
                                                  ApplicationIntent=ReadWrite;
                                                  MultiSubnetFailover=False");
        public AngryBirdsContext() : base(ConnectionString) { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Score> Score { get; set; }
    }


}
