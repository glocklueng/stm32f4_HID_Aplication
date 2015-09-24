using System;
 
namespace GenericHid
{
	internal sealed partial class Debugging
    {         
        internal String ResultOfApiCall( String functionName ) 
        {
	        var resultString = new String(Convert.ToChar( 0 ), 129 ); 
            Int32 resultCode = System.Runtime.InteropServices.Marshal.GetLastWin32Error(); 
            Int64 temp = 0;
			Int32 bytes = NativeMethods.FormatMessage(NativeMethods.FormatMessageFromSystem, ref temp, resultCode, 0, resultString, 128, 0); 
            if ( bytes > 2 ) 
            { 
                resultString = resultString.Remove( bytes - 2, 2 ); 
            }             
            resultString = Environment.NewLine + functionName + Environment.NewLine + "Result = " + resultString + Environment.NewLine; 
            return resultString;             
        }         
    }  
} 
