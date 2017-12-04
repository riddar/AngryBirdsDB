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
            Score score = null;
            Score score2 = new Score { Points = points, Player = player, Level = level };

            try
            {
                score = (from scoreId in context.Score
                         where scoreId.Id == id
                         select scoreId).Single();

                if (score != null)
                {
                    context.Score.Add(score2);
                    context.SaveChanges();
                    return score2;
                }
                else
                {
                    return score;
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

        public static bool DeleteScoreById(int id)
        {
            Score score = null;
            try
            {
                score = (from scoreId in context.Score
                         where scoreId.Id == id
                         select scoreId).Single();

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
