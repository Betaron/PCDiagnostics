using System.Windows.Controls;

namespace PCDiagnostics.Client.Views.Tabs
{
	/// <summary>
	/// Логика взаимодействия для Specs.xaml
	/// </summary>
	public partial class Specs : UserControl
	{
		public Specs()
		{
			InitializeComponent();
		}

		private void ScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
		{
			ScrollViewer scv = (ScrollViewer)sender;
			scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta / 7);
			e.Handled = true;
		}
	}
}
