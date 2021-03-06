﻿using System;
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
        public int roomNumber = 1;
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
            roomContent = new RoomContent(this);
            room = roomContent.Room1();
            Inventory = new List<string>();
            name = "Luigi";
            lastInputs = new string[18];
            commandArray = new string[] { "gehe", "töte", "nehme", "untersuche", "umschauen", "benutze" };
            weaponArray = new string[] { "messer", "waffe", "frau", "pistole" };
        }



        public void Input()
        {
            Utility.CheckGuard(this);
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
                        RoomContent.NextRoom(roomNumber, room);
                        Utility.WriteAnswer("Du bist in den nächsten Raum gegangen", this);
                        
                    }
                    else
                    {
                        Utility.WriteAnswer("Du bist zum / zur " + words[iCount] + " gegangen", this);
                    }
                }
                else
                {
                    Utility.FalseInput(words[iCount],  " wurde nicht gefunden", this);
                }
            } 
            //töte
            else if (input == commandArray[1])
            {
                bool specialCase = false;
                bool foundItem = false;
                int iCount = 0;

                for (int i = 1; i < words.Length; i++)
                {
                    foundItem = room.proofInput("2", words[i],room.RoomObjects);
                    iCount++;
                }
                
                specialCase = Utility.proofSpecialInput(words[iCount]);

                if (specialCase)
                {
                    Utility.WriteAnswer("Mit was möchtest du " + words[iCount] + " töten?", this);
                    Utility.ClearInputAndWaitForNextInput();
                    string weapon = Console.ReadLine();
                    foreach (var item in Inventory)
                    {
                        if (item.ToLower() == weapon)
                        {
                            foreach (var weapons in weaponArray)
                            {
                                if (weapons == weapon && specialCase)
                                {
                                    //Utility.WriteAnswer("Du hast " + words[iCount] + " mit " + weapon + " getötet, bist du stolz auf dich?", this);
                                    Utility.ConfirmKill(words[iCount], this);
                                    room.deleteArrayEntry(room.RoomObjects, words[iCount]);
                                }
                            }
                        }
                        else
                        {
                            Utility.FalseInput(weapon, "wurde im Inventar nicht gefunden!", this);
                        }
                    }
                }
                else
                {
                    Utility.FalseInput(words[iCount], "konnte nicht angegriffen werden!", this);
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
                    Inventory.Add(Utility.FirstUpper(words[inventoryNumber]));
                    Utility.RightInput(Utility.FirstUpper(words[inventoryNumber]), "wurde dem Inventar hinzugefügt!", this);
                    Utility.SwitchItemInArray(room.RoomObjects, words[inventoryNumber], "lksrughxkdlsujhg");
                    foreach (var entry in room.shortDescriptionArray)
                    {
                        entryCounter++;
                        if (entry == words[inventoryNumber])
                        {
                            room.shortDescriptionArray[entryCounter-1] = "";
                            //room.SideDescription();
                        }
                    }
                }
                else
                {
                    Utility.FalseInput(Utility.FirstUpper(words[inventoryNumber]), "konnte dem Inventar nicht hinzugefügt werden!", this);
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
                        string[] output = examin.Split(new Char[] { ']' });
                        foreach (var item in output)
                        {
                            Utility.WriteAnswer(item, this);
                        }
                    }
                    else
                    {
                        Utility.WriteAnswer("Sieht normal aus", this);
                    }
                }
            }
            //umgucken
            else if (input == commandArray[4])
            {
                Utility.WriteAnswer("Du siehst dich in dem Raum um:", this);
                room.WriteDescritipon(this);
                room.SideDescription();
            }
            //benutzen
            else if (input == commandArray[5])
            {
                if (RoomContent.getRoomNumber(room.roomName) == 5 && words[1] == "Bier");
                {
                    Utility.TakeBeer(this);
                }
                bool isWeaponInInventory = false;
                int iCount = 0;
                 Utility.ClearInputAndWaitForNextInput();
                        foreach (var item in Inventory)
                        {
                            if (item.ToLower() == words[iCount+1])
                            {
                                isWeaponInInventory = true;
                                Utility.WriteAnswer(string.Format("Wen möchtest du mit {0} töten?", Utility.FirstUpper(words[iCount+1])), this);
                                Utility.kill(room,words,this);
                            }
                            else
                            {
                                isWeaponInInventory = false;
                            }
                        }
                    
                    if (!isWeaponInInventory)
                    {
                        Utility.FalseInput(Utility.FirstUpper(words[iCount]), "wurde im Inventar nicht gefunden", this);
                    }
            }
            else
            {
                if (words[0] != "")
                {
                    Utility.FalseInput(words[0], "konnte nicht ausgeführt werden!", this);
                }
                else
                {
                    Utility.FalseInput("Kein Befehl eingegeben!", "", this);
                }
            }
            Utility.ClearInput(this);
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

        
    }
}