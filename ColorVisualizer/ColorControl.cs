using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DebugVisualizersCollection
{
    public partial class ColorControl : UserControl
    {
        public ColorControl()
        {
            InitializeComponent();
        }

        public Color Color
        {
            set 
            {
                this.panel1.BackColor = value;
                this.textBox1.Text = value.Name;
                this.textBox2.Text = string.Format("{0};{1};{2};{3}",
                    value.A, value.R, value.G, value.B);
                this.textBox3.Text = string.Format("{0};{1};{2}",
                    value.GetBrightness(), value.GetHue(), value.GetSaturation());
            }
        }
    }
}
