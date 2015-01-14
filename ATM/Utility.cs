using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AnotherStrangerMe
{
    static class Utility
    {
        static bool luigiOneDead = false;
        static bool luigiTwoDead = false;
        static bool guardDead = false;
        static bool receptionistDead = false;

        static string[] specialCases = { "luigi", "wachmann", "rezeptionist"};

        public static string FirstUpper(string upper)
        {
            if (String.IsNullOrEmpty(upper))
            {
                return "";
            }
            return upper.First().ToString().ToUpper() + upper.Substring(1);
        }

        public static void ClearInput(Player player)
        {
            Console.SetCursorPosition(0, 31);
            Console.WriteLine("|                                                                                                       |");
            player.Input();
        }

        public static void WriteAnswer(string answer, Player player)
        {
            ClearTopLane(player);
            Console.SetCursorPosition(1, player.inputY);
            Console.WriteLine(answer);
        }

        public static void FalseInput(string falseWord, string reason, Player player)
        {
            ClearTopLane(player);
            Console.SetCursorPosition(1, player.inputY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Utility.FirstUpper(falseWord));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" " + reason);
        }

        public static void RightInput(string rightWord, string reason, Player player)
        {
            ClearTopLane(player);
            Console.SetCursorPosition(1, player.inputY);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(Utility.FirstUpper(rightWord));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" " + reason);
        }

        public static void ClearInputAndWaitForNextInput()
        {
            Console.SetCursorPosition(0, 31);
            Console.WriteLine("|                                                                                                       |");
            Console.SetCursorPosition(1, 31);
        }

        public static void ClearTopLane(Player player)
        {
            Console.MoveBufferArea(1, 10, 79, 19, 1, 9);
            Console.SetCursorPosition(0, player.inputY);
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("|_______________________________|_______________________________________________|_______________________|");
        }

        public static void SwitchItemInArray(string[] array, string originalData, string newData)
        {
            int iCounter = 0;
            foreach (var testString in array)
            {
                if (testString == originalData)
                {
                    array[iCounter] = newData;
                    break;
                }
                iCounter++;
            }
        }

        public static void TypeWriter(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(200);
            }
        }

        public static void kill(Room room,string[] words,Player player)
        {
            
            bool foundVictim = false;
            int iCount = 0;
            Utility.ClearInputAndWaitForNextInput();
            string victim = Console.ReadLine();

            foundVictim = room.proofInput("2", victim, room.RoomObjects);

            if (foundVictim)
            {
                Utility.WriteAnswer("Du hast " + victim + " mit " + words[iCount + 1] + " getötet, bist du stolz auf dich?", player);
                room.deleteArrayEntry(room.RoomObjects, words[iCount + 1]);
            }
        } 

        public static bool proofSpecialInput(string input)
        {
            foreach (var item in specialCases)
	        {
                if (item == input)
	            {
                    return true; 
	            }
	        }
            return false;
        }

        public static void ConfirmKill(string victim, Player player)
        {
            if (player.roomNumber == 9)
            {
                if (victim == "luigi")
                {
                    bool luigiTwoDead = true;
                    WinScreen luigi = new WinScreen(player);
                }
            }
            else 
            {
                if (victim == "luigi")
                {
                    bool luigiOneDead = true;
                    EndScreen luigi = new EndScreen(player);
                }
                else if (victim == "wachmann")
                {
                    bool guardDead = true;

                }
                else if (victim == "rezeptionist")
                {
                    bool receptionistDead = true;
                } 
            }
        }

        public static void StartGame()
        {
            Console.SetWindowSize(110, 37);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();


            Intro intro = new Intro();
            intro.DrawText();

            Console.ReadLine();
        }
    }
}
