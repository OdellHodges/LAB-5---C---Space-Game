using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_5___C___Space_Game
{
    public class App
    {
        List<Location> locations = new List<Location>();

        Location currentLocation;

        public App()
        {
            locations.Add(new Location("Earth", 0, 0));
            locations.Add(new Location("Mars", 1, 1));
            locations.Add(new Location("Venus", 2, 2));
            locations.Add(new Location("Mercury", 3, 3));
            locations.Add(new Location("Jupiter", 4, 4));
            locations.Add(new Location("Alpha Proxima 1", 4.7, 0));

            currentLocation = locations[0];
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
                Console.WriteLine($"Location: {currentLocation.name}\n");

                //Provide options to the user of goods
                PrintOptionList();

                var key = UI.ElicitInput();
                quitReason = HandleInput(key);
            } while (quitReason == QuitReason.DontQuit);

            return quitReason;

        }

        private void PrintOptionList()
        {
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

        private void TravelMenu()
        {
            var valid = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Travel to:");

                PrintLocationsAndDistances();

                var key = UI.ElicitInput();

            } while (!valid);
        }

        private void PrintLocationsAndDistances()
        {
            for (int i = 0, i < locations.Count, ++i)
            {
                Location destination = locations[i];

                var distance = currentLocation.DistanceTo(destination);

                Console.WriteLine($"{i + 1}. {destination.name}: {destination}ly");
            }
        }

    }
}

