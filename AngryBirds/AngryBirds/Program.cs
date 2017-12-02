using AngryBirds.Models;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;

namespace AngryBirds
{
    class Program
    {
        AngryBirdsContext context = new AngryBirdsContext();

        static void Main(string[] args)
        {
            

            

            

            
        }

        public IQueryable<Score> GetAllScores()
        {
            try
            {
                var scores = from score in context.Scores
                             select score;
                return scores;
            }
            catch(Exception e){
                throw e;
            }       
        }

        public void AddPlayerScoreByLevelId(int points, int playerId, int levelId)
        {
            Score score = new Score {Points = points, PlayerId = playerId, LevelId = levelId};

            try
            {
                context.Scores.insertOnSubmit(score);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void UpdateScoreById(int id)
        {

        }

        public void DeleteScoreById(int id)
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
        public DbSet<Score> Scores { get; set; }
    }
}
