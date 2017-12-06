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

        public static void AddOrShowPlayer(string playerName)
        {
            Player thisPlayer = null;

            try
            {
                thisPlayer = (from player in context.Players
                              where player.Name == playerName
                              select player).First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (thisPlayer != null)
                {

                    var score = ScoreController.GetScoreByPlayer(thisPlayer);

                    Console.WriteLine($" {playerName} scores:");
                    foreach (var sc in score)
                        Console.WriteLine($" {sc.Level.Name}: {sc.Points} drag [{sc.Level.Birds - sc.Points} kvar] Highscore: {sc.Level.Scores.Max().Points} by {sc.Level.Scores.Max().Player.Name}");
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

        public static IList<Player> GetAllPlayers()
        {

            List<Player> allPlayers = new List<Player>();
            try
            {
                allPlayers = (from player in context.Players
                              select player).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return allPlayers;
        }

        public static Player GetPlayerById(int id)
        {
            Player thisPlayer = null;

            try
            {
                thisPlayer = (from player in context.Players
                              where player.Id == id
                              select player).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return thisPlayer;
        }

        public static Player GetPlayerByName(string name)
        {
            Player thisPlayer = null;

            try
            {
                thisPlayer = (from player in context.Players
                              where player.Name == name
                              select player).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return thisPlayer;
        }

        public static void DeletePlayer(Player player)
        {

            List<Score> playerScores = ScoreController.GetScoreByPlayer(player);

            foreach (Score s in playerScores)
                ScoreController.DeleteScoreById(s.Id);

            context.Players.Remove(player);
            context.SaveChanges();
        }

        public static bool DeletePlayerByName(string name)
        {
            Player thisPlayer = null;
            try
            {
                thisPlayer = GetPlayerByName(name);

                if (thisPlayer != null)
                {
                    List<Score> playerScores = new List<Score>();
                    playerScores = ScoreController.GetScoreByPlayer(thisPlayer);

                    // Remove all the players scores. (RemoveRange doesn't work, because of reasons.)
                    foreach (Score s in playerScores)
                        ScoreController.DeleteScoreById(s.Id);

                    context.Players.Remove(thisPlayer);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
