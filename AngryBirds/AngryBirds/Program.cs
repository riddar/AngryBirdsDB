using AngryBirds.Models;
using System.Data.Entity;

namespace AngryBirds
{
    class Program
    {
        static void Main(string[] args)
        {
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
