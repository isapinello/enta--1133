using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanExplorer
{
    public abstract class Room
    {
        public string Name { get; }
        public string Description { get; }
        public Dictionary<Direction, Room> Exits { get; }
        public string Art { get; } // ASCII art as a string

        public Room(string name, string description, string art)
        {
            Name = name;
            Description = description;
            Exits = new Dictionary<Direction, Room>();
            Art = art; // Assign the ASCII art to the room
        }

        public void AddExit(Direction direction, Room room)
        {
            Exits[direction] = room;
        }

        public string GetAvailableExits()
        {
            var directionNames = new List<string>();
            foreach (var exit in Exits.Keys)
            {
                directionNames.Add(exit.ToString().ToLower());
            }
            return string.Join(", ", directionNames);
        }
    }

    public class BasicRoom : Room
    {
        public BasicRoom(string name, string description, string art) : base(name, description, art)
        {
        }
    }
}
