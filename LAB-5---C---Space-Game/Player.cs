using System;
using System.Collections.Generic;

namespace LAB_5___C___Space_Game
{
    public class Player
    {
        public double age = 18;
        public Location location;

        public Player(Location location)
        {
            this.location = location;
        }

        public void TravelTo(Location destination, double warpSpeed)
        {
            var distance = location.DistanceTo(destination);
            var speed    = Utility.WarpSpeedToLightSpeed(warpSpeed);

            age += distance / speed;

            location = destination;
        }
    }
}