using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AngryBirds
{
    public class View
    {
        public void Start()
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

        public void Menu()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("|        StartMenu        |");
            Console.WriteLine("|     1. Search Players   |");
            Console.WriteLine("|      2. PrintTables     |");
            Console.WriteLine("|         3. Quit         |");
            Console.WriteLine("---------------------------");
        }

        public void Name()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("|         Names           |");
            Console.WriteLine("|         1.scores        |");
            Console.WriteLine("---------------------------");
        }

        public void Tables()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("|         Tables          |");
            Console.WriteLine("|         1.All           |");
            Console.WriteLine("|         2.players       |");
            Console.WriteLine("|         2.Scores        |");
            Console.WriteLine("---------------------------");
        }

        public void LevelTable()
        {
            Console.WriteLine("---------------------------");

            Console.WriteLine("---------------------------");
        }
    }
}
