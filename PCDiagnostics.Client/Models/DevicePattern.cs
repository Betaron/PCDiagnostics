using System.Collections.Generic;

namespace PCDiagnostics.Client.Models;

public class DevicePattern
{
	public string? DeviceType { get; set; }
	public string? WmiClass { get; set; }
	public HashSet<string>? Properties { get; set; }

	public DevicePattern(string? name, string? wmiClass, HashSet<string>? properties)
	{
		DeviceType = name;
		WmiClass = wmiClass;
		Properties = properties;
	}
}
