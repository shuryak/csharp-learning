using System;

namespace Structs
{
    class Program
    {
        static void Main(string[] args)
        {
            Player Mike;

            Mike.Nickname = "Mike171293";
            Mike.Level = 5;
            Mike.Xp = 5067;

            Console.WriteLine("Information about {0}:", Mike.Nickname);
            Console.WriteLine("Level: {0}.", Mike.Level);
            Console.WriteLine("XP: {0}.", Mike.Xp);

            Console.WriteLine("----------");

            Player Harry = new Player("HarryGedon1", 8);

            Console.WriteLine("Information about {0}:", Harry.Nickname);
            Console.WriteLine("Level: {0}.", Harry.Level);
            Console.WriteLine("XP: {0}.", Harry.Xp);

            Console.WriteLine("----------");

            Player Paul = new Player("PaulX10", 4);

            Paul.DisplayInfo();

            Console.ReadLine();
        }
    }

    struct Player
    {
        public Player(string nickname, int level)
        {
            Nickname = nickname;
            Level = level;
            Xp = level * 1000;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Information about {0}: Level {1}, {2} XP.", Nickname, Level, Xp);
        }

        public string Nickname;
        public int Level;
        public int Xp;
    }
}