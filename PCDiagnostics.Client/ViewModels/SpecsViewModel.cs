using System.Collections.Generic;
using System.Management;
using PCDiagnostics.Client.Models;
using PCDiagnostics.Client.ViewModels.Base;

namespace PCDiagnostics.Client.ViewModels;

public class SpecsViewModel : BaseViewModel
{
	private List<Device>? _devices;

	public List<Device>? Devices
	{
		get => _devices;
		set => Set(ref _devices, value);
	}

	public SpecsViewModel()
	{
		Devices = GetDevisesList();
	}

	private static ManagementObjectCollection GetDevicesByClassName(string FromWIN32Class)
	{
		ManagementObjectSearcher searcher =
				 new ManagementObjectSearcher("SELECT * FROM " + FromWIN32Class);

		return searcher.Get();
	}

	public static List<Device> GetDevisesList()
	{
		List<Device> result = new();
		foreach (var pattern in PCSpecs.DevicesPatterns)
		{
			var devices = GetDevicesByClassName(pattern.WmiClass!);
			var count = devices.Count;
			int iter = 1;
			foreach (var device in devices)
			{
				Dictionary<string, string> specs = new();
				foreach (var prop in pattern.Properties!)
					specs.Add(prop, device[prop.Replace(" ", "")]?.ToString() ?? string.Empty);

				result.Add(new Device()
				{
					Name = $"{pattern.DeviceType} {(count > 1 ? iter++ : string.Empty)}",
					Specs = specs
				});
			}
		}
		return result;
	}
}
