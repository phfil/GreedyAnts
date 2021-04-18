using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GreedyAnts
{
    public class Town
    {
        private string name;
        private double x, y;
        private LinkedList<Ant> antList;
        private Bitmap look;

        public const int OFFSETX = 12;
        public const int OFFSETY = 24;
        public const int PROTECTEDSPACE = 40;

        public int currentIndex;

        public Town(double x, double y, int index, int townIndex, Random r)
        {
            this.name = "S"+townIndex;
            this.x = x;
            this.y = y;
            this.antList = new LinkedList<Ant>();
            this.look = assignLook(r.Next(1, 12));
            this.currentIndex = index;
        }
        public Town(double x, double y, int index, int townIndex, int look)
        {
            this.name = "S" + townIndex;
            this.x = x;
            this.y = y;
            this.antList = new LinkedList<Ant>();
            this.look = assignLook(look);
            this.currentIndex = index;
        }

        private Bitmap assignLook(int choice)
        {
            switch (choice)
            {
                case 1:
                    return new Bitmap(GreedyAnts.Properties.Resources.town1);
                case 2:
                    return new Bitmap(GreedyAnts.Properties.Resources.town2);
                case 3:
                    return new Bitmap(GreedyAnts.Properties.Resources.town3);
                case 4:
                    return new Bitmap(GreedyAnts.Properties.Resources.town4);
                case 5:
                    return new Bitmap(GreedyAnts.Properties.Resources.town5);
                case 6:
                    return new Bitmap(GreedyAnts.Properties.Resources.town6);
                case 7:
                    return new Bitmap(GreedyAnts.Properties.Resources.town7);
                case 8:
                    return new Bitmap(GreedyAnts.Properties.Resources.town8);
                case 9:
                    return new Bitmap(GreedyAnts.Properties.Resources.town9);
                case 10:
                    return new Bitmap(GreedyAnts.Properties.Resources.town10);
                case 11:
                    return new Bitmap(GreedyAnts.Properties.Resources.town11);
                case 12:
                    return new Bitmap(GreedyAnts.Properties.Resources.town12);
                default:
                    return new Bitmap(GreedyAnts.Properties.Resources.town5);
            }
        }

        public double getX()
        {
            return this.x;
        }

        public double getY()
        {
            return this.y;
        }

        public void setPosition(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void update(double x, double y)
        {
            this.x = x;
            this.y = y;
            for(int i = 0; i < antList.Count; i++)
            {
                antList.ElementAt(i).setPosition(x, y);
            }
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return this.name;
        }

        public void setAntList(LinkedList<Ant> antList)
        {
            this.antList = antList;
        }

        public LinkedList<Ant> getAntList()
        {
            return this.antList;
        }

        public Bitmap getLook()
        {
            return this.look;
        }
    }
}
