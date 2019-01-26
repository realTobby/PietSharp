using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietSharp
{
    class PietInterpret
    {
        public Bitmap ENLARGED_PIET { get; set; }
        public Bitmap RESIZED_PIET { get; set; }
        public List<CODEL> PietCode { get; set; }
        public int CODEL_WIDTH { get; set; }
        public int CODEL_HEIGHT { get; set; }
        public POINTER PIET_POINTER { get; set; }
        
        public PietInterpret(string pietPath)
        {
            LoadPietFile(pietPath);
            PietCode = new List<CODEL>();

        }

        public void Start()
        {
            Console.Write("Codel Width: ");
            CODEL_WIDTH = Convert.ToInt32(Console.ReadLine());

            Console.Write("Codel height: ");
            CODEL_HEIGHT = Convert.ToInt32(Console.ReadLine());

            ShrinkPietFile();
            ReadPiet();
            PIET_POINTER = new POINTER(0,0,CC_DIRECTION.LEFT, DP_DIRECTION.RIGHT);
            ExecutePiet();

        }

        private void ExecutePiet()
        {
            CODEL firstCodel = PietCode.Where(pietFinder => pietFinder.POSITION_X == PIET_POINTER.POSITION_X && pietFinder.POSITION_Y == PIET_POINTER.POSITION_Y).FirstOrDefault();

            List<CODEL> CURRENT_COLOR_BLOCK = new List<CODEL>();

            CURRENT_COLOR_BLOCK = GetColorBlock(firstCodel);

        }

        private List<CODEL> GetColorBlock(CODEL firstCodel)
        {
            List<CODEL> result = new List<CODEL>();

            int colorBlockIndex = 0;

            firstCodel.COLORBLOCKCHECK = true;
            result.Add(firstCodel);

            while(result.Count > colorBlockIndex)
            {
                int colorBlockX = result[colorBlockIndex].POSITION_X;
                int colorBlockY = result[colorBlockIndex].POSITION_Y;

                for (int y = colorBlockY; y < RESIZED_PIET.Height / CODEL_HEIGHT; y++)
                {
                    for (int x = colorBlockX; x < RESIZED_PIET.Width / CODEL_WIDTH; x++)
                    {
                        // get neighbours
                        if (y -1 > 0)
                        {
                            var topCodel = PietCode.Where(pietFinder => pietFinder.POSITION_X == x && pietFinder.POSITION_Y == y - 1 && pietFinder.HEXCOLOR == firstCodel.HEXCOLOR).FirstOrDefault();
                            if (topCodel != null)
                                result.Add(topCodel);
                        }
                        if (x - 1 > 0)
                        {
                            var leftCodel = PietCode.Where(pietFinder => pietFinder.POSITION_Y == y && pietFinder.POSITION_X == x - 1 && pietFinder.HEXCOLOR == firstCodel.HEXCOLOR).FirstOrDefault();
                            if (leftCodel != null)
                                result.Add(leftCodel);
                        }
                        if (x + 1 < RESIZED_PIET.Width / CODEL_WIDTH)
                        {
                            var rightCodel = PietCode.Where(pietFinder => pietFinder.POSITION_Y == y && pietFinder.POSITION_X == x + 1 && pietFinder.HEXCOLOR == firstCodel.HEXCOLOR).FirstOrDefault();
                            if (rightCodel != null)
                                result.Add(rightCodel);
                        }
                        if (y + 1 < RESIZED_PIET.Height / CODEL_HEIGHT)
                        {
                            var downCodel = PietCode.Where(pietFinder => pietFinder.POSITION_X == x && pietFinder.POSITION_Y == y + 1 && pietFinder.HEXCOLOR == firstCodel.HEXCOLOR).FirstOrDefault();
                            if (downCodel != null)
                                result.Add(downCodel);
                        }
                    }
                }

                if (result.Count > colorBlockIndex)
                {
                    colorBlockIndex++;
                }
            }
            return result;
        }

        public void LoadPietFile(string filepath)
        {
            ENLARGED_PIET = new Bitmap(filepath);
        }

        public void ShrinkPietFile()
        {
            Bitmap resizedPiet = new Bitmap((ENLARGED_PIET.Width / CODEL_WIDTH), (ENLARGED_PIET.Height / CODEL_HEIGHT));
            int ry = 0;
            int rx = 0;

            for (int codel_y = 0; codel_y < ENLARGED_PIET.Size.Height; codel_y += CODEL_HEIGHT)
            {
                for (int codel_x = 0; codel_x < ENLARGED_PIET.Size.Width; codel_x += CODEL_WIDTH)
                {
                    Color currentCodel = ENLARGED_PIET.GetPixel(codel_x + (CODEL_WIDTH / 2), codel_y + (CODEL_HEIGHT / 2));
                    resizedPiet.SetPixel(rx, ry, currentCodel);
                    rx += 1;
                    if (rx >= resizedPiet.Width)
                        rx = 0;
                }
                ry += 1;
                if (ry >= resizedPiet.Height)
                    ry = 0;
            }
            resizedPiet.Save("resizedPIET.png");
            RESIZED_PIET = resizedPiet;
        }

        

        private void ReadPiet()
        {
            for(int y = 0; y < RESIZED_PIET.Height; y++)
            {
                for(int x = 0; x < RESIZED_PIET.Width; x++)
                {
                    PietCode.Add(new CODEL(x, y, RESIZED_PIET.GetPixel(x, y)));
                }
            }
        }
    }
}
