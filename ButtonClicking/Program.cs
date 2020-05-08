using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ButtonClicking
{
	class Program
	{
		const int WM_COMMAND = 0x0111;
		const int BN_CLICKED = 0;
	//	const int ButtonId = 0x79;
        const int ButtonId = 0x88;
		const string fn = @"C:\Windows\system32\calc.exe";
    //    const string fn = @"C:\Windows\system32\notepad.exe";

		[DllImport("user32.dll")]
		static extern IntPtr GetDlgItem(IntPtr hWnd, int nIDDlgItem);

		[DllImport("user32.dll")]
		static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

		static void Main(string[] args)
		{
			IntPtr handle = IntPtr.Zero;
			Process[] localAll = Process.GetProcesses();

            

			foreach (Process p in localAll)
			{
				if (p.MainWindowHandle != IntPtr.Zero)
				{
					ProcessModule pm = GetModule(p);
					if (pm != null && p.MainModule.FileName == fn)
						handle = p.MainWindowHandle;
				}
			}
			if (handle == IntPtr.Zero)
			{
				Console.WriteLine("Not found");
                System.Threading.Thread.Sleep(50000);
				return;
			}
			Console.WriteLine("{0:X}", handle);
			IntPtr hWndButton = GetDlgItem(handle, ButtonId);
		//	int wParam = (BN_CLICKED << 16) | (ButtonId & 0xffff);
            int wParam = (BN_CLICKED << 16) | (ButtonId & 0xffff);
			SendMessage(handle, WM_COMMAND, wParam, hWndButton);
			Console.WriteLine("Message sent");
            Console.WriteLine(handle.ToString() + " / " + WM_COMMAND.ToString() + " / " + wParam.ToString() + " / " + hWndButton.ToString());

            int i = 0;
            while (i < 100) {
            System.Threading.Thread.Sleep(50000);
            i = i + 1;
            }

		}

		/// <summary>
		/// Some modules might be restricted from access for security purposes.
		/// This will catch that error and others.
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		private static ProcessModule GetModule(Process p)
		{
			ProcessModule pm = null;
			try { pm = p.MainModule; }
			catch
			{
				return null;
			}
			return pm;
		}
	}
}
