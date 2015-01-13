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
        public int inputY = 28;
        public string[] commandArray;
        public string[] weaponArray;
        public string name;
        string[] words;
        public List<string> Inventory;
        public int iCounter = 0;
        string[] lastInputs;
        

        public Player()
        {
            roomContent = new RoomContent();
            room = roomContent.Room1();
            Inventory = new List<string>();
            name = "Luigi";
            lastInputs = new string[18];
            commandArray = new string[] { "gehe", "töte", "nehme", "untersuche", "umschauen", "benutze" };
            weaponArray = new string[] { "messer", "schrotflinte", "frau", "pistole" };
        }



        public void Input()
        {

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
                    objectFound = room.proofInput("5", words[i], room.RoomObjects);
                    iCount++;
                }
                if (objectFound)
                {
                    if(words[iCount] == "tuer")
                    {
                        Content.WriteAnswer("Du bist in den nächsten Raum gegangen", this);
                        RoomContent.NextRoom(roomNumber, room, this);
                        roomNumber++;
                    }
                    else
                    {
                        Content.WriteAnswer("Du bist zum / zur " + words[iCount] + " gegangen", this);
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
                    foundItem = room.proofInput("2", words[i],room.RoomObjects);
                    iCount++;
                }
                if (foundItem)
                {
                    Content.WriteAnswer("Mit was möchtest du " + words[iCount] + " töten?", this);
                    Content.ClearInputAndWaitForNextInput();
                    string weapon = Console.ReadLine();
                    foreach (var item in Inventory)
                    {
                        if (item.ToLower() == weapon)
                        {
                            foreach (var weapons in weaponArray)
                            {
                                if (weapons == weapon)
                                {
                                    Content.WriteAnswer("Du hast " + words[iCount] + " mit " + weapon + " getötet, bist du stolz auf dich?", this);
                                    room.deleteArrayEntry(room.RoomObjects, words[iCount]);
                                }
                            }
                        }
                        else
                        {
                            Content.FalseInput(weapon, "wurde im Inventar nicht gefunden!", this);
                        }
                    }
                }
                else
                {
                    Content.FalseInput(words[iCount], "konnte nicht angegriffen werden!", this);
                }
            } 
            //nehme
            else if (input == commandArray[2])
            {
                inventoryNumber = 0;
                bool foundItem = false;
                for (int i = 1; i < words.Length; i++)
                {
                    foundItem = room.proofInput("3", words[i],room.RoomObjects);
                    inventoryNumber++;
                }
                if (foundItem)
                {
                    int entryCounter = 0;
                    Inventory.Add(Content.FirstUpper(words[inventoryNumber]));
                    Content.RightInput(Content.FirstUpper(words[inventoryNumber]), "wurde dem Inventar hinzugefügt!", this);
                    Content.SwitchItemInArray(room.RoomObjects, words[inventoryNumber], "lksrughxkdlsujhg");
                    foreach (var entry in room.shortDescriptionArray)
                    {
                        entryCounter++;
                        if (entry == words[inventoryNumber])
                        {
                            room.shortDescriptionArray[entryCounter-1] = "";
                            room.SideDescription();
                        }
                    }
                }
                else
                {
                    Content.FalseInput(Content.FirstUpper(words[inventoryNumber]), "konnte dem Inventar nicht hinzugefügt werden!", this);
                }
                UpdateInventory();
            } 
            //untersuche
            else if (input == commandArray[3])
            {
                bool objectFound = false;

                int iCount = 0;

                for (int i = 1; i < words.Length; i++)
                {
                    objectFound = room.proofInput("4",words[i],room.RoomObjects);
                    iCount++;

                    if (objectFound)
                    {
                        string examin = room.returnExamintext(words[iCount], RoomContent.examinarray, this);

                        Content.WriteAnswer(examin, this);
                    }
                    else
                    {
                        Content.WriteAnswer("Sieht normal aus", this);
                    }
                }
            }
            //umgucken
            else if (input == commandArray[4])
            {
                Content.WriteAnswer("Du siehst dich in dem Raum um:", this);
                room.WriteDescritipon(this);
                room.SideDescription();
            }
            //benutzen
            else if (input == commandArray[5])
            {
                bool isWeaponInInventory = false;
                bool foundItem = false;
                int iCount = 0;
                for (int i = 1; i < words.Length; i++)
                {
                    foundItem = room.proofInput("1", words[i], room.RoomObjects);
                    iCount++;

                    if (words[i].ToLower() == "spiegel")
                    {

                    }
                    if (foundItem)
                    {
                        Content.ClearInputAndWaitForNextInput();
                        foreach (var item in Inventory)
                        {
                            if (item.ToLower() == words[iCount])
                            {
                                isWeaponInInventory = true;
                                Content.WriteAnswer(string.Format("Wen möchtest du mit {0} töten?", Content.FirstUpper(words[iCount])), this);
                                kill();
                            }
                            else
                            {
                                isWeaponInInventory = false;
                            }
                        }
                    }
                    if (!isWeaponInInventory)
                    {
                        Content.FalseInput(Content.FirstUpper(words[iCount]), "wurde im Inventar nicht gefunden", this);
                    }

                }
            }
            else
            {
                if (words[0] != "")
                {
                    Content.FalseInput(words[0], "konnte nicht ausgeführt werden!", this);
                }
                else
                {
                    Content.FalseInput("Kein Befehl eingegeben!", "", this);
                }
            }
            Content.ClearInput(this);
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

        public void kill()
        {
            bool foundVictim = false;
            int iCount = 0;
            Content.ClearInputAndWaitForNextInput();
            string victim = Console.ReadLine();

            foundVictim = room.proofInput("2", victim, room.RoomObjects);

            if (foundVictim)
            {
                Content.WriteAnswer("Du hast " + victim + " mit " + words[iCount+1] + " getötet, bist du stolz auf dich?", this);
                room.deleteArrayEntry(room.RoomObjects, words[iCount+1]);
            }
        } 
    }
}