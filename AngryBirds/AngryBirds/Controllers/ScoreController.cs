using AngryBirds.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirds.Controllers
{
    class ScoreController
    {
        static AngryBirdsContext context = new AngryBirdsContext();

        public static IEnumerable<Score> GetAllScores()
        {
            try
            {
                var scores = from score in context.Score
                             select score;
                return (scores).AsEnumerable();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Score GetScoreById(int id)
        {
            Score score = null;

            try
            {
                score = (from scoreId in context.Score
                         where scoreId.Id == id
                         select scoreId).First();
                return score;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<Score> GetScoreByLevel(Level level)
        {
            var scores = (from score in context.Score
                          where score.Level.Id == level.Id
                          select score).ToList();

            return scores;
        }

        public static List<Score> GetScoreByPlayer(Player player)
        {
            var scores = (from score in context.Score
                          where score.Player.Id == player.Id
                          select score).ToList();

            return scores;
        }

        public static void AddScore(int points, Player player, Level level)
        {
            Score score = new Score { Points = points, Player = player, Level = level };

            try
            {
                context.Score.Add(score);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                return;
            }

        }

        public static Score AddOrUpdateScoreById(int id, int points, Player player, Level level)
        {
            Score newScore = new Score { Points = points, Player = player, Level = level };
            Score score = null;

            try
            {
                score = (from scoreId in context.Score
                         where scoreId.Id == id
                         select scoreId).Single();

                if (score != null)
                {
                    context.Score.Add(newScore);
                    context.SaveChanges();
                    return newScore;
                }
                else
                {
                    context.Score.Add(newScore);
                    context.SaveChanges();
                    return newScore;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Score AddOrUpdateScoreByPlayerNameandlevelname(int points, string playername, string levelname)
        {
            
            Score score = null;
            Player player = null;
            Level level = null;
            

            try
            {
                score = (from scores in context.Score
                         where scores.Player.Name == playername && scores.Level.Name == levelname
                         select scores).FirstOrDefault();
                
                if (score != null)
                {
                    player = (from players in context.Players
                              where players.Name == playername
                              select players).FirstOrDefault();
                    level = (from levels in context.Levels
                             where levels.Name == levelname
                             select levels).FirstOrDefault();
                    Score newScore = new Score { Points = points, PlayerId = player.Id, LevelId = level.Id };
                    context.Entry(score).CurrentValues.SetValues(newScore);
                    context.SaveChanges();
                    return score;
                }
                else
                {
                    PlayerController.AddOrShowPlayer(playername);
                    LevelController.AddOrUpdateLevel(levelname, 0);
                    player = (from players in context.Players
                              where players.Name == playername
                              select players).FirstOrDefault();
                    level = (from levels in context.Levels
                             where levels.Name == levelname
                             select levels).FirstOrDefault();
                    Score newScore = new Score { Points = points, PlayerId = player.Id, LevelId = level.Id };

                    context.Score.Add(newScore);
                    context.SaveChanges();
                    return newScore;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Score UpdateScorePointsById(int id, int points)
        {
            Score score = null;
            try
            {
                score = (from scoreId in context.Score
                         where scoreId.Id == id
                         select scoreId).Single();

                if (score != null)
                {
                    score.Points = points;
                    context.SaveChanges();
                    return score;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool DeleteScoreByLevelNameAndPlayerName(string PlayerName, string LevelName)
        {
            Score score = null;
            try
            {
                score = (from scores in context.Score
                         where scores.Player.Name == PlayerName && scores.Level.Name == LevelName
                         select scores).FirstOrDefault();

                if (score != null)
                {
                    context.Score.Remove(score);
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

        public static bool DeleteScoreByPlayerName(string PlayerName)
        {
            Score score = null;
            try
            {
                score = (from scores in context.Score
                         where scores.Player.Name == PlayerName
                         select scores).FirstOrDefault();

                if (score != null)
                {
                    context.Score.Remove(score);
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
