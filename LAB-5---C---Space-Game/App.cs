using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_5___C___Space_Game
{
    public class App
    {
        List<Location> locations = new List<Location>();

        Player hero;

        public App()
        {
            locations.Add(new Location("Earth", 0, 0));
            locations.Add(new Location("Mars", 1, 1));
            locations.Add(new Location("Venus", 2, 2));
            locations.Add(new Location("Mercury", 3, 3));
            locations.Add(new Location("Jupiter", 4, 4));
            locations.Add(new Location("Alpha Proxima 1", 4.7, 0));

            hero = new Player(locations[0]);
        }

    public void Run()
        {
            Program.Intro();

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
                Console.WriteLine($"Location: {hero.location.name}\n");

                //Provide options to the user of goods
                PrintOptionList();

                var key = UI.ElicitInput();
                quitReason = HandleInput(key);
            } while (quitReason == QuitReason.DontQuit);

            return quitReason;

        }

        private void PrintOptionList()
        {
            Console.WriteLine();
            Console.WriteLine("1. Travel to other locations");
            Console.WriteLine("q. Quit");
        }

        private QuitReason HandleInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Q:
                    return QuitReason.UserQuit;
                case ConsoleKey.D1:
                    TravelMenu();
                    break;
            }

            return QuitReason.UserQuit;
        }

        //travel menu and basic controls for travel menu
        private void TravelMenu()
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
                        hero.TravelTo(locations[selector]);
                        break;
                }
            } while (!done);
        }

        private void PrintLocationsAndDistances(int selector)
        {
            for (int i = 0; i < locations.Count; ++i)
            {
                Location destination = locations[i];

                var distance = hero.location.DistanceTo(destination);

                Console.WriteLine($"{i + 1}, ");

                if (i == selector)
                {
                    UI.Highlight();
                }

                Console.WriteLine($"{destination.name}: {destination}ly");

                UI.ResetColors();
            }
        }
    }
}

