using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace FortyOne.AudioSwitcher
{
    public static class IconExtractor
    {

        public static Icon Extract(string file, int number, bool largeIcon)
        {
            IntPtr large;
            IntPtr small;

            ExtractIconEx(file, number, out large, out small, 1);
            var iconHandle = largeIcon ? large : small;

            try
            {
                return Icon.FromHandle(iconHandle).Clone() as Icon;
            }
            catch
            {
                return null;
            }
            finally
            {
                DestroyIcon(iconHandle);
            }

        }

        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);
    }
}
