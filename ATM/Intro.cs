using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace AnotherStrangerMe
{
    class Intro
    {
        StreamReader intro = new StreamReader("Intro.txt");
        StreamReader controls = new StreamReader("controls.txt");

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
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();
                Player player = new Player();
                Layout layout = new Layout();
                layout.DrawLayout();
                player.Input();
            }

            else if (input == "2")
            {
                Console.Clear();
                string line = controls.ReadToEnd();
                Console.WriteLine(line);
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.S)
                {
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
            else if (input == "3")
            {
                Console.Clear();
                Console.WriteLine("Dieses Textadventure wurde von Nico Engelhardt, Lucas Zacharias und Kevin Holst erdacht und entwickelt");
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Drücke die Enter oder die M-Taste um zum Menü zurückzukehren oder drücke 'S' um das Spiel zu Starten");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.S)
                {
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
            else if (input == "4")
            {
                Environment.Exit(0);
            }
            Console.ReadLine();
        }
        
    }
}
