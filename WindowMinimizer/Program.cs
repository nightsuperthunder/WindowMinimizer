using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowMinimizer {
    internal static class Program {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [STAThread]
        private static void Main() {
            var processesByName = Process.GetProcessesByName(Environment.GetCommandLineArgs()[0]);

            if (processesByName.Length == 0)
                return;
            foreach (var process in processesByName)
                ShowWindow(process.MainWindowHandle, 6);
        }
    }
}