using Microsoft.Win32.SafeHandles; 
using System;
using System.Runtime.InteropServices; 

namespace GenericHid
{    
    internal sealed partial class Hid  
    {
		internal static class NativeMethods
		{
			internal const Int16 HidP_Input = 0;
			internal const Int16 HidP_Output = 1;
			internal const Int16 HidP_Feature = 2;
			[StructLayout(LayoutKind.Sequential)]
			internal struct HIDD_ATTRIBUTES
			{
				internal Int32 Size;
				internal UInt16 VendorID;
				internal UInt16 ProductID;
				internal UInt16 VersionNumber;
			}
			internal struct HIDP_CAPS
			{
				internal Int16 Usage;
				internal Int16 UsagePage;
				internal Int16 InputReportByteLength;
				internal Int16 OutputReportByteLength;
				internal Int16 FeatureReportByteLength;
				[MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)] internal Int16[] Reserved;
				internal Int16 NumberLinkCollectionNodes;
				internal Int16 NumberInputButtonCaps;
				internal Int16 NumberInputValueCaps;
				internal Int16 NumberInputDataIndices;
				internal Int16 NumberOutputButtonCaps;
				internal Int16 NumberOutputValueCaps;
				internal Int16 NumberOutputDataIndices;
				internal Int16 NumberFeatureButtonCaps;
				internal Int16 NumberFeatureValueCaps;
				internal Int16 NumberFeatureDataIndices;
			}

			[DllImport("hid.dll", SetLastError = true)]
			internal static extern Boolean HidD_FlushQueue(SafeFileHandle HidDeviceObject);

			[DllImport("hid.dll", SetLastError = true)]
			internal static extern Boolean HidD_FreePreparsedData(IntPtr PreparsedData);

			[DllImport("hid.dll", SetLastError = true)]
			internal static extern Boolean HidD_GetAttributes(SafeFileHandle HidDeviceObject, ref HIDD_ATTRIBUTES Attributes);

			[DllImport("hid.dll", SetLastError = true)]
			internal static extern Boolean HidD_GetFeature(SafeFileHandle HidDeviceObject, Byte[] lpReportBuffer,
			                                               Int32 ReportBufferLength);

			[DllImport("hid.dll", SetLastError = true)]
			internal static extern Boolean HidD_GetInputReport(SafeFileHandle HidDeviceObject, Byte[] lpReportBuffer,
			                                                   Int32 ReportBufferLength);

			[DllImport("hid.dll", SetLastError = true)]
			internal static extern void HidD_GetHidGuid(ref Guid HidGuid);

			[DllImport("hid.dll", SetLastError = true)]
			internal static extern Boolean HidD_GetNumInputBuffers(SafeFileHandle HidDeviceObject, ref Int32 NumberBuffers);

			[DllImport("hid.dll", SetLastError = true)]
			internal static extern Boolean HidD_GetPreparsedData(SafeFileHandle HidDeviceObject, ref IntPtr PreparsedData);

			[DllImport("hid.dll", SetLastError = true)]
			internal static extern Boolean HidD_SetFeature(SafeFileHandle HidDeviceObject, Byte[] lpReportBuffer,
			                                               Int32 ReportBufferLength);

			[DllImport("hid.dll", SetLastError = true)]
			internal static extern Boolean HidD_SetNumInputBuffers(SafeFileHandle HidDeviceObject, Int32 NumberBuffers);

			[DllImport("hid.dll", SetLastError = true)]
			internal static extern Boolean HidD_SetOutputReport(SafeFileHandle HidDeviceObject, Byte[] lpReportBuffer,
			                                                    Int32 ReportBufferLength);

			[DllImport("hid.dll", SetLastError = true)]
			internal static extern Int32 HidP_GetCaps(IntPtr PreparsedData, ref HIDP_CAPS Capabilities);

			[DllImport("hid.dll", SetLastError = true)]
			internal static extern Int32 HidP_GetValueCaps(Int32 ReportType, Byte[] ValueCaps, ref Int32 ValueCapsLength,
			                                               IntPtr PreparsedData);
		}
    } 
} 
