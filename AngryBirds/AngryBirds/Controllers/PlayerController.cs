using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryBirds.Models;

namespace AngryBirds.Controllers
{
    class PlayerController
    {
        static AngryBirdsContext context = new AngryBirdsContext();

        public static IEnumerable<Player> GetAllPlayers()
        {
            try
            {
                var Players = from player in context.Players
                             select player;
                return (Players).AsEnumerable();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Player GetPlayerByName(string name)
        {
            Player player = null;
            try
            {
                player = (from players in context.Players
                          where players.Name == name
                          select players).FirstOrDefault();
                return player;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void AddOrShowPlayer(string playerName)
        {
            Player thisPlayer = null;

            try
            {
                thisPlayer = (from player in context.Players
                              where player.Name == playerName
                              select player).FirstOrDefault();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                if (thisPlayer != null)
                {

                    var score = ScoreController.GetScoreByPlayer(thisPlayer);

                    Console.WriteLine($" {playerName} scores:");
                    foreach (var sc in score)
                        Console.WriteLine($" {sc.Level.Name}: {sc.Points} drag [{sc.Level.Birds - sc.Points} kvar] Highscore: {sc.Level.Scores.Min().Points} by {sc.Level.Scores.Min().Player.Name}");
                }
                else
                {
                    thisPlayer = new Player();

                    thisPlayer.Name = playerName;

                    Console.WriteLine($"No player found with name '{playerName}', press any key to register!.\n");
                    Console.ReadKey(true);

                    context.Players.Add(thisPlayer);
                    context.SaveChanges();
                }
            }
        }

        public static void DeletePlayer(Player player)
        {
            context.Players.Remove(player);
            context.SaveChanges();
        }

        public static bool DeletePlayerByName(string Name)
        {
            Player player = null;
            try
            {
                player = (from players in context.Players
                         where players.Name == Name
                         select players).FirstOrDefault();

                if (player != null)
                {
                    context.Players.Remove(player);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
