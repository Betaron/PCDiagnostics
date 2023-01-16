﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Timers;
using System.Windows.Input;
using LibreHardwareMonitor.Hardware;
using PCDiagnostics.Client.Models;
using PCDiagnostics.Client.ViewModels.Base;
using PCDiagnostics.Web.Controllers.Devices.Dto;
using PCDiagnostics.Web.Controllers.Diagnostics.Dto;

namespace PCDiagnostics.Client.ViewModels;

public class SpecsViewModel : BaseViewModel
{
	private List<Device>? _devices;
	private Dictionary<string, string>? _temperatures;
	private string _login;

	public ICommand RefreshCommand { get; private set; }
	public ICommand SendDiagnosticCommand { get; private set; }

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
		RefreshDevices();

		System.Timers.Timer timer = new(1000);
		timer.Elapsed += new System.Timers.ElapsedEventHandler(RequestTemperatures);
		timer.Start();

		RefreshCommand = new RelayCommand(RefreshDevices);
		SendDiagnosticCommand = new RelayCommand(SendDiagnostic);
	}

	public void RefreshDevices(object obj = null)
	{
		Devices = GetDevisesList();
	}

	private void SendDiagnostic(object obj = null)
	{
		var diagnostic = Requests.ServerRequest<DiagnosticDto>(
			$"http://localhost:5001/diagnostic",
			new DiagnosticDto()
			{
				CheckTime = DateTime.UtcNow,
			}, method: "POST");
		foreach (var device in Devices)
		{
			Requests.ServerRequest<DeviceDto>(
			$"http://localhost:5001/device",
			new DeviceDto()
			{
				DiagnosticId = diagnostic!.Id,
				Name = device.Name,
				Specs = device.Specs
			},
			method: "POST");
		}
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
