using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietSharp
{
    public enum DP_DIRECTION
    {
        RIGHT,
        LEFT,
        UP,
        DOWN,
    }

    public enum CC_DIRECTION
    {
        RIGHT,
        LEFT
    }

    public class POINTER
    {
        public Stack<int> stack = new Stack<int>();
        public DP_DIRECTION DIRECTION_POINTER { get; set; } = DP_DIRECTION.RIGHT;
        public CC_DIRECTION CODEL_CHOOSER { get; set; } = CC_DIRECTION.LEFT;
        public int POSITION_X { get; set; } = 0;
        public int POSITION_Y { get; set; } = 0;

        public POINTER(int x, int y, CC_DIRECTION cc, DP_DIRECTION dp)
        {
            POSITION_X = x;
            POSITION_Y = y;
            CODEL_CHOOSER = cc;
            DIRECTION_POINTER = dp;
        }

    }
}
