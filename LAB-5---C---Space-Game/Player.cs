using System;
using System.Collections.Generic;

namespace LAB_5___C___Space_Game
{
    public class Player
    {
        public double age = 18;
        
        public Location location;
        public List<Items> inventory = new List<Items>();

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

        public void BuyItem (Items item)
        {
            inventory.Add(item);
        }

        public void SellItem(Items item)
        {
            inventory.Remove(item);
            
        }
    }
}