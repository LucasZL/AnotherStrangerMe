using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;


namespace AnotherStrangerMe
{
    class Intro
    {
        StreamReader intro = new StreamReader("Intro.txt", Encoding.UTF8);
        StreamReader controls = new StreamReader("controls.txt", Encoding.UTF8);

        public void DrawText()
        {
            string line = intro.ReadToEnd();
            Console.WriteLine(line);
            ChooseNumber();
        }

        private void ChooseNumber()
        {
            ConsoleKeyInfo key;
            Console.SetCursorPosition(21, 18);
            key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.SetCursorPosition(45, 18);
                Content.TypeWriter("Chicago, 27.Juli 1928");
                Console.SetCursorPosition(50, 19);
                Content.TypeWriter("10:28 Uhr");
                Thread.Sleep(900);
                Console.Clear();
                Player player = new Player();
                Layout layout = new Layout();
                layout.DrawLayout();
                player.Input();
            }

            else if (key.Key == ConsoleKey.D2)
            {
                Console.Clear();
                string line = controls.ReadToEnd();
                Console.WriteLine(line);
                key = Console.ReadKey();
                

                if (key.Key == ConsoleKey.S)
                {
                    Console.Clear();
                    Console.SetCursorPosition(45, 18);
                    Content.TypeWriter("Chicago, 27.Juli 1928");
                    Console.SetCursorPosition(50, 19);
                    Content.TypeWriter("10:28 Uhr");
                    Thread.Sleep(900);
                    Console.Clear();
                    Player player = new Player();
                    Layout layout = new Layout();
                    layout.DrawLayout();
                    player.Input();
                }
                else if (key.Key == ConsoleKey.M || key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    StreamReader menue = new StreamReader("menue.txt");
                    string menueline = menue.ReadToEnd();
                    Console.WriteLine(menueline);
                    ChooseNumber();
                }
            }
            else if (key.Key == ConsoleKey.D3)
            {
                Console.Clear();
                Console.WriteLine("Dieses Textadventure wurde von Nico Engelhardt, Lucas Zacharias und Kevin Holst erdacht und entwickelt");
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Drücke die Enter oder die M-Taste um zum Menü zurückzukehren oder drücke 'S' um das Spiel zu Starten");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.S)
                {
                    Console.Clear();
                    Console.SetCursorPosition(45, 18);
                    Content.TypeWriter("Chicago, 27.Juli 1928");
                    Console.SetCursorPosition(50, 19);
                    Content.TypeWriter("10:28 Uhr");
                    Thread.Sleep(900);
                    Console.Clear();
                    Player player = new Player();
                    Layout layout = new Layout();
                    layout.DrawLayout();
                    player.Input();
                }
                else if (key.Key == ConsoleKey.M || key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    StreamReader menue = new StreamReader("menue.txt");
                    string menueline = menue.ReadToEnd();
                    Console.WriteLine(menueline);
                    ChooseNumber();
                }
            }
            else if (key.Key == ConsoleKey.D4)
            {
                Environment.Exit(0);
            }
            Console.ReadLine();
        }
        
    }
}
