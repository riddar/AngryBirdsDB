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

        static void AddLevel(string levelName, int birds)
        {
            Level newLevel = new Level() { Name = levelName, Birds = birds };

            try
            {
                context.Levels.Add(newLevel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                context.SaveChanges();
            }
        }

        static IList<Level> GetAllLevels()
        {
            List<Level> allLevels = new List<Level>();
            try
            {
                allLevels = (from level in context.Levels
                             select level).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return allLevels;
        }

        static Level GetLevelById(int levelId)
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

        static bool DeleteLevelById(int levelId)
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
