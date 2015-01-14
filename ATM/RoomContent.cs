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
        public static string[] examinarray;
        public static string[] shortDescriptionArray;
        public static string[] roomNumber;
        public static string[] nextRooms;
        static StreamReader roomArrayReader;
        static StreamReader examinReader;
        static StreamReader descriptionReader;
        static StreamReader shortDescriptionReader;
        static StreamReader roomNumberReader;
        static StreamReader nextRoomReader;
        private static List<Room> roomList;
        static Player player;

        public RoomContent(Player player)
        {
            RoomContent.player = player;
            roomList = new List<Room>();
            examinReader = new StreamReader("examinList.txt", Encoding.UTF8);
            roomArrayReader = new StreamReader("objectList.txt", Encoding.UTF8);
            descriptionReader = new StreamReader("roomDescription.txt", Encoding.UTF8);
            shortDescriptionReader = new StreamReader("shortRoomDescription.txt", Encoding.UTF8);
            roomNumberReader = new StreamReader("roomNumbers.txt", Encoding.UTF8);
            nextRoomReader = new StreamReader("nextRooms.txt", Encoding.UTF8);
            roomArrayCommands = roomArrayReader.ReadToEnd().Split(new Char[] { '|' });
            roomDescription = descriptionReader.ReadToEnd().Split(new Char[] { '|' });
            shortDescriptionArray = shortDescriptionReader.ReadToEnd().Split(new Char[] { '|' });
            examinarray = examinReader.ReadToEnd().Split(new Char[] { '|' });
            roomNumber = roomNumberReader.ReadToEnd().Split(new Char[] { '|' });
            nextRooms = nextRoomReader.ReadToEnd().Split(new Char[] { '|' });
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
                
                roomList.Add(new Room(roomArrayCommands[i].Split(new Char[] { ',' }), roomDescription[i], shortDescriptionArray[i], roomNumber[i],nextRooms[i]));
            }
        }


        public static void NextRoom(int roomNumber, Room currentRoom)
        {
            if (currentRoom.nextRoomsArray.Count() > 1)
            {
                Utility.WriteAnswer("Wohin möchtest du gehen?", player);
                foreach (var room in currentRoom.nextRoomsArray)
                {
                    Utility.RightInput(room, "", player);
                }
                Utility.ClearInputAndWaitForNextInput();
                string input = Console.ReadLine();
                foreach (var room in currentRoom.nextRoomsArray)
                {
                    if (room.ToLower() == input)
                    {
                        prepareNextRoom(getRoomNumber(room));
                    }
                }
            }
            else if (currentRoom.nextRoomsArray.Count() == 1)
            {
                prepareNextRoom(roomNumber);
            }
            else
            {
                Utility.FalseInput("Kein Raum erreichbar!","", player);
            }
        }

        private static void prepareNextRoom(int roomNumber)
        {
            Console.MoveBufferArea(0, 35, 23, 7, 81, 9);
            player.room = null;
            player.room = roomList[roomNumber];
            player.roomNumber = roomNumber;
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("|Umschauen                      |						|                       |");
            writeRoomName();
        }

        public static void writeRoomName()
        {
            Console.SetCursorPosition(48, 7);
            Console.WriteLine("Raum: " + player.room.roomName);
        }

        private static int getRoomNumber(string roomName)
        {
            int iCounter = 0;
            foreach (var room in roomNumber)
            {
                if (room == roomName)
                {
                    return iCounter;
                }
                iCounter++;
            }
            return 0;
        }
    }
}