using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietSharp
{
    enum DP
    {
        RIGHT,
        LEFT,
        UP,
        DOWN,
    }

    enum CC
    {
        RIGHT,
        LEFT
    }

    public enum HUE_CYCLE
    {
        RED,
        YELLOW,
        GREEN,
        CYAN,
        BLUE,
        MAGENTA,
        WHITE,
        BLACK
    }

    public enum LIGHT_CYCLE
    {
        LIGHT,
        NORMAL,
        DARK
    }

    class PietInterpret
    {
        public Stack<int> stack = new Stack<int>();
        public Bitmap PietFile { get; set; }

        public List<CODEL> PietCode { get; set; }

        public int CURRENT_ATTEMPTS = 0;

        public DP DIRECTION_POINTER { get; set; } = DP.RIGHT;
        public CC CODEL_CHOOSER { get; set; } = CC.LEFT;

        public int POINTER_X { get; set; } = 0;
        public int POINTER_Y { get; set; } = 0;

        public int CODEL_WIDTH { get; set; }
        public int CODEL_HEIGHT { get; set; }


        public PietInterpret(string filepath)
        {
            PietFile = new Bitmap(filepath);
            PietCode = new List<CODEL>();
        }

        public void Start()
        {
            Console.Write("Codel Width: ");
            CODEL_WIDTH = Convert.ToInt32(Console.ReadLine());

            Console.Write("Codel height: ");
            CODEL_HEIGHT = Convert.ToInt32(Console.ReadLine());

            // read every codel and save color into color canvas
            for(int codel_y = 0; codel_y < PietFile.Size.Height; codel_y += CODEL_HEIGHT)
            {
                for(int codel_x = 0; codel_x < PietFile.Size.Width; codel_x+= CODEL_WIDTH)
                {
                    Color middlePixel = PietFile.GetPixel(codel_x + CODEL_WIDTH / 2, codel_y + CODEL_HEIGHT / 2);
                    CODEL newCodel = new CODEL(codel_x, codel_y, middlePixel);
                    PietCode.Add(newCodel);
                    Console.Write(newCodel.COLOR_NAME.ToString()[0]);
                }
                Console.WriteLine("");
            }

            //while(CURRENT_ATTEMPTS < 8)
            //{
                CODEL currentCodel = PietCode.Where(x => x.INDEX_X == POINTER_X && x.INDEX_Y == POINTER_Y).FirstOrDefault();

                var test = GetBlockInteger(currentCodel.HEXCOLOR);
                Console.WriteLine(test);
            //}
        }

        private void TurnDPClockwise()
        {
            switch(DIRECTION_POINTER)
            {
                case DP.DOWN:
                    DIRECTION_POINTER = DP.LEFT;
                    break;
                case DP.LEFT:
                    DIRECTION_POINTER = DP.UP;
                    break;
                case DP.UP:
                    DIRECTION_POINTER = DP.RIGHT;
                    break;
                case DP.RIGHT:
                    DIRECTION_POINTER = DP.DOWN;
                    break;
            }
        }

        private int GetBlockInteger(string colorToCheck)
        {
            int blockSize = -1;

            // scan for region size
            for(int y = 0; y < PietFile.Size.Height; y+=CODEL_HEIGHT)
            {
                for(int x = 0; x < PietFile.Size.Width; x+= CODEL_WIDTH)
                {
                    if(PietCode.Where(i=>i.INDEX_X == x && i.INDEX_Y == y).FirstOrDefault().HEXCOLOR == colorToCheck)
                    {
                        blockSize += 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return blockSize;
        }



    }
}
