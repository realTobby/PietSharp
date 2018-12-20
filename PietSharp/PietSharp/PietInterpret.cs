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
        public int[] stack = null;
        public Bitmap PietFile { get; set; }

        public PietInterpret(string filepath)
        {
            PietFile = new Bitmap(filepath);
        }

        public void Start()
        {
            // get codel size (width and height)
            // implement function with the different commands
            // implement a way to stack the integers
            // implement a way to detect the hue/light/color changes and "execute" the corresponding command
        }



    }
}
