using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AnotherStrangerMe
{
    static class Content
    {
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
            Console.Write(Content.FirstUpper(falseWord));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" " + reason);
        }

        public static void RightInput(string rightWord, string reason, Player player)
        {
            ClearTopLane(player);
            Console.SetCursorPosition(1, player.inputY);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(Content.FirstUpper(rightWord));
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
    }
}
