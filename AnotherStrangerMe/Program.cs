using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherStrangerMe
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.SetWindowSize(110,37);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();

            
            Intro intro = new Intro();
            intro.DrawText();

            Console.ReadLine();
        }
    }
}
