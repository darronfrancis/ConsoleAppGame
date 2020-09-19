using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public class Room
    {
        public string Name { get; }
        public string Description { get; }
        public List<int> Exits { get; }
        public string ExitDescription { get; }
        public List<ProgramUI.Item> Items { get; }
        
        public Room(string name, string description, List<int> exits, string exitDescription, List<ProgramUI.Item> items)
        {
            Name = name;
            Description = description;
            Exits = exits;
            ExitDescription = exitDescription;
            Items = items;
        }

        public void RemoveItem(ProgramUI.Item item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
        }
    }
}
