using System;
using System.Runtime.InteropServices;

namespace gpoguy.com
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class AASGen
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		///
		[DllImport("msi.dll")]
		public static extern int MsiAdvertiseProductEx(string packagePath,string scriptFilePath, string transforms, System.UInt16 language, UInt32 platform, UInt32 options);
		[DllImport("msi.dll",SetLastError=true) ]
		public static extern int MsiSetInternalUI(int uiLevel,IntPtr hwnd);
		[STAThread]
		static void Main(string[] args)
		{
            if (args.Length == 0)
            {
                Usage();
                return;
            }
            try
            {
                int a = MsiSetInternalUI(2, IntPtr.Zero);
                int x;
                if (args.Length == 2)
                {
                    x = MsiAdvertiseProductEx(args[0], args[1], null, 0x409, 0, 0);
                }
                else
                    x = MsiAdvertiseProductEx(args[0], args[1], args[2], 0x409, 0, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
                return;
            }
        }
        static void Usage()
        {
            Console.WriteLine("\nUsage: aasgen [path to MSI Package (should be UNC)] [path to output aas file (including file name)] [UNC path to any transform]");
        }
	}
}
