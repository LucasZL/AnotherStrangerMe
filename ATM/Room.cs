using System;
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
        public Room()
        {

        }
        
        public Room(string[] RoomObjects, string description, string shortDescritpion)
        {
            this.RoomObjects = RoomObjects;
            this.description = description;
            this.shortDescritpion = shortDescritpion;
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
                player.WriteAnswer(descriptionArray[iCounter]);
                iCounter++;
            }
        }

        public void SideDescription()
        {
            int iCounter = 9;
            shortDescriptionArray = shortDescritpion.Split(',');
            foreach (var shortDes in shortDescriptionArray)
            {
                for (int i = 0; i < shortDes.Length; i++)
                {
                    Console.SetCursorPosition(81, iCounter);
                    Console.WriteLine("- "+ Player.FirstUpper(shortDes));
                    Thread.Sleep(100);
                }
                iCounter++;
            }
        }

        
        public void Kill(string victim)
        {

        }

 
        public bool proofInput(string kind, string item)
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
    }
}
