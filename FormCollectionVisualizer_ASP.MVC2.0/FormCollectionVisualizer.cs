using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Windows.Forms;
using System.Diagnostics;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[assembly: DebuggerVisualizer(
typeof(DebugVisualizersCollection.FormCollectionVisualizer),
typeof(DebugVisualizersCollection.FormCollectionObjectSource),
Target = typeof(System.Web.Mvc.FormCollection),
Description = "FormCollection Visualizer")]
namespace DebugVisualizersCollection
{
	public class FormCollectionObjectSource : VisualizerObjectSource
	{
		public override void GetData(object target, Stream outgoingData)
		{
			var formColl = (System.Web.Mvc.FormCollection)target;

			DataTable dt = new DataTable();
			dt.Columns.Add("Key", typeof(string));
			dt.Columns.Add("Value", typeof(string));

			foreach (var key in formColl.AllKeys)
			{
				var row = dt.NewRow();
				row["Key"] = key;
				row["Value"] = formColl[key];

				dt.Rows.Add(row);
			}

			BinaryFormatter serializer = new BinaryFormatter();
			serializer.Serialize(outgoingData, dt);
		}
	}

	public class FormCollectionVisualizer : DialogDebuggerVisualizer
	{
		protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider provider)
		{
			using (Form form1 = new Form())
			{
				form1.Text = "FormCollection Visualizer";
				form1.StartPosition = FormStartPosition.WindowsDefaultLocation;
				form1.SizeGripStyle = SizeGripStyle.Auto;
				form1.ShowInTaskbar = false;
				form1.ShowIcon = false;

				DataTable dt;

				using (Stream stream = provider.GetData())
				{
					BinaryFormatter bformatter = new BinaryFormatter();

					dt = (DataTable)bformatter.Deserialize(stream);

					stream.Close();
				}

				DataGridView gridView = new DataGridView();
				gridView.Dock = DockStyle.Fill;
				
				form1.Controls.Add(gridView);
				
				gridView.DataSource = dt;

				windowService.ShowDialog(form1);
			}
		}

		public static void TestShowVisualizer(object objectToVisualize)
		{
			var visualizerHost = new VisualizerDevelopmentHost(
				objectToVisualize,
				typeof(FormCollectionVisualizer),
				typeof(FormCollectionObjectSource));
			visualizerHost.ShowVisualizer();
		}
	}
}
