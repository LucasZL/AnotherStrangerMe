﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AnotherStrangerMe
{
    class Room 
    {

        public string[] RoomObjects;
        public string description;
        public string[] descriptionArray;
        public string shortDescritpion;
        public string[] shortDescriptionArray;
        public string roomName;
        public string[] nextRoomsArray;
        public Room()
        {

        }
        
        public Room(string[] RoomObjects, string description, string shortDescritpion, string roomName, string nextRooms)
        {
            this.RoomObjects = RoomObjects;
            this.description = description;
            this.shortDescritpion = shortDescritpion;
            this.roomName = roomName;
            shortDescriptionArray = shortDescritpion.Split(',');
            nextRoomsArray = nextRooms.Split(',');
        }
        public Room(string[] array)
        {

        }

        public void WriteDescritipon(Player player)
        {
            int iCounter = 0;
            descriptionArray = description.Split(']');
            foreach (var line in descriptionArray)
            {
                Utility.WriteAnswer(descriptionArray[iCounter], player);
                iCounter++;
            }
        }

        public void SideDescription()
        {
            Console.MoveBufferArea(0, 35, 23, 7, 81, 9);
            int iCounter = 9;
            foreach (var shortDes in shortDescriptionArray)
            {
                    if (shortDes != "")
                    {
                        Console.SetCursorPosition(81, iCounter);
                        Console.WriteLine("- " + Utility.FirstUpper(shortDes));
                        Thread.Sleep(100);
                    }
                    else
                    {
                        iCounter--;
                    }
                iCounter++;
            }
        }
 
        public bool proofInput(string kind, string item,string[] array)
        {
            int iCounter = 0;
            foreach (var kindOption in RoomObjects)
            {
                iCounter++;
                if (kind == kindOption)
                {
                    if (RoomObjects[iCounter] == item)
                        {
                            return true;
                        }
                }
            }
            return false;
        }

        public void deleteArrayEntry(string[] array, string a)
        {
            int iCount = 0;
		    foreach (var item in array)
	        {
                if (item == a)
                {
                    array[iCount] = "jhgsfsdjkfhgiudrghiodhg";
                }
                iCount++;
	        }	 
        }
        public string returnExamintext(string item, string[] array, Player player)
        {
            int iCounter = 0;
            foreach (var kindOption in array)
            {
                if (array[iCounter].ToLower() == item)
                {
                    Utility.WriteAnswer(string.Format("Du untersuchst {0} ",Utility.FirstUpper(item)), player);
                    return array[iCounter + 1];
                }
                iCounter++;
            }
            return array[iCounter];
        }
    }
}
