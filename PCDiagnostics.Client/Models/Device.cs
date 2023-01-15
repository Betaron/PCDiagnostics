using System;
using System.Collections.Generic;

namespace PCDiagnostics.Client.Models;

[Serializable]
public class Device
{
	public string? Name { get; set; }
	public Dictionary<string, string>? Specs { get; set; }
}
