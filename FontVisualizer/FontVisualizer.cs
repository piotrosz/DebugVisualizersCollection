using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;


[assembly: DebuggerVisualizer(
typeof(DebugVisualizersCollection.FontVisualizer),
Target = typeof(Font),
Description = "Font Visualizer")]

namespace DebugVisualizersCollection
{
	public class FontVisualizer : DialogDebuggerVisualizer
	{
		Font font;

		protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider provider)
		{
			using (Form form1 = new Form())
			{
				form1.Paint += new PaintEventHandler(form1_Paint);

				form1.Text = "Font Visualizer";

				font = (Font)provider.GetObject();

				form1.StartPosition = FormStartPosition.WindowsDefaultLocation;
				form1.SizeGripStyle = SizeGripStyle.Auto;
				form1.ShowInTaskbar = false;
				form1.ShowIcon = false;

				Graphics formGraphics = form1.CreateGraphics();

				var size = formGraphics.MeasureString(font.Name, font);

				form1.Width = (int)size.Width + 100;
				form1.Height = (int)size.Height + 100;
				
				windowService.ShowDialog(form1);
			}
		}

		void form1_Paint(object sender, PaintEventArgs e)
		{
			string drawString = font.Name;
			SolidBrush drawBrush = new SolidBrush(Color.Black);
			e.Graphics.DrawString(drawString, font, drawBrush, 0, 0);
		}
	}
}
