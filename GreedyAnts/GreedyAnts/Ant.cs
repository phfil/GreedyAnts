using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAnts
{
    public class Ant
    {
        private Bitmap[] sprites;
        private int currentLook;
        private double x, y;



        public string displayName;
        private LinkedList<Town> tabu;
        private int nextTown;
        private LinkedList<double[]> possibilities;
        public double pathLength;

        public const int OFFSETX = 9;
        public const int OFFSETY = 11;

        public Ant(double x, double y)
        {
            Bitmap collection = new Bitmap(GreedyAnts.Properties.Resources.AntSpriteCollection);
            this.sprites = cutAntSpriteCollection(collection);
            currentLook = 0;
            this.x = x;
            this.y = y;
        }
        public Ant(double x, double y, Town town, System.Windows.Forms.ListBox lbxAnts,int antIndex)
        {
            Bitmap collection = new Bitmap(GreedyAnts.Properties.Resources.AntSpriteCollection);
            this.sprites = cutAntSpriteCollection(collection);
            currentLook = 0;



            string name = "A" + antIndex;
            this.displayName = name;
            this.tabu = new LinkedList<Town>();
            tabu.AddLast(town);
            this.x = x;
            this.y = y;


            lbxAnts.Items.Add(name);
            nextTown = -1;
            pathLength = 0;
            possibilities = new LinkedList<double[]>();
        }
        public void updatePathLength(LinkedList<Town> towns,LinkedList<LinkedList<double[]>> matrix)
        {
            this.pathLength = 0;
            for (int k = 0; k < this.getTabu().Count - 1; k++)
            {
                int town1 = this.getTabu().ElementAt(k).currentIndex;
                int town2 = this.getTabu().ElementAt(k + 1).currentIndex;
                this.pathLength += matrix.ElementAt(town1).ElementAt(town2)[0];
            }
        }
        //gibt einen Bitmap-Array mit einzelnen Ameisen-Sprites zurück
        public Bitmap[] cutAntSpriteCollection(Bitmap spriteCollection)
        {
            Bitmap[] pieces = new Bitmap[62];

            //Sprite-Spezifikation
            int rasterSize = 8;

            int width = 25;
            int height = 31;

            int correction = 0;
            int cut = 0;

            int index = 0;
            for (int i = 0; i < rasterSize; i++)
            {
                //wegen Skalierung des Sprites muss in Zeile 2(i=1) und 6(i=5) 1 Pixel vom Ausschnitt abgetrennt werden
                if (i == 1 || i == 5)
                {
                    cut = 1;
                }
                //wegen Skalierung des Sprites muss je ab Zeile 3(i=2) und 7(i=6) um 1 Pixel korrigiert werden
                if (i == 2 || i == 6)
                {
                    correction++;
                }
                for (int j = 0; j < rasterSize; j++)
                {
                    Rectangle cloneRect = new Rectangle(width * j, height * i - correction, width, height - cut);
                    System.Drawing.Imaging.PixelFormat format = spriteCollection.PixelFormat;
                    index = (rasterSize * i) + j;
                    if (index < 62)
                    {
                        pieces[(rasterSize * i) + j] = spriteCollection.Clone(cloneRect, format);
                    }
                }

                if (i == 1 || i == 5)
                {
                    cut = 0;
                }
            }
            return pieces;
        }

        public void setTabu(LinkedList<Town> tabu)
        {
            this.tabu = tabu;
        }

        public LinkedList<Town> getTabu()
        {
            return this.tabu;
        }

        public void setPossibilities(LinkedList<double[]> possibilities)
        {
            this.possibilities = possibilities;
        }

        public LinkedList<double[]> getPossibilities()
        {
            return this.possibilities;
        }

        public void setNextTown(int nextTown)
        {
            this.nextTown = nextTown;
        }

        public int getNextTown()
        {
            return this.nextTown;
        }

        public int getCurrentLook()
        {
            return this.currentLook;
        }

        public Bitmap[] getSprites()
        {
            return this.sprites;
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

        public string getDisplayName()
        {
            return this.displayName;
        }

        public void setCurrentLook(int currentLook)
        {
            this.currentLook = currentLook;
        }
    }
}
