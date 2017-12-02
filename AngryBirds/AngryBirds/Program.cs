using AngryBirds.Models;
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



            Console.ReadLine();
        }


        static void AddOrShowPlayer(string playerName)
        {
            Player thisPlayer = null;

            try
            {
                thisPlayer = (from player in context.Players
                              where player.Name == playerName
                              select player).First();


            }
            catch(Exception ex)
            {
                // Suppress exception for now...
            }
            finally
            {
                if (thisPlayer != null)
                {

                    var score = (from sc in context.Score
                                 where sc.PlayerId == thisPlayer.Id
                                 select sc).ToList();


                    Console.WriteLine($" {playerName} scores:");
                    foreach (var sc in score)
                        Console.WriteLine($" {sc.Level.Name}: {sc.Points} [{sc.Level.Birds} max]");


                }
                else
                {
                    thisPlayer = new Player();

                    thisPlayer.Name = playerName;

                    Console.WriteLine($"No player found with name '{playerName}', registering name.\n");
                    Console.WriteLine("Please enter a password for your account: ");
                    thisPlayer.Password = Console.ReadLine();

                    context.Players.Add(thisPlayer);
                    context.SaveChanges();
                }
            }
        }

        static void DeletePlayer(Player player)
        {
            context.Players.Remove(player);
            context.SaveChanges();
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
