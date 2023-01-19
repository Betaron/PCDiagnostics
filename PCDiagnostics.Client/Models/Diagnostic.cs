using System;
using System.Collections.Generic;

namespace PCDiagnostics.Client.Models;

public class Diagnostic
{
	public Guid Id { get; set; }
	public DateTime CheckTime { get; set; }
	public List<Device>? Devices { get; set; }
}
