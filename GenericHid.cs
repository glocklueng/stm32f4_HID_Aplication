
using System.Windows.Forms;

namespace GenericHid
{
	public class GenericHid  
	{ 
		internal static FrmMain FrmMy; 
		public static void Main() 
		{ 
			FrmMy = new FrmMain(); 
			Application.Run(FrmMy); 
		} 
	} 
} 
