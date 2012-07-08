using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace DebugVisualizersCollectionTest
{
    class Program
    {
        static void Main()
        {
            Color color = Color.Black;

            Color[] colors = new Color[] { Color.Aqua, Color.Beige, Color.Firebrick, Color.FromArgb(23, 127, 253)};

            List<Color> colorsList = new List<Color>() { Color.Aqua, Color.Beige, Color.Firebrick, Color.FromArgb(23, 127, 253) };

            Font font = new Font("Verdana", 12, FontStyle.Bold);


        }
    }
}
