using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleGame.Room;

namespace ConsoleGame
{
    public class ProgramUI
    {
        // DICTIONARY
        public static Dictionary<string, string> treasure = new Dictionary<string, string>()
        {
            { "One", "small dagger" },
            { "Two", "gold coins" },
            { "Three", "large dagger" },
            { "Four", "small bag of gems" },
            { "Five", "long sword" },
            { "Six", "small bag of gems" },
        };

        public enum Item { smalldagger, largedagger, longsword, coins, gems };
        public List<Item> inventory = new List<Item>();

        // ROOM CREATION
        Room one = new Room("One", "Further ahead are two paths.  Both look equally treacherous.", new List<int> { 3, 5 }, "There are two exits in this room - northeast or northwest.",  new List<Item> { Item.smalldagger });
        Room two = new Room("Two", "Burning torches in iron sconces line the walls of this room, lighting it brilliantly. At the room's center lies \n" +
            "a squat stone altar, its top covered in black sludge. A channel in the altar funnels the sludge down its \n" +
            "side to the floor where it fills grooves in the floor that trace some kind of pattern or symbol around the \n" +
            "altar. Unfortunately, you can't tell what it is from your vantage point.", new List<int> { 3 }, "There is only one exit in this room - north.", new List<Item> { Item.coins });
        Room three = new Room("Three", "A crack in the ceiling above the middle of the north wall allows a trickle of water to flow down to the floor. \n" +
            "The water pools near the base of the wall, and a rivulet runs along the wall an out into the hall. The water \n" +
            "smells fresh.", new List<int> { 1, 2, 6 }, "There are three exits in this room - north, southeast, or southwest.", new List<Item> { Item.largedagger });
        Room four = new Room("Four", "The manacles set into the walls of this room give you the distinct impression that it was used as a prison \n" +
            "and torture chamber, although you can see no evidence of torture devices. One particularly large set of \n" +
            "manacles -- big enough for an ogre -- have been broken open.", new List<int> { 5 }, "There is only one exit in this room - north.", new List<Item> { Item.gems });
        Room five = new Room("Five", "Unlike the flagstone common throughout the dungeon, this room is walled and floored with black marble veined with \n" +
            "white. The ceiling is similarly marbled, but the thick pillars that hold it up are white. A brown stain drips \n" +
            "down one side of a nearby pillar.", new List<int> { 1, 4, 7 }, "There are three exits in this room - north, southeast, or southwest.", new List<Item> { Item.longsword });
        Room six = new Room("Six", "A liquid-filled pit extends to every wall of this chamber. The liquid lies about 10 feet below your feet \n" +
            "and is so murky that you can't see its bottom. The room smells sour. A rope bridge extends from your door to a \n" +
            "tapestry on the east wall.", new List<int> { 3 }, "There is one exit in this room - to the south from whence you came.  \n" +
            "But there's also the rope bridge.  What if you braved it? \n" +
            "Do you want to go on the rope bridge?", new List<Item> { });
        Room seven = new Room("Seven", "Tapestries decorate the walls of this room. Although they may once have been brilliant in hue, they now hang in \n" +
            "graying tatters. Despite the damage of time and neglect, you can perceive once-grand images of wizards' towers, \n" +
            "magical beasts, and symbols of spellcasting. The tapestry that is in the best condition bulges out weirdly, as \n" +
            "though someone stands behind it (an armless statue of a female human spellcaster).", new List<int> { 5 }, "There are two exits in this room - north or south.", new List<Item> { });

        public void Run()
        {
            Room currentRoom = one;
            Console.WriteLine("A wide fallen tree in a sinister wasteland marks the entrance to the Labyrinth of the Golden Scorpion. \n" +
                "Beyond the fallen tree lies a modest, dusty room. \n" +
                "Your torch allows you to see it's covered in roots, bones, and dead insects.  \n" +
                "What happened in this place?");

            bool gameActive = true;
            while (gameActive)
            {
                Console.WriteLine($"\n" +
                    $"********************************************************\n" +
                    $"You are in Room {currentRoom.Name}.\n" +
                    $"{currentRoom.Description}\n" +
                    $"{currentRoom.ExitDescription}\n" +
                    $"What would you like to do?  You can look around or go somewhere else.\n\n" +
                    $"********************************************************\n" +
                    $"***You can also type \"help\" for a list of directions.***\n" +
                    $"********************************************************\n");

            string command = Console.ReadLine().ToLower();
                Console.Clear();

                // MAP COMMAND
                if (command.Contains("map"))
                {
                    Console.WriteLine("Here's a map of your dungeon.\n" +
                        "\n" +
                        "          ********    ********\n" +
                        "          *Room 6*    *Room 7*\n" +
                        "          ********    ********\n" +
                        "            *              *\n" +
                        "            *              *\n" +
                        "       ********          ********\n" +
                        "       *Room 3*          *Room 5*\n" +
                        "       ********          ********\n" +
                        "        *     *          *     *\n" +
                        "       *       *        *       *\n" +
                        "********        ********        ********\n" +
                        "*Room 2*        *Room 1*        *Room 4*\n" +
                        "********        ********        ********\n" +
                        "");
                }

                // HELP COMMAND
                else if (command == "help")
                {
                    Console.WriteLine("*Type \"look around\" to look around a room to see if there is anything usable that you can collect.\n" +
                        "*Type \"go\" plus whatever direction is listed in the room info to go to a different room.\n" +
                        "  Example: \"go forward right\" or \"go straight ahead.\"\n" +
                        "*Type \"inventory\" to see a list of items you have collected.\n" +
                        "*Type \"map\" to see a map of the dungeon.");
                }

                // GO/EXIT COMMANDS
                else if (command.StartsWith("go ") || command.StartsWith("exit "))
                {
                    switch (currentRoom.Name)
                    {
                        case "One":
                            if (command.Contains("northwest") || command.Contains("north west") || command.Contains("nw")) { currentRoom = three; };
                            if (command.Contains("northeast") || command.Contains("north east") || command.Contains("ne")) { currentRoom = five; };
                            break;
                        case "Two":
                            if (command.Contains("north")) { currentRoom = three; };
                            break;
                        case "Three":
                            if (command.Contains("southeast") || command.Contains("south east") || command.Contains("se")) { currentRoom = one; };
                            if (command.Contains("southwest") || command.Contains("south west") || command.Contains("sw")) { currentRoom = two; };
                            if (command.Contains("north")) { currentRoom = six; };
                            break;
                        case "Four":
                            if (command.Contains("north")) { currentRoom = five; };
                            break;
                        case "Five":
                            if (command.Contains("southwest") || command.Contains("south west") || command.Contains("sw")) { currentRoom = one; };
                            if (command.Contains("southeast") || command.Contains("south east") || command.Contains("se")) { currentRoom = four; };
                            if (command.Contains("north")) { currentRoom = seven; };
                            break;
                        case "Six":
                            if (command.Contains("south")) { currentRoom = three; };
                            if (command.Contains("rope") || command.Contains("bridge")) { currentRoom = seven; };
                            break;
                        case "Seven":
                            if (command.Contains("south")) { currentRoom = five; };
                            break;
                        default:
                            Console.WriteLine("Uh... Go where?");
                            break;
                    }
                }

                // LOOK COMMAND
                else if (command.StartsWith("look"))
                {
                    /* USING DICTIONARY
                    if (treasure.ContainsKey("One") && currentRoom.Name == "One")
                    {
                        Console.WriteLine("Here are the items you see in this room:");
                        Console.WriteLine(treasure["One"]);
                    }
                    */

                    if (IsEmpty(currentRoom.Items) == true)
                    {
                        Console.WriteLine("Looks like there's nothing interesting in this room.");
                    }
                    else
                    {
                        Console.WriteLine("Here are the items you see in this room:");
                        foreach (var item in currentRoom.Items)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }

                // GET/TAKE/GRAB COMMANDS
                else if (command.StartsWith("get ") || command.StartsWith("take ") || command.StartsWith("grab "))
                {
                    /* DICTIONARY
                    List<KeyValuePair<string, string>> treasureList = treasure.ToList();
                    List<string> keyList = new List<string>(treasure.Values);

                    foreach (var item in keyList)
                    {
                        if (command.Contains(item))
                        {
                            Console.WriteLine($"You picked up the {item}.\n" +
                                $"Press any key to continue...");
                            //treaure.item;
                            //inventory.Add(pair.Value.ToString);
                            foundItem = true;
                            Console.ReadKey();
                            break;
                        }
                    }
                    if (!foundItem)
                    {
                        Console.WriteLine("I don't know what you're talking about.");
                    }
                    */

                    bool foundItem = false;

                    foreach (Item item in currentRoom.Items)
                    {
                        if (command.Contains(item.ToString()))
                        {
                            Console.WriteLine($"You picked up the {item}.\n" +
                                $"Press any key to continue...");
                            currentRoom.RemoveItem(item);
                            inventory.Add(item);
                            foundItem = true;
                            Console.ReadKey();
                            break;
                        }
                    }
                    if (!foundItem)
                    {
                        Console.WriteLine("I don't know what you're talking about.");
                    }
                }

                // INVENTORY COMMAND
                else if (command.Contains("inventory"))
                {
                    bool isEmpty = !inventory.Any();
                    if (isEmpty)
                    {
                        Console.WriteLine("You have nothing in your inventory.");
                    }
                    else
                    {
                        Console.WriteLine("You have:");
                        foreach (var item in inventory)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }

                // DEFAULT

                else if (command.Contains("exit") || command.Contains("quit") || command.Contains("escape"))
                {
                    gameActive = false;
                }

                else
                {
                    Console.WriteLine("I don't understand your input.");
                }
            }
        }

        public static bool IsEmpty<Item>(List<Item> list)
        {
            if (list == null)
            {
                return true;
            }
            return !list.Any();
        }
    }
}
