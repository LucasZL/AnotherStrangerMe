using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnotherStrangerMe
{
    class RoomContent
    {
        public static string[] roomArrayCommands;
        public static string[] roomDescription;
        public static string[] shortDescriptionArray;
        static StreamReader arrayReader;
        static StreamReader description;
        static StreamReader shortdescription;
        private static List<Room> roomList;

        public RoomContent()
        {
            roomList = new List<Room>();
            arrayReader = new StreamReader("objectList.txt");
            description = new StreamReader("roomDescription.txt");
            shortdescription = new StreamReader("shortRoomDescription.txt");
            roomArrayCommands = arrayReader.ReadToEnd().Split(new Char[] { '|' });
            roomDescription = description.ReadToEnd().Split(new Char[] { '|' });
            shortDescriptionArray = shortdescription.ReadToEnd().Split(new Char[] { '|' });
        }

        public Room Room1()
        {
            addRoomsToList();
            return roomList[0];
        }

        public void addRoomsToList()
        {
            for (int i = 0; i < roomArrayCommands.Length; i++)
            {
                roomList.Add(new Room(roomArrayCommands[i].Split(new Char[] { ',' }), roomDescription[i],shortDescriptionArray[i]));
            }
        }
        

        public static void NextRoom(int roomNumber, Room currentRoom, Player player)
        {
            player.room = null;
            player.room = roomList[roomNumber];
        }

        

    }
}