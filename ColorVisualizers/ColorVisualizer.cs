using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;


[assembly: DebuggerVisualizer(
typeof(DebugVisualizersCollection.ColorVisualizer),
Target = typeof(Color),
Description = "Color Visualizer")]

namespace DebugVisualizersCollection
{
    public class ColorVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider provider)
        {
            using (Form form1 = new Form())
            {
                form1.Text = "Color Visualizer";

                var color = (Color)provider.GetObject();

                var colorControl = new ColorControl();
                colorControl.Color = color;

                form1.Controls.Add(colorControl);
                form1.Width = colorControl.Width;
                form1.Height = colorControl.Height + 40;
                form1.StartPosition = FormStartPosition.WindowsDefaultLocation;
                form1.SizeGripStyle = SizeGripStyle.Auto;
                form1.ShowInTaskbar = false;
                form1.ShowIcon = false;

                windowService.ShowDialog(form1);
            }
        }
    }
}
