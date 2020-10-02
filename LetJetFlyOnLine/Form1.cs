using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LetJetFlyOnLine
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        public Form1()
        {
            InitializeComponent();
            
        }

        List<Point> coords;
        Image plane;
        List<PictureBox> pictures = new List<PictureBox>();
       
        private void Form1_Load(object sender, EventArgs e)
        {

            //MessageBox.Show(Math.Sin((90*Math.PI)/180).ToString());
            plane = Image.FromFile("F-23A_Black_Widow_II(1).png");

            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            coords = new List<Point>();
            coords.Add(new Point(100, 100));
            coords.Add(new Point(500, 100));
            coords.Add(new Point(500, 500));
            //shortestPathCoords.Add(new Point(700, 500));
            coords.Add(new Point(700, 300));
            coords.Add(new Point(900, 500));
            coords.Add(new Point(700, 800));
            coords.Add(new Point(700, 1000));
            coords.Add(new Point(500, 1000));
            coords.Add(new Point(500, 800));

            graphics = this.CreateGraphics();
            //graphics.Clear(SystemColors.Control);
            Pen pen = new Pen(Color.Blue, 3);
            for (int i = 0; i < coords.Count-1; i++)
            {
                graphics.DrawLine(pen, coords[i], coords[i+1]);
            }
            graphics.DrawLine(pen, coords[coords.Count-1], coords[0]);


            graphics.Dispose();
        }

        private double getAngle(Point firstCoord, Point secondCoord, out int moveToRHSCoef, out int moveToBottomCoef)
        {
            double numurator = secondCoord.Y - firstCoord.Y;
            double denominator = secondCoord.X - firstCoord.X;
            if (denominator < 0)
            {
                moveToRHSCoef = -1; //if the enemy base is on the rhs of the the goody runway, else I must multiply the denominator with -1 if the denominator is larger than 0
            }
            else{
                moveToRHSCoef = 1;
            }

            if (numurator < 0)
            {
                moveToBottomCoef = -1; //if the enemy base is on the rhs of the the goody runway, else I must multiply the denominator with -1 if the denominator is larger than 0
            }
            else
            {
                moveToBottomCoef = 1;
            }

            if (numurator == 0)
            {
                return 0;
            }
            else if (denominator == 0)
            {
                return 90;
            }
            else
            {
                double m = (numurator) / (denominator);
                //MessageBox.Show(m.ToString());
                double angle = Math.Atan(m) * 180 / Math.PI;// to convert from radians to degrees
                

                return Math.Abs(angle);
            }
            
        }

        private Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            bmp.MakeTransparent();

            //return the image
            return bmp;
        }

        //int currentCoordIndex = 0;

        private void StartFlight()
        {

           // MessageBox.Show((coords.Count).ToString());
            for (int currentCoordIndex = 0; currentCoordIndex < coords.Count; currentCoordIndex++)
            {
                
                //MessageBox.Show(coords.Count.ToString());
                int speed = 10;
                int nextCoordIndex = currentCoordIndex + 1;
                if (nextCoordIndex > coords.Count - 1)
                {
                    nextCoordIndex = 0;
                }

                int moveToRHSCoef;
                int moveToBottomCoef;


                double angle = getAngle(coords[currentCoordIndex], coords[nextCoordIndex], out moveToRHSCoef, out moveToBottomCoef);
                //MessageBox.Show(angle.ToString());
                //MessageBox.Show(currentCoordIndex.ToString());


                double xIncrement = speed * Math.Cos((angle * Math.PI) / 180) * moveToRHSCoef;
                double yIncrement = speed * Math.Sin((angle * Math.PI) / 180) * moveToBottomCoef;

                //MessageBox.Show("X Increment:" + xIncrement.ToString() + "\nY Increment:" + yIncrement.ToString()+"\nCurrentIndex:"+currentCoordIndex.ToString()+"\nNextIndex:"+nextCoordIndex.ToString());

                double currrentX = coords[currentCoordIndex].X;
                double currrentY = coords[currentCoordIndex].Y;

                int sleep = 0;
                //MessageBox.Show(currrentX.ToString() +";"+ shortestPathCoords[nextCoordIndex].X.ToString());
                if (moveToRHSCoef > 0 && moveToBottomCoef > 0)
                {
                    ChangeAngleOfPlane(angle, moveToRHSCoef, moveToBottomCoef);
                    Thread.Sleep(sleep);
                    while (currrentX <= coords[nextCoordIndex].X && currrentY <= coords[nextCoordIndex].Y)
                    {
                        pictureBox1.Location = new Point((int)Math.Round(Math.Round(currrentX) - (pictureBox1.Width / 2)), (int)Math.Round(Math.Round(currrentY) - (pictureBox1.Height / 2)));
                        currrentX += xIncrement;
                        currrentY += yIncrement;
                        //this.Update();
                        //pictureBox1.Update();
                        pictureBox1.Refresh();
                        Thread.Sleep(sleep);
                        //MessageBox.Show(pictureBox1.Location.ToString());
                    }
                }
                else if (moveToRHSCoef < 0 && moveToBottomCoef > 0)
                {
                    ChangeAngleOfPlane(angle, moveToRHSCoef, moveToBottomCoef);
                    Thread.Sleep(sleep);
                    while (currrentX >= coords[nextCoordIndex].X && currrentY <= coords[nextCoordIndex].Y)
                    {
                        pictureBox1.Location = new Point((int)Math.Round(Math.Round(currrentX) - (pictureBox1.Width / 2)), (int)Math.Round(Math.Round(currrentY) - (pictureBox1.Height / 2)));
                        currrentX += xIncrement;
                        currrentY += yIncrement;
                        //this.Update();
                        //pictureBox1.Update();
                        pictureBox1.Refresh();
                        Thread.Sleep(sleep);
                    }
                }
                else if (moveToRHSCoef > 0 && moveToBottomCoef < 0)
                {
                    ChangeAngleOfPlane(angle, moveToRHSCoef, moveToBottomCoef);
                    Thread.Sleep(sleep);
                    while (currrentX <= coords[nextCoordIndex].X && currrentY >= coords[nextCoordIndex].Y)
                    {
                        pictureBox1.Location = new Point((int)Math.Round(Math.Round(currrentX) - (pictureBox1.Width / 2)), (int)Math.Round(Math.Round(currrentY) - (pictureBox1.Height / 2)));
                        currrentX += xIncrement;
                        currrentY += yIncrement;
                        //this.Update();
                        //pictureBox1.Update();
                        pictureBox1.Refresh();
                        Thread.Sleep(sleep);
                    }
                }
                else if (moveToRHSCoef < 0 && moveToBottomCoef < 0)
                {
                    ChangeAngleOfPlane(angle, moveToRHSCoef, moveToBottomCoef);
                    Thread.Sleep(sleep);
                    while (currrentX >= coords[nextCoordIndex].X && currrentY >= coords[nextCoordIndex].Y)
                    {
                        pictureBox1.Location = new Point((int)Math.Round(Math.Round(currrentX) - (pictureBox1.Width / 2)), (int)Math.Round(Math.Round(currrentY) - (pictureBox1.Height / 2)));
                        currrentX += xIncrement;
                        currrentY += yIncrement;
                        //this.Update();
                        //pictureBox1.Update();
                        pictureBox1.Refresh();
                        Thread.Sleep(sleep);
                    }
                }
                this.Update();
            }                      

        }


        private void ChangeAngleOfPlane(double angle, int moveToRHSCoef, int moveToBottomCoef)
        {

            
            
            if(moveToRHSCoef<0 && moveToBottomCoef < 0)
            {
                angle += 180;
            }
            else if ((moveToRHSCoef < 0 && moveToBottomCoef > 0))
            {
                angle = angle*-1 -180;
            }
            else if(moveToRHSCoef > 0 && moveToBottomCoef < 0)
            {
                angle = angle * -1;
            }

            
            pictureBox1.Image = RotateImage(plane, (float)angle);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Update();
            pictureBox1.Refresh();
        }

        private void btnStartFlight_Click(object sender, EventArgs e)
        {
            StartFlight();
            //currentCoordIndex++;
            //if (currentCoordIndex > shortestPathCoords.Count - 1)
            //{
            //    currentCoordIndex = 0;
            //}

        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }
    }
}
