using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Paint
{
    public struct Pixel
    {
        public Pixel(Color col, PointF pnt)
        {
            Color = col;
            Location = pnt;
            Width = 0;
            Height = 0;
        }
        public Color Color { get; set; }
        public PointF Location { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float X => Location.X;
        public float Y => Location.Y;
    }
    public static class ImageProcessing
    {
        public delegate Pixel ProcessPixel(Pixel pixel);
        public static int RunningThreads = 0;
        static int threadBlock, lastBlock, mTC;
        static ProcessPixel pp;
        static Bitmap[] blocks;
        static Bitmap[] inBlocks;
        public static Bitmap ProcessImage(Bitmap image, ProcessPixel callback, int threadCount = 0, bool Inverse_Horizontally = false)
        {
            if (threadCount == 0)
                threadCount = Environment.ProcessorCount;
            mTC = threadCount;
            threadBlock = image.Width / threadCount;
            lastBlock = image.Width - ((threadCount - 1) * threadBlock);

            Thread[] threads = new Thread[threadCount];
            pp = callback;
            blocks = new Bitmap[threadCount];
            inBlocks = new Bitmap[threadCount];
            for (int i = 0; i < threadCount; i++)
            {

                int wid = i == threadCount - 1 ? lastBlock : threadBlock;
                inBlocks[i] = new Bitmap(wid, image.Height);
                using (Graphics g2 = Graphics.FromImage(inBlocks[i]))
                {
                    g2.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g2.DrawImage(image,
                        new Rectangle(0, 0, inBlocks[i].Width, image.Height),
                        new Rectangle(i * threadBlock, 0, threadBlock, image.Height),
                        GraphicsUnit.Pixel);
                }
            }


            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(THREAD);
                threads[i].Name = i.ToString();
                threads[i].Start();
            }

            bool ended = false;
            while (!ended)
            {
                ended = true;
                int liveThreads = 0;
                for (int i = 0; i < threadCount; i++)
                {
                    if (threads[i].IsAlive) { ended = false; liveThreads++; }
                }
               // if (label != null) label.Text = "Proccessing Image...";
                System.Windows.Forms.Application.DoEvents();
            }

            Bitmap outB = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < threadCount; i++)
            {

                using (Graphics g = Graphics.FromImage(outB))
                {
                    int x = Inverse_Horizontally ? outB.Width - ((i + 1) * threadBlock) : i * threadBlock;
                    g.DrawImage(blocks[i], new Rectangle(x, 0, blocks[i].Width, image.Height));
                    blocks[i].Dispose();
                    inBlocks[i].Dispose();
                }

            }

            return outB;
        }
        static void THREAD()
        {
            int myIndex = int.Parse(Thread.CurrentThread.Name);
            Bitmap img = inBlocks[myIndex];

            int startBlock = (myIndex - 1) * threadBlock;
            int endBlock = myIndex == mTC - 1 ? startBlock + lastBlock : startBlock + threadBlock;
            blocks[myIndex] = new Bitmap(endBlock - startBlock, img.Height);


            for (int x = startBlock; x < endBlock; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {

                    var col = img.GetPixel(x - startBlock, y);
                    if (col.A < 40) continue;
                    Pixel input = new Pixel(col, new PointF(x - startBlock, y));
                    input.Width = endBlock - startBlock;
                    input.Height = img.Height;
                    var pix = pp(input);
                    blocks[myIndex].SetPixel((int)pix.X, (int)pix.Y, pix.Color);

                }
            }
        }

    }
    public static class ImageFilters
    {
        public static Pixel RedOnly(Pixel pix) => new Pixel(Color.FromArgb(pix.Color.R, 0, 0), pix.Location);
        public static Pixel GreenOnly(Pixel pix) => new Pixel(Color.FromArgb(0, pix.Color.G, 0), pix.Location);
        public static Pixel BlueOnly(Pixel pix) => new Pixel(Color.FromArgb(0, 0, pix.Color.B), pix.Location);
        public static Pixel Invert(Pixel pix) => new Pixel(
            Color.FromArgb(255 - pix.Color.R, 255 - pix.Color.G, 255 - pix.Color.B)
            , pix.Location);
        public static Pixel GrayScale(Pixel pix)
        {
            int avg = (pix.Color.R + pix.Color.G + pix.Color.B) / 3;
            return new Pixel(Color.FromArgb(avg, avg, avg), pix.Location);
        }
        public static Pixel BlackWhite(Pixel pix)
        {
            Color col = GrayScale(pix).Color;
            int bW = col.R > 150 ? 255 : 0;
            return new Pixel(Color.FromArgb(bW, bW, bW), pix.Location);
        }
        public static Pixel Inverse_Horizontally(Pixel pix)
        {
            return new Pixel(pix.Color, new PointF((pix.Width - 1) - pix.X, pix.Y));
        }
        public static Pixel Inverse_Vertically(Pixel pix)
        {
            return new Pixel(pix.Color, new PointF(pix.X, (pix.Height - 1) - pix.Y));
        }
    }
}
