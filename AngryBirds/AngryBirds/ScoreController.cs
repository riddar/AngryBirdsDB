﻿using AngryBirds.Models;
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

        static IEnumerable<Score> GetAllScores()
        {
            try
            {
                var scores = from score in context.Scores
                             select score;
                return (scores).AsEnumerable();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        static Score GetScoreById(int id)
        {
            Score score = null;

            try
            {
                score = (from scoreId in context.Scores
                             where scoreId.Id == id
                             select scoreId).First();
                return score;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        static void AddScore(int points, int playerId, int levelId)
        {
            Score score = new Score { Points = points, PlayerId = playerId, LevelId = levelId };

            try
            {
                context.Scores.Add(score);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                context.SaveChanges();
            }
            
        }

        static Score AddOrUpdateScoreById(int id, int points, int playerId, int levelId)
        {
            Score score = null;
            Score score2 = new Score { Points = points, PlayerId = playerId, LevelId = levelId };

            try
            {
                score = (from scoreId in context.Scores
                               where scoreId.Id == id
                               select scoreId).Single();

                if (score != null)
                {
                    context.Scores.Add(score2);
                    return score2;
                }
                else
                {
                    return score;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                context.SaveChanges();
            }
        }

        static Score UpdateScorePointsById(int id, int points)
        {
            Score score = null;
            try
            {
                score = (from scoreId in context.Scores
                         where scoreId.Id == id
                         select scoreId).Single();

                if (score != null)
                {
                    score.Points = points;
                    return score;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                context.SaveChanges();
            }
            
        }

        static bool DeleteScoreById(int id)
        {
            Score score = null;
            try
            {
                score = (from scoreId in context.Scores
                         where scoreId.Id == id
                         select scoreId).Single();

                if (score != null)
                {
                    context.Scores.Remove(score);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                context.SaveChanges();
            }
        }
    }
}
