using System.Collections.Generic;

namespace PCDiagnostics.Client.Models;

public static class PCSpecs
{
	public static readonly List<DevicePattern> DevicesPatterns = new()
	{
		new ("CPU", "Win32_Processor", new()
		{
			"Name" ,
			"Device ID",
			"Asset Tag",
			"Current ClockSpeed",
			"Current Voltage",
			"L2 Cache Size",
			"L3 Cache Size",
			"Address Width",
			"Number Of Cores",
			"Thread Count",
			"System Name",
			"Virtualization Firmware Enabled",
			"Manufacturer"
		}),
		new ("GPU", "Win32_VideoController", new()
		{
			"Name",
			"Device ID",
			"Adapter Compatibility",
			"Adapter DAC Type",
			"Driver Version",
			"Current Refresh Rate",
			"Max Refresh Rate",
			"Min Refresh Rate"
		}),
		new ("Memory", "Win32_PhysicalMemory", new()
		{
			"Name",
			"Part Number",
			"Serial Number",
			"Device Locator",
			"Capacity",
			"Speed",
			"Configured Voltage",
			"Interleave Position"
		}),
		new ("Network Adapter", "Win32_NetworkAdapter", new()
		{
			"Name",
			"Device ID",
			"Adapter Type",
			"Caption",
			"Description",
			"MAC Address",
			"Manufacturer",
			"Net Connection ID",
			"Physical Adapter"
		}),
		new ("Logical disk", "Win32_LogicalDisk", new()
		{
			"Name",
			"Description",
			"File System",
			"Size",
			"Free Space"
		}),
		new ("Battery", "Win32_Battery", new()
		{
			"Name",
			"Description",
			"Estimated Charge Remaining",
			"Estimated Run Time",
			"Design Voltage"
		}),
		new ("USB Controller", "Win32_USBController", new()
		{
			"Name",
			"Description",
			"Protocol Supported"
		}),
		new ("Display", "Win32_DesktopMonitor", new()
		{
			"Name",
			"Description",
			"Device ID",
			"Screen Height",
			"Screen Width",
			"Pixels Per X Logical Inch",
			"Pixels Per Y Logical Inch"
		}),
		new ("Fan", "Win32_Fan", new()
		{
			"Name",
			"Active Cooling"
		}),
		new ("BIOS", "Win32_BIOS", new()
		{
			"Name",
			"Manufacturer",
			"Current Language",
			"Serial Number",
			"Bios Characteristics",
			"Primary BIOS"
		}),
		new ("OperatingSystem", "Win32_OperatingSystem", new()
		{
			"Caption",
			"Manufacturer",
			"OS Architecture",
			"Version",
			"CS Name",
			"Registered User",
			"Number Of Users",
			"Boot Device",
			"System Drive",
			"MUI Languages",
			"Code Set",
			"Locale",
			"Free Physical Memory",
			"Free Space In Paging Files",
			"Free Virtual Memory",
			"Number Of Processes",
			"Install Date",
			"Last Boot Up Time",
			"Local Date Time",
			"Encryption Level",
			"Portable Operating System",
			"Debug"
		})
	};
}
