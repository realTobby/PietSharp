using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietSharp
{
    enum DP_DIRECTION
    {
        RIGHT,
        LEFT,
        UP,
        DOWN,
    }

    enum CC_DIRECTION
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
        public Bitmap ENLARGED_PIET { get; set; }
        public Bitmap RESIZED_PIET { get; set; }
        public List<CODEL> PietCode { get; set; }
        public int POINTER_X { get; set; } = 0;
        public int POINTER_Y { get; set; } = 0;
        public int CODEL_WIDTH { get; set; }
        public int CODEL_HEIGHT { get; set; }
        public DP_DIRECTION DIRECTION_POINTER { get; set; } = DP_DIRECTION.RIGHT;
        public CC_DIRECTION CODEL_CHOOSER { get; set; } = CC_DIRECTION.LEFT;

        public PietInterpret(string pietPath)
        {
            LoadPietFile(pietPath);
            PietCode = new List<CODEL>();
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

        public void Start()
        {
            Console.Write("Codel Width: ");
            CODEL_WIDTH = Convert.ToInt32(Console.ReadLine());

            Console.Write("Codel height: ");
            CODEL_HEIGHT = Convert.ToInt32(Console.ReadLine());

            ShrinkPietFile();
            ReadPiet();
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
