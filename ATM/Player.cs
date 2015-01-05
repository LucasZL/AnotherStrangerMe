using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnotherStrangerMe;

namespace AnotherStrangerMe
{
    class Player
    {
        RoomContent roomContent;
        public Room room;
        int roomNumber = 1;
        public int inventoryNumber;
        public int inputY = 9;
        public string[] commandArray;
        public string[] weaponArray;
        public string name;
        string[] words;
        public List<string> Inventory;
        

        public Player()
        {
            roomContent = new RoomContent();
            room = roomContent.Room1();
            Inventory = new List<string>();
            name = "Luigi";
            commandArray = new string[] { "gehe", "töte", "nehme", "untersuche", "umschauen", "benutze" };
            weaponArray = new string[] { "messer", "schrotflinte", "frau", "pistole" };
        }



        public void Input()
        {
            ClearTopLane();

            Console.SetCursorPosition(1, 31);
            string read = Console.ReadLine().ToLower();

            words = read.Split(' ');
            string input = words[0];
            
            //gehe
            if (input == commandArray[0])
            {
                bool objectFound = false;
                int iCount = 1;
                for (int i = 2; i < words.Length; i++)
                {
                    objectFound = room.proofInput("5", words[i]);
                    iCount++;
                }
                if (objectFound)
                {
                    if(words[iCount] == "tuer")
                    {
                        WriteAnswer("Du bist in den nächsten Raum gegangen");
                        RoomContent.NextRoom(roomNumber, room, this);
                        roomNumber++;
                    }
                    else
                    {
                        WriteAnswer("Du bist zum / zur " + words[iCount] + " gegangen");
                    }
                }
                else
                {
                    Console.WriteLine(words[iCount] + " wurde nicht gefunden");
                }
            } 
            //töte
            else if (input == commandArray[1])
            {
                bool foundItem = false;
                int iCount = 0;
                for (int i = 1; i < words.Length; i++)
                {
                    foundItem = room.proofInput("2", words[i]);
                    iCount++;
                }
                if (foundItem)
                {
                    WriteAnswer("Mit was möchtest du " + words[iCount] + " töten");
                    ClearInputAndWaitForNextInput();
                    string weapon = Console.ReadLine();
                    foreach (var item in Inventory)
                    {
                        if (item.ToLower() == weapon)
                        {
                            foreach (var weapons in weaponArray)
                            {
                                if (weapons == weapon)
                                {
                                    WriteAnswer("Du hast " + words[iCount] + " mit " + weapon + " getötet, bist du stolz auf dich?");
                                    words[iCount] = "hsgsrgowsihosifskgjoisjgfsij";
                                }
                            }
                        }
                        else
                        {
                            FalseInput(weapon, "wurde im Inventar nicht gefunden!");
                        }
                    }
                }
                else
                {
                    FalseInput(words[iCount], "konnte nicht angegriffen werden!");
                }
            } 
            //nehme
            else if (input == commandArray[2])
            {
                inventoryNumber = 0;
                bool foundItem = false;
                for (int i = 1; i < words.Length; i++)
                {
                    foundItem = room.proofInput("3", words[i]);
                    inventoryNumber++;
                }
                if (foundItem)
                {
                    Inventory.Add(FirstUpper(words[inventoryNumber]));
                    RightInput(FirstUpper(words[inventoryNumber]), "wurde dem Inventar hinzugefügt!");
                    SwitchItemInArray(room.RoomObjects, words[inventoryNumber], "lksrughxkdlsujhg");
                }
                else
                {
                    FalseInput(FirstUpper(words[inventoryNumber]), "konnte dem Inventar nicht hinzugefügt werden!");
                }
                UpdateInventory();
            } 
            //untersuche
            else if (input == commandArray[3])
            {
                for (int i = 1; i < words.Length; i++)
                {
                    room.proofInput("4", words[i]);
                }
            } 
            //umgucken
            else if (input == commandArray[4])
            {
                WriteAnswer("Du siehst dich in dem Raum um:");
                room.WriteDescritipon(this);
                room.SideDescription();
            } 
            //benutzen
            else if (input == commandArray[5])
            {
                int iCount = 0;
                for (int i = 1; i < words.Length; i++)
                {
                    room.proofInput("1", words[i]);
                    iCount++;
                }
            }
            else 
            {
                FalseInput(words[0], "konnte nicht ausgeführt werden!");
            }
            ClearInput();
        }
        public static string FirstUpper(string upper)
        {
            if (String.IsNullOrEmpty(upper))
            {
                return "";
            }
            return upper.First().ToString().ToUpper() + upper.Substring(1);
        }

        public void UpdateInventory()
        {
            int inventoryY = 2;
            foreach (var item in Inventory)
            {
                Console.SetCursorPosition(81, inventoryY);
                Console.WriteLine(item);
                inventoryY++;
            }
        }

        public void SwitchItemInArray(string[] array, string originalData, string newData)
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

        public void ClearInput()
        {
            Console.SetCursorPosition(0, 31);
            Console.WriteLine("|                                                                                                       |");
            Input();
        }

        public void WriteAnswer(string answer)
        {
            Console.SetCursorPosition(1, inputY);
            Console.WriteLine(answer);
            inputY++;
        }

        public void FalseInput(string falseWord, string reason)
        {
            Console.SetCursorPosition(1, inputY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(FirstUpper(falseWord));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" " + reason);
            inputY++;
        }

        public void RightInput(string rightWord, string reason)
        {
            Console.SetCursorPosition(1, inputY);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(FirstUpper(rightWord));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" " + reason);
            inputY++;
        }

        public void ClearInputAndWaitForNextInput()
        {
            Console.SetCursorPosition(0, 31);
            Console.WriteLine("|                                                                                                       |");
            Console.SetCursorPosition(1, 31);
        }

        public void ClearTopLane()
        {
            int top = Console.CursorTop;
            if (top > 12)
            {
                Console.SetCursorPosition(1, 9);
                Console.Write("                                                                               ");
                Console.MoveBufferArea(0, 10, 20, 10, 0, 11);
                inputY--;
            }
        }
    }
}
