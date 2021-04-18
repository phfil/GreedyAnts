using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAnts
{
    public class AnimatedAnt
    {
        private Bitmap[] sprites;
        private int currentLook;
        private Bitmap currentSprite;
        private double x, y;
        private double xD, yD;
        private double xStep, yStep;
        private int number;
        private float angle;

        public AnimatedAnt(double x, double y, int number)
        {
            Bitmap collection = new Bitmap(GreedyAnts.Properties.Resources.AntSpriteCollection);
            this.sprites = cutAntSpriteCollection(collection);
            currentLook = 0;
            currentSprite = sprites[currentLook];
            this.x = x;
            this.y = y;
            this.xD = 0;
            this.yD = 0;
            this.xStep = 0;
            this.yStep = 0;
            this.number = number;
            this.angle = 0;
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

        public static Bitmap getDefaultSprite(Bitmap spriteCollection)
        {
            Rectangle cloneRect = new Rectangle(0, 0, 25, 31);
            System.Drawing.Imaging.PixelFormat format = spriteCollection.PixelFormat;
            return spriteCollection.Clone(cloneRect, format);
        }

        public static Bitmap rotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnBitmap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(b, new Point(0, 0));
            }
            return returnBitmap;
        }
        public Bitmap[] getSprites()
        {
            return this.sprites;
        }

        public int getCurrentLook()
        {
            return this.currentLook;
        }

        public Bitmap getCurrentSprite()
        {
            return this.currentSprite;
        }

        public double getX()
        {
            return this.x;
        }

        public double getY()
        {
            return this.y;
        }

        public double getXD()
        {
            return this.xD;
        }

        public double getYD()
        {
            return this.yD;
        }

        public double getXStep()
        {
            return this.xStep;
        }

        public double getYStep()
        {
            return this.yStep;
        }

        public int getNumber()
        {
            return this.number;
        }

        public float getAngle()
        {
            return this.angle;
        }

        public void setCurrentLook(int currentLook)
        {
            this.currentLook = currentLook;
            this.currentSprite = this.sprites[currentLook];
        }

        public void setX(double x)
        {
            this.x = x;
        }

        public void setY(double y)
        {
            this.y = y;
        }

        public void setXD(double xD)
        {
            this.xD = xD;
        }

        public void setYD(double yD)
        {
            this.yD = yD;
        }

        public void setXStep(double xStep)
        {
            this.xStep = xStep;
        }

        public void setYStep(double yStep)
        {
            this.yStep = yStep;
        }

        public void setAngle(float angle)
        {
            this.angle = angle;
        }
    }
}
