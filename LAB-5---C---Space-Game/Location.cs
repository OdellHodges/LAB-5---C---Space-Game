using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_5___C___Space_Game
{
    class Location
    {
        public string name;

        double xPos;
        double yPos;

      //  decimal tradeRate;

       // public List<Item> items;
       // private string v1;
       // private int v2;
       // private int v3;

        public Location(string name, double xPos, double yPos) //List<Item> items, decimal, tradeRate = 1.0M)
        {
            this.name = name;
            this.xPos = xPos;
            this.yPos = yPos;
           // this.tradeRate = tradeRate;
          //  this.Item = items;
        }

       // public Location(string v1, int v2, int v3)
       // {
       //     this.v1 = v1;
       //     this.v2 = v2;
       //     this.v3 = v3;
       // }

        public double DistanceTo(Location destination)
        {
            var left  = Math.Pow(this.xPos - destination.xPos, 2);
            var right = Math.Pow(this.yPos - destination.yPos, 2);

            return Math.Sqrt(left + right);
        }
    }
}
