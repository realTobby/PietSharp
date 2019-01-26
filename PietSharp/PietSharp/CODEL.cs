using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietSharp
{
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

    public class CODEL
    {
        public string HEXCOLOR { get; set; }
        public int POSITION_X { get; set; }
        public int POSITION_Y { get; set; }
        public int BLOCK_SIZE_COUNT { get; set; }
        public HUE_CYCLE COLOR_NAME { get; set; }
        public LIGHT_CYCLE LIGHT { get; set; }
        public bool COLORBLOCKCHECK { get; set; }

        public CODEL(int x, int y, Color c)
        {
            POSITION_X = x;
            POSITION_Y = y;
            HEXCOLOR = c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
            DiffColorNameAndLight();
        }

        private void DiffColorNameAndLight()
        {
            switch(HEXCOLOR)
            {
                case "FFC0C0":
                    COLOR_NAME = HUE_CYCLE.RED;
                    LIGHT = LIGHT_CYCLE.LIGHT;
                    break;
                case "FF0000":
                    COLOR_NAME = HUE_CYCLE.RED;
                    LIGHT = LIGHT_CYCLE.NORMAL;
                    break;
                case "C00000":
                    COLOR_NAME = HUE_CYCLE.RED;
                    LIGHT = LIGHT_CYCLE.DARK;
                    break;
                case "FFFFC0":
                    COLOR_NAME = HUE_CYCLE.YELLOW;
                    LIGHT = LIGHT_CYCLE.LIGHT;
                    break;
                case "FFFF00":
                    COLOR_NAME = HUE_CYCLE.YELLOW;
                    LIGHT = LIGHT_CYCLE.NORMAL;
                    break;
                case "C0C000":
                    COLOR_NAME = HUE_CYCLE.YELLOW;
                    LIGHT = LIGHT_CYCLE.DARK;
                    break;
                case "C0FFC0":
                    COLOR_NAME = HUE_CYCLE.GREEN;
                    LIGHT = LIGHT_CYCLE.LIGHT;
                    break;
                case "00FF00":
                    COLOR_NAME = HUE_CYCLE.GREEN;
                    LIGHT = LIGHT_CYCLE.NORMAL;
                    break;
                case "00C000":
                    COLOR_NAME = HUE_CYCLE.GREEN;
                    LIGHT = LIGHT_CYCLE.DARK;
                    break;
                case "C0FFFF":
                    COLOR_NAME = HUE_CYCLE.CYAN;
                    LIGHT = LIGHT_CYCLE.LIGHT;
                    break;
                case "00FFFF":
                    COLOR_NAME = HUE_CYCLE.CYAN;
                    LIGHT = LIGHT_CYCLE.NORMAL;
                    break;
                case "00C0C0":
                    COLOR_NAME = HUE_CYCLE.CYAN;
                    LIGHT = LIGHT_CYCLE.DARK;
                    break;
                case "C0C0FF":
                    COLOR_NAME = HUE_CYCLE.BLUE;
                    LIGHT = LIGHT_CYCLE.LIGHT;
                    break;
                case "0000FF":
                    COLOR_NAME = HUE_CYCLE.BLUE;
                    LIGHT = LIGHT_CYCLE.NORMAL;
                    break;
                case "0000C0":
                    COLOR_NAME = HUE_CYCLE.BLUE;
                    LIGHT = LIGHT_CYCLE.DARK;
                    break;
                case "FFC0FF":
                    COLOR_NAME = HUE_CYCLE.MAGENTA;
                    LIGHT = LIGHT_CYCLE.LIGHT;
                    break;
                case "FF00FF":
                    COLOR_NAME = HUE_CYCLE.MAGENTA;
                    LIGHT = LIGHT_CYCLE.NORMAL;
                    break;
                case "C000C0":
                    COLOR_NAME = HUE_CYCLE.MAGENTA;
                    LIGHT = LIGHT_CYCLE.DARK;
                    break;
                default:
                    COLOR_NAME = HUE_CYCLE.WHITE;
                    LIGHT = LIGHT_CYCLE.NORMAL;
                    break;
                case "FFFFFF":
                    COLOR_NAME = HUE_CYCLE.WHITE;
                    LIGHT = LIGHT_CYCLE.NORMAL;
                    break;
                case "000000":
                    COLOR_NAME = HUE_CYCLE.BLACK;
                    LIGHT = LIGHT_CYCLE.NORMAL;
                    break;
            }
        }
    }
}
