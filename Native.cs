﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace AntiAfkKick
{
    class Native
    {
        internal struct LASTINPUTINFO
        {
            public uint cbSize;

            public uint dwTime;
        }

        /// <summary>
        /// Helps to find the idle time, (in milliseconds) spent since the last user input
        /// </summary>
        public class IdleTimeFinder
        {
            [DllImport("User32.dll")]
            private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

            [DllImport("Kernel32.dll")]
            private static extern uint GetLastError();

            public static uint GetIdleTime()
            {
                LASTINPUTINFO lastInPut = new LASTINPUTINFO();
                lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
                GetLastInputInfo(ref lastInPut);

                return ((uint)Environment.TickCount - lastInPut.dwTime);
            }
            /// <summary>
            /// Get the Last input time in milliseconds
            /// </summary>
            /// <returns></returns>
            public static long GetLastInputTime()
            {
                LASTINPUTINFO lastInPut = new LASTINPUTINFO();
                lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
                if (!GetLastInputInfo(ref lastInPut))
                {
                    throw new Exception(GetLastError().ToString());
                }
                return lastInPut.dwTime;
            }
        }


        public static IEnumerable<IntPtr> GetGameWindows()
        {
            var hwnd = IntPtr.Zero;
            while (true)
            {
                hwnd = FindWindowEx(IntPtr.Zero, hwnd, "FFXIVGAME", null);
                if (hwnd == IntPtr.Zero) yield break;
                yield return hwnd;
            }
        }

        [DllImport("user32.dll")]
        static extern IntPtr FindWindowEx(IntPtr hWndParent, IntPtr hWndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        internal static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool AllocConsole();



        public class Keypress
        {
            public const int LControlKey = 162;
            public const int Space = 32;

            const uint WM_KEYUP = 0x101;
            const uint WM_KEYDOWN = 0x100;

            [DllImport("user32.dll")]
            private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

            public static void SendKeycode(IntPtr hwnd, int keycode)
            {
                SendMessage(hwnd, WM_KEYDOWN, (IntPtr)keycode, (IntPtr)0);
                Thread.Sleep(200);
                SendMessage(hwnd, WM_KEYUP, (IntPtr)keycode, (IntPtr)0);
            }
        }

        public class Program
        {

            static void ReadAllSettings()
            {
                try
                {
                    var appSettings = ConfigurationManager.AppSettings;

                    if (appSettings.Count == 0)
                    {
                        Console.WriteLine("AppSettings is empty.");
                    }
                    else
                    {
                        foreach (var key in appSettings.AllKeys)
                        {
                            Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                        }
                    }
                }
                catch (ConfigurationErrorsException)
                {
                    Console.WriteLine("Error reading app settings");
                }
            }



            static void ReadSetting(string key)
            {
                try
                {
                    var appSettings = ConfigurationManager.AppSettings;
                    string result = appSettings[key] ?? "Not Found";
                    Console.WriteLine(result);
                }
                catch (ConfigurationErrorsException)
                {
                    Console.WriteLine("Error reading app settings");
                }
            }

            public static void AddUpdateAppSettings(string key, string value)
            {
                try
                {
                    var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var settings = configFile.AppSettings.Settings;
                    if (settings[key] == null)
                    {
                        settings.Add(key, value);
                    }
                    else
                    {
                        settings[key].Value = value;
                    }
                    configFile.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                }
                catch (ConfigurationErrorsException)
                {
                    Console.WriteLine("Error writing app settings");
                }
            }
            //internal static extern string AddUpdateAppSettings(string key, string value);
        }
    }

}
