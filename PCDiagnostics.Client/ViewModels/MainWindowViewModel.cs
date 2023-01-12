using PCDiagnostics.Client.ViewModels.Base;

namespace PCDiagnostics.Client.ViewModels;

internal class MainWindowViewModel : BaseViewModel
{
	private string _title = "PC Diagnostics";

	/// <summary>
	/// Window title
	/// </summary>
	public string Title
	{
		get => _title;
		set => Set(ref _title, value);
	}
}
