using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAB_5___C___Space_Game
{
    public enum QuitReason {DontQuit, UserQuit, Age, OutofMoney};

    public class App
    {
        List<Location> locations = new List<Location>();

        Player hero;

        public App()
        {

            locations.Add(new Location("Earth", 0, 0, new List<Items>()));
            locations.Add(new Location("Mars", 1, 1, new List<Items>()));
            locations.Add(new Location("Venus", 2, 2, new List<Items>()));
            locations.Add(new Location("Mercury", 3, 3, new List<Items>()));
            locations.Add(new Location("Jupiter", 4, 4, new List<Items>()));
            locations.Add(new Location("Alpha Proxima 1", 4.7, 0, new List<Items>()));

            var Health = new Items("Health Pack");
            var Copper = new Items("Copper Mineral");
            var Fuel = new Items("JP8 Fuel Key");
            var IceCream = new Items("Chunky Monkey");
            var Palladium = new Items("Palladium");

            hero = new Player(locations[0]);
        }

    public void Run()
        {
            Program.Title();

            var quitReason = EventLoop();

            Program.ClosingMessage(quitReason);
        }

        private QuitReason EventLoop()
        {
            var quitReason = QuitReason.DontQuit;
            
            do
            {
                Console.Clear();

                //Print the current location
                Console.WriteLine($"Location: {hero.location.name}\t\tAge: {hero.age:f2} years\n");

                //Provide options to the user of goods
                PrintOptionList();

                var key = UI.ElicitInput();

                quitReason = ShouldQuit(HandleInput(key));
            } while (quitReason == QuitReason.DontQuit);

            return quitReason;

        }

        private QuitReason ShouldQuit(QuitReason quitReason)
        {
            QuitReason AgeCheck() => hero.age >= 60 ? QuitReason.Age : QuitReason.DontQuit;

            if (quitReason == QuitReason.DontQuit)
            {
                quitReason = AgeCheck();
            }
              return quitReason;
        }

        private void PrintOptionList()
        {
            Console.WriteLine();
            Console.WriteLine("1. Travel to other locations");
            Console.WriteLine("2. Buy item");
            Console.WriteLine("3. Trade item");
            Console.WriteLine("q. Quit");
        }

        public QuitReason HandleInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Q:
                    return QuitReason.UserQuit;
                case ConsoleKey.D1:
                    TravelMenu();
                    break;
                case ConsoleKey.D2:
                    BuyMenu();
                    break;
                case ConsoleKey.D3:
                    SellMenu();
                    break;
            }

            return QuitReason.DontQuit;
        }

        private void SellMenu()
        {
            Console.Clear();

            if (hero.inventory.Any())
            {
                PrintItems(hero.inventory);

                var itemIndex = UI.ElicitInput("Which item would you like to trade: ", 1, hero.inventory.Count);

                if (!itemIndex.cancelled)
                {
                    hero.SellItem(hero.inventory[itemIndex.input - 1]);
                }
            }
            else
            {
                Console.WriteLine("Nothing to trade...");
                UI.ElicitInput("Press any key to continue...");
            }
        }

        private void BuyMenu()
        {
            Console.Clear();

            List<Items> items = hero.location.items;

            PrintItems(items);

            var itemIndex = UI.ElicitInput("Which item would you like to buy: ", 1, items.Count);

            if (!itemIndex.cancelled)
            {
                hero.BuyItem(items[itemIndex.input - 1]);
            }
        }

        private void PrintItems(List<Items> items)
        {
            for (int i = 0; i < items.Count; ++i)
            {
                var item = items[i];

                Console.WriteLine($"{i + 1}. {item.name}");
            }
        }

        //travel menu and basic controls for travel menu
        public void TravelMenu()
        {
            var done = false;
            int selector = 0;
            int count = locations.Count;

            do
            {
                Console.Clear();
                Console.WriteLine("Travel to:");

                PrintLocationsAndDistances(selector);

                var key = UI.ElicitInput();


                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        selector++;
                        selector %= count;
                        break;
                    case ConsoleKey.UpArrow:
                        selector--;
                        selector = (selector + count) % count;
                        break;
                    case ConsoleKey.Q:
                        done = true;
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.Enter:
                        done = true;
                        var warpSpeed = UI.ElicitInput("How fast (in warp units) would you like to go?", 0.0, 9.5);
                        hero.TravelTo(locations[selector], warpSpeed);
                        break;
                }
            } while (!done);
        }

        public void PrintLocationsAndDistances(int selector)
        {
            for (int i = 0; i < locations.Count; ++i)
            {
                Location destination = locations[i];

                var distance = hero.location.DistanceTo(destination);

                Console.WriteLine($"{i + 1}. ");


                if (i == selector)
                {
                    UI.Highlight();
                }

                Console.WriteLine($"{destination.name}: {distance:f2} light years");

                UI.ResetColors();
            }
        }
    }
}

