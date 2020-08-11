using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LAB_5___C___Space_Game
{
    public class Location
    {
        public string name;

        double xPos;
        double yPos;

         public List<Items> items;

         public Location(string name, double xPos, double yPos, List<Items> items)
        {
            this.name = name;
            this.xPos = xPos;
            this.yPos = yPos;
            this.items = items;
        }

        public double DistanceTo(Location destination)
        {
            var left = Math.Pow(this.xPos - destination.xPos, 2);
            var right = Math.Pow(this.yPos - destination.yPos, 2);

            return Math.Sqrt(left + right);
        }
    }
}
