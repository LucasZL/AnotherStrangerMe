using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnotherStrangerMe
{
    class WinScreen
    {
        static StreamReader winScreen;

        public WinScreen (Player player)
	    {
            winScreen = new StreamReader("gameOver.txt", Encoding.UTF8);
            Console.Clear();

            string draw = winScreen.ReadToEnd();
            Console.ForegroundColor = ConsoleColor.Green;
            System.Threading.Thread.Sleep(3000);
            Utility.StartGame();
	    }
    }
}
