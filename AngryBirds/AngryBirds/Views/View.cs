using System;
using AngryBirds.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryBirds.Models;

namespace AngryBirds
{
    public class View
    {
        public void Header()
        {
            Console.WriteLine(
            "_______  __    _  _______  ______    __   __  _______  ___   ______    ______   _______\n"+
            "|   _   ||  |  | ||       ||    _ |  |  | |  ||  _    ||   | |    _ |  |      | |       |\n" +
            "|  |_|  ||   |_| ||    ___||   | ||  |  |_|  || |_|   ||   | |   | ||  |  _    ||  _____|\n" +
            "|       ||       ||   | __ |   |_||_ |       ||       ||   | |   |_||_ | | |   || |_____ \n" +
            "|       ||  _    ||   ||  ||    __  ||_     _||  _   | |   | |    __  || |_|   ||_____  |\n" +
            "|   _   || | |   ||   |_| ||   |  | |  |   |  | |_|   ||   | |   |  | ||       | _____| |\n" +
            "|__| |__||_|  |__||_______||___|  |_|  |___|  |_______||___| |___|  |_||______| |_______|\n");
        }

        public void Footer()
        {
            Console.WriteLine(
            "-------------------------------------------------------------------------------------------");
        }

        public void Menu()
        {
            Console.Clear();
            Header();
            Console.WriteLine("---------------------------");
            Console.WriteLine("|        StartMenu        |");
            Console.WriteLine("|     1. Search names     |");
            Console.WriteLine("|      2. Print Tables    |");
            Console.WriteLine("|         3. Quit         |");
            Console.WriteLine("---------------------------");
            Footer();
            try
            {
                bool KeepGoing = true;
                do
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            var res = Name();
                            Player(res);
                            break;
                        case ConsoleKey.D2:
                            Tables();
                            break;
                        case ConsoleKey.D3:
                            KeepGoing = false;
                            break;
                        default:
                            break;
                    }
                } while (KeepGoing != false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        public string Name()
        {
            Console.Clear();
            Header();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"  Enter your name below    ");
            Console.WriteLine("---------------------------");
            string result = Console.ReadLine();
            return result;
        }

        public void Player(string name)
        {
            Console.Clear();
            Header();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"      {name}");
            Console.WriteLine("|     1.add/show          |");
            Console.WriteLine("|     2.update score      |");
            Console.WriteLine("|     3.Remove Score      |");
            Console.WriteLine("|     4.Remove Player     |");
            Console.WriteLine("|     5.return            |");
            Console.WriteLine("---------------------------");
            Footer();

            try
            {
                bool KeepGoing = true;
                do
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            PlayerController.AddOrShowPlayer(name);
                            break;
                        case ConsoleKey.D2:
                            Console.Write("please enter the score: ");
                            int score = int.Parse(Console.ReadLine());
                            var player = PlayerController.GetPlayerByName(name);
                            foreach (var scores in player.Scores)
                            {
                                var playerLevel = LevelController.GetLevelById(scores.LevelId);
                                Console.WriteLine($"Level: {playerLevel.Name}, Highscore: {scores.Points}");
                            }
                            Console.Write("and the level name: ");
                            string level = Console.ReadLine();
                            ScoreController.AddOrUpdateScoreByPlayerNameandlevelname(score, name, level);
                            break;
                        case ConsoleKey.D3:
                            ScoreController.DeleteScoreByPlayerName(name);
                            break;
                        case ConsoleKey.D4:
                            PlayerController.DeletePlayerByName(name);
                            break;
                        case ConsoleKey.D5:
                            KeepGoing = false;
                            Menu();
                            break;
                        default:
                            
                            break;
                    }
                } while (KeepGoing != false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Tables()
        {
            Console.Clear();
            Header();
            Console.WriteLine("---------------------------");
            Console.WriteLine("|         Tables          |");
            Console.WriteLine("|         1.players       |");
            Console.WriteLine("|         2.Scores        |");
            Console.WriteLine("|         3.Level         |");
            Console.WriteLine("|         4.return        |");
            Console.WriteLine("---------------------------");
            Footer();

            try
            {
                bool KeepGoing = true;
                while (KeepGoing != false)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            PlayersTable();
                            break;
                        case ConsoleKey.D2:
                            ScoreTable();
                            break;
                        case ConsoleKey.D3:
                            LevelTable();
                            break;
                        case ConsoleKey.D4:
                            KeepGoing = false;
                            Menu();
                            break;
                        default:
                            break;
                    }
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void PlayersTable()
        {
            Console.Clear();
            Header();
            Console.WriteLine("---------------------------");
            Console.WriteLine("|         Players         |");
            Console.WriteLine("|         1.All           |");
            Console.WriteLine("|         2.Add/show      |");
            Console.WriteLine("|         3.Update        |");
            Console.WriteLine("|         4.Delete        |");
            Console.WriteLine("|         5.return        |");
            Console.WriteLine("---------------------------");
            Footer();

            try
            {
                bool KeepGoing = true;
                do
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            foreach (Player player in PlayerController.GetAllPlayers().OrderBy(p => p.Name))
                            {
                                Console.WriteLine($"Name: {player.Name}, LevelsCompleted: {player.Scores.Count()}");
                            }
                            break;
                        case ConsoleKey.D2:
                            Console.Write("Enter the Name of the Player: ");
                            string playerName = Console.ReadLine();
                            PlayerController.AddOrShowPlayer(playerName);
                            break;
                        case ConsoleKey.D3:
                            Console.Write("Enter the Name of the Player: ");
                            string name = Console.ReadLine();
                            Console.Write("please enter the score: ");
                            int score = int.Parse(Console.ReadLine());
                            Console.Write("and the level: ");
                            string level = Console.ReadLine();
                            ScoreController.AddOrUpdateScoreByPlayerNameandlevelname(score, name, level);
                            break;
                        case ConsoleKey.D4:
                            Console.Write("Enter the Name of the Player: ");
                            string Name = Console.ReadLine();
                            PlayerController.DeletePlayerByName(Name);
                            break;
                        case ConsoleKey.D5:
                            KeepGoing = false;
                            Menu();
                            break;
                        default:
                            break;
                    }
                } while (KeepGoing != false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void ScoreTable()
        {
            Console.Clear();
            Header();
            Console.WriteLine("---------------------------");
            Console.WriteLine("|         Scores          |");
            Console.WriteLine("|         1.All           |");
            Console.WriteLine("|         2.Add/show      |");
            Console.WriteLine("|         3.Update        |");
            Console.WriteLine("|         4.Delete        |");
            Console.WriteLine("|         5.return        |");
            Console.WriteLine("---------------------------");
            Footer();

            try
            {
                bool KeepGoing = true;
                do
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            var scores = ScoreController.GetAllScores().OrderBy(s => s.Points);
                            foreach (Score score in scores)
                            {
                                Console.WriteLine($"{score.Points}, {score.Level.Name}, {score.Player.Name}");
                            }
                            break;
                        case ConsoleKey.D2:
                            var allLevels = LevelController.GetAllLevels().ToList();
                            foreach (var levelid in allLevels)
                            {
                                if (levelid.Scores.Count > 0)
                                {
                                    Console.WriteLine($"Level: {levelid.Name}, Highscore: {levelid.Scores.Min().Points}");
                                }                          
                            }
                            Console.Write("Enter new score for player to be added: ");
                            int points = int.Parse(Console.ReadLine());
                            Console.Write("and Enter players name to be added: ");
                            string player = Console.ReadLine();
                            Console.Write("and Enter the level to be added: ");
                            string level = Console.ReadLine();
                            ScoreController.AddOrUpdateScoreByPlayerNameandlevelname(points, player, level);
                            break;
                        case ConsoleKey.D3:
                            Console.Write("Enter score for player to Update: ");
                            int points1 = int.Parse(Console.ReadLine());
                            Console.Write("and Enter players name to Update: ");
                            string player1 = Console.ReadLine();
                            Console.Write("and Enter the level to Update: ");
                            string level1 = Console.ReadLine();
                            ScoreController.AddOrUpdateScoreByPlayerNameandlevelname(points1, player1, level1);
                            break;
                        case ConsoleKey.D4:
                            Console.Write("Enter player name to delete score: ");
                            string player2 = Console.ReadLine();
                            Console.Write("and Enter score By level to delete: ");
                            string level2 = Console.ReadLine();
                            ScoreController.DeleteScoreByLevelNameAndPlayerName(player2, level2);
                            break;
                        case ConsoleKey.D5:
                            KeepGoing = false;
                            Menu();
                            break;
                        default:
                            break;
                    } 
                } while (KeepGoing != false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void LevelTable()
        {
            Console.Clear();
            Header();           
            Console.WriteLine("---------------------------");
            Console.WriteLine("|         Levels          |");
            Console.WriteLine("|         1.All           |");
            Console.WriteLine("|         2.Add/show      |");
            Console.WriteLine("|         3.Update        |");
            Console.WriteLine("|         4.Delete        |");
            Console.WriteLine("|         5.return        |");
            Console.WriteLine("---------------------------");
            Footer();
            try
            {
                bool KeepGoing = true;
                do
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            foreach (Level lev in LevelController.GetAllLevels().OrderBy(s => s.Id))
                            {
                                if (lev.Scores.Count > 0)
                                {
                                    Console.WriteLine($"{lev.Name}, Birds: {lev.Birds}, highestscore: {lev.Scores.Min().Points}, {lev.Scores.Min().Player.Name}");
                                }
                                else
                                {
                                    Console.WriteLine($"{lev.Name}, Birds: {lev.Birds}, No Highscores!");
                                }
                                
                            }
                            break;
                        case ConsoleKey.D2:
                            Console.Write("Enter level name to add/show: ");
                            string levelName = Console.ReadLine();
                            Console.Write("and enter the amount of birds: ");
                            int birds = int.Parse(Console.ReadLine());
                            LevelController.AddOrUpdateLevel(levelName, birds);
                            break;
                        case ConsoleKey.D3:
                            Console.Write("Enter level name to Update: ");
                            string levelName1 = Console.ReadLine();
                            Console.Write("and enter the amount of birds: ");
                            int birds1 = int.Parse(Console.ReadLine());
                            LevelController.AddOrUpdateLevel(levelName1, birds1);
                            break;
                        case ConsoleKey.D4:
                            Console.Write("Enter level name to delete: ");
                            string Name = Console.ReadLine();
                            var levels = LevelController.DeleteLevelByName(Name);
                            break;
                        case ConsoleKey.D5:
                            KeepGoing = false;
                            Menu();
                            break;
                        default:
                            break;
                    }
                } while (KeepGoing != false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
