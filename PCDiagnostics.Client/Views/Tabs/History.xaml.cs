using System.Windows;
using System.Windows.Controls;

namespace PCDiagnostics.Client.Views.Tabs
{
	/// <summary>
	/// Логика взаимодействия для History.xaml
	/// </summary>
	public partial class History : UserControl
	{
		public History()
		{
			InitializeComponent();
		}
		private void ScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
		{
			ScrollViewer scv = (ScrollViewer)sender;
			scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta / 7);
			e.Handled = true;
		}

		private void Copy_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			Clipboard.SetText((((sender as Button)!.Parent as StackPanel)!.Children[0] as TextBlock)!.Text);
		}
	}
}
