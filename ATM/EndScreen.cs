using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnotherStrangerMe
{
    class EndScreen
    {
        static StreamReader endScreen;
        int sleepTime;
        public EndScreen(Player player)
        {
            player = null;

            endScreen = new StreamReader("gameOver.txt", Encoding.UTF8);

            Console.Clear();

            string draw = endScreen.ReadToEnd();
            for (int i = 0; i < 25; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                sleepTime += 10;
                Console.Clear();
                System.Threading.Thread.Sleep(sleepTime);
                Console.SetCursorPosition(0, 3);
                Console.WriteLine(draw);
                System.Threading.Thread.Sleep(sleepTime);
            }
            System.Threading.Thread.Sleep(3000);
            Utility.StartGame();
        }
    }
}
