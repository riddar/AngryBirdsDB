using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryBirds.Models;

namespace AngryBirds.Controllers
{
    public class LevelController
    {
        static AngryBirdsContext context = new AngryBirdsContext();

        public static IEnumerable<Level> GetAllLevels()
        {
            try
            {
                var levels = from level in context.Levels
                             select level;
                return (levels).AsEnumerable();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Level AddOrUpdateLevel(string levelName, int birds)
        {
            Level newLevel = new Level() { Name = levelName, Birds = birds };
            Level level = null;

            try
            {
                level = (from levels in context.Levels
                         where levels.Name == levelName
                         select level).FirstOrDefault();

                if (level != null)
                {
                    context.Entry(level).CurrentValues.SetValues(newLevel);
                    context.SaveChanges();
                    return level;
                }
                else
                {
                    context.Levels.Add(newLevel);
                    context.SaveChanges();
                    return newLevel;
                }       
            }
            catch (Exception ex)
            {
                return null; 
            }
        }

        public static Level GetLevelById(int levelId)
        {
            Level level = null;
            try
            {
                level = (from lev in context.Levels
                            where lev.Id == levelId
                            select lev).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return level;
        }

        public static bool DeleteLevelByName(string name)
        {
            Level level = null;
            try
            {
                level = (from lev in context.Levels
                         where lev.Name == name
                         select lev).Single();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            if (level != null)
            {
                context.Levels.Remove(level);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
