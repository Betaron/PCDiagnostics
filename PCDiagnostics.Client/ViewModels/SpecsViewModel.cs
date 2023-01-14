using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Timers;
using LibreHardwareMonitor.Hardware;
using PCDiagnostics.Client.Models;
using PCDiagnostics.Client.ViewModels.Base;

namespace PCDiagnostics.Client.ViewModels;

public class SpecsViewModel : BaseViewModel
{
	private List<Device>? _devices;
	private Dictionary<string, string>? _temperatures;
	private string _login;

	public List<Device>? Devices
	{
		get => _devices;
		set => Set(ref _devices, value);
	}

	public Dictionary<string, string>? Temperatures
	{
		get => _temperatures;
		set => Set(ref _temperatures, value);
	}

	public string Login
	{
		get => _login;
		set => Set(ref _login, value);
	}

	public SpecsViewModel()
	{
		Devices = GetDevisesList();

		System.Timers.Timer timer = new(1000);
		timer.Elapsed += new System.Timers.ElapsedEventHandler(RequestTemperatures);
		timer.Start();
	}

	private static ManagementObjectCollection GetDevicesByClassName(string FromWIN32Class)
	{
		ManagementObjectSearcher searcher =
				 new ManagementObjectSearcher("SELECT * FROM " + FromWIN32Class);

		return searcher.Get();
	}

	private void RequestTemperatures(object? sender, ElapsedEventArgs e)
	{
		Temperatures = GetTemperatures();
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
				Debug.WriteLine(device.GetText(TextFormat.Mof));
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

	public static Dictionary<string, string> GetTemperatures()
	{
		Computer computer = new()
		{
			IsCpuEnabled = true,
			IsGpuEnabled = true,
		};

		computer.Open();

		Dictionary<string, string> temps = new();

		foreach (IHardware hardware in computer.Hardware)
		{
			var tempSensors = hardware.Sensors.Where(s => s.SensorType == SensorType.Temperature).ToList();
			var temp = tempSensors.Count > 0 ? tempSensors[0].Value.ToString() : null;
			if (string.IsNullOrEmpty(temp))
				temp = "unknown";
			temps.Add(hardware.Name, temp!);
		}
		return temps;
	}
}
