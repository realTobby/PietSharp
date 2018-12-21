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

        public PietInterpret(string filepath)
        {
            PietFile = new Bitmap(filepath);
            PietCode = new List<CODEL>();
        }

        public void Start()
        {
            // === program execution === 
            // set codelSize to correspond to the size of the colored blocks
            // create a way to determine where the DIRECTION_POINTER AND CODEL_CHOOSER moves
            // add numbers to stack
            // black blocks and edges
            // white blocks
            // commands
            Console.Write("Codel Width: ");
            int codelWidth = Convert.ToInt32(Console.ReadLine());

            Console.Write("Codel height: ");
            int codelHeight = Convert.ToInt32(Console.ReadLine());

            // read every codel and save color into color canvas
            for(int codel_y = 0; codel_y < PietFile.Size.Height; codel_y += codelHeight)
            {
                for(int codel_x = 0; codel_x < PietFile.Size.Width; codel_x+=codelWidth)
                {
                    Color middlePixel = PietFile.GetPixel(codel_x + codelWidth / 2, codel_y + codelHeight / 2);
                    PietCode.Add(new CODEL(codel_x, codel_y, middlePixel));
                }
            }

            while(CURRENT_ATTEMPTS < 8)
            {

            }








        }



    }
}
