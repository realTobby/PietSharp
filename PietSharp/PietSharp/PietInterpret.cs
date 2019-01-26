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

            ReadPietCode();
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
            firstCodel.NEIGHBOURCHECK = false;
            result.Add(firstCodel);

            while (result.Where(x=>x.NEIGHBOURCHECK == false) != null)
            {
                var neighbours = GetCodelNeighbours(result.First(x => x.NEIGHBOURCHECK == false));


                var noDupeNeighbours = neighbours.Distinct().ToList();


                result.AddRange(noDupeNeighbours);



                int max = result.Count();
                int diff = max - neighbours.Count();

                result[diff - 1].NEIGHBOURCHECK = true;


            }
            return result;
        }

        private List<CODEL> GetCodelNeighbours(CODEL firstCodel)
        {
            List<CODEL> neighbours = new List<CODEL>();
            int x = firstCodel.POSITION_X;
            int y = firstCodel.POSITION_Y;
            string hexColor = firstCodel.HEXCOLOR;
            LIGHT_CYCLE light = firstCodel.LIGHT;



            if(x > 0)
            {
                CODEL leftNeighbour = PietCode.Where(codel => codel.POSITION_X == x -1 && codel.POSITION_Y == y && codel.HEXCOLOR == hexColor && codel.LIGHT == light).FirstOrDefault();
                if (leftNeighbour != null)
                {
                    neighbours.Add(leftNeighbour);
                }
                    
            }
            if(x < RESIZED_PIET.Width)
            {
                CODEL rightNeighbour = PietCode.Where(codel => codel.POSITION_X == x +1 && codel.POSITION_Y == y && codel.HEXCOLOR == hexColor && codel.LIGHT == light).FirstOrDefault();
                if (rightNeighbour != null)
                    neighbours.Add(rightNeighbour);
            }

            if (y > 0)
            {
                CODEL topNeighbour = PietCode.Where(codel => codel.POSITION_X == x && codel.POSITION_Y == y - 1 && codel.HEXCOLOR == hexColor && codel.LIGHT == light).FirstOrDefault();
                if (topNeighbour != null)
                    neighbours.Add(topNeighbour);
            }

            if (y < RESIZED_PIET.Height)
            {
                CODEL downNeighbour = PietCode.Where(codel => codel.POSITION_X == x && codel.POSITION_Y == y + 1 && codel.HEXCOLOR == hexColor && codel.LIGHT == light).FirstOrDefault();
                if (downNeighbour != null)
                    neighbours.Add(downNeighbour);
            }

            return neighbours;

        }

        public void LoadPietFile(string filepath)
        {
            ENLARGED_PIET = new Bitmap(filepath);
        }

        public void ReadPietCode()
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
                    PietCode.Add(new CODEL(rx, ry, currentCodel));
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
    }
}
