using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using PCDiagnostics.Client.Models;
using PCDiagnostics.Client.ViewModels.Base;
using PCDiagnostics.Web.Controllers.Devices.Dto;
using PCDiagnostics.Web.Controllers.Diagnostics.Dto;

namespace PCDiagnostics.Client.ViewModels;

public class HistoryViewModel : BaseViewModel
{
	private List<Diagnostic>? _diagnostics;
	private string _login;
	private string _key;

	public string Login
	{
		get => _login;
		set => Set(ref _login, value);
	}

	public string Key
	{
		get => _key;
		set => Set(ref _key, value);
	}

	public string AuthLine { get => _login + ":" + _key; }

	public ICommand RefreshCommand { get; private set; }

	public List<Diagnostic>? Diagnostics
	{
		get => _diagnostics;
		set => Set(ref _diagnostics, value);
	}

	public HistoryViewModel()
	{
		RefreshCommand = new RelayCommand(GetHistory);
	}

	public void GetHistory(object obj = null)
	{
		var diagnostics = Requests.ServerRequest<IEnumerable<DiagnosticDto>>(
			$"http://localhost:5001/diagnostic", method: "GET", authLine: AuthLine)?
			.Select(it => new Diagnostic
			{
				Id = it.Id,
				CheckTime = it.CheckTime
			}).ToList(); ;

		if (diagnostics is null)
			return;

		List<List<Device>?> devices = new();
		foreach (var diagnostic in diagnostics)
		{
			devices.Add(Requests.ServerRequest<IEnumerable<DeviceDto>>(
				$"http://localhost:5001/device/diagnostic-id/{diagnostic.Id}", method: "GET", authLine: AuthLine)?
				.Select(it => new Device()
				{
					Name = it.Name,
					Specs = it.Specs
				}).ToList());
		}

		for (int i = 0; i < diagnostics.Count; i++)
		{
			diagnostics[i].Devices = devices[i];
		}

		Diagnostics = diagnostics;
	}
}
