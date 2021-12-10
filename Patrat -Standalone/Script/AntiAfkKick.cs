using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace AntiAfkKick
{
    class AntiAfkKick
    {
        static int NextKeyPress = 0;
        static NotifyIcon n = null;
        private static string appGuid = "92f42221-51a5-4753-9e91-84aeea157d17";

        static void Main(string[] args)
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                //Checks if already running
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Application already running");
                    return;
                }
                //Creates Icon in System Tray. 
                Icon icon;
                try
                {
                    icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                }
                catch (Exception)
                {
                    icon = SystemIcons.Application;
                }
                // Pulls in Configuration file values
                int DMinMin;
                int DMaxMin;
                DMinMin = int.Parse(Native.Program.ReadSetting("DelayMinMinutes"));
                DMaxMin = int.Parse(Native.Program.ReadSetting("DelayMaxMinutes"));
                Console.WriteLine(": The value of DelayMinMinutes is " + DMinMin);
                Console.WriteLine(": The value of DelayMaxMinutes is " + DMaxMin);



                MenuItem[] ControlMin = new MenuItem[2];
                MenuItem[] ControlMax = new MenuItem[2];
                MenuItem Min5 = new MenuItem("Delay 5 mins");
                MenuItem Min10 = new MenuItem("Delay 10 mins");
                MenuItem Max15 = new MenuItem("Delay 15 min");
                MenuItem Max25 = new MenuItem("Delay 25 min");
                ControlMin[0] = Min5;
                ControlMin[1] = Min10;
                ControlMax[0] = Max15;
                ControlMax[1] = Max25;


                if (DMinMin == 5)
                {
                    Min5.Checked = true;
                }
                else if (DMinMin == 10)
                {
                    Min10.Checked = true;
                };

                if (DMaxMin == 15)
                {
                    Max15.Checked = true;
                }
                else if (DMaxMin == 25)
                {
                    Max25.Checked = true;
                };

                Min5.Click += new EventHandler(MyMenuClick);
                Min10.Click += new EventHandler(MyMenuClick);
                Max15.Click += new EventHandler(MyMenuClick);
                Max25.Click += new EventHandler(MyMenuClick);


                void MyMenuClick(Object sender, EventArgs e)
                {
                    if (sender == Min5)
                    {
                        Min5.Checked = true;
                        Min10.Checked = false;

                        DMinMin = 5;
                        Native.Program.AddUpdateAppSettings("DelayMinMinutes", "5");
                    }

                    if (sender == Min10)
                    {

                        Min10.Checked = true;
                        Min5.Checked = false;

                        DMinMin = 10;
                        Native.Program.AddUpdateAppSettings("DelayMinMinutes", "10");
                    }

                    if (sender == Max15)
                    {
                        Max15.Checked = true;
                        Max25.Checked = false;

                        DMaxMin = 15;
                        Native.Program.AddUpdateAppSettings("DelayMaxMinutes", "15");
                    }

                    if (sender == Max25)
                    {

                        Max25.Checked = true;
                        Max15.Checked = false;

                        DMaxMin = 25;
                        Native.Program.AddUpdateAppSettings("DelayMaxMinutes", "25");
                    }
                    Console.WriteLine(": The value of DelayMinMinutes is " + DMinMin);
                    Console.WriteLine(": The value of DelayMaxMinutes is " + DMaxMin);
                };

                bool SendClickAlways = false;
                SendClickAlways = bool.Parse(ConfigurationManager.AppSettings.Get("SendClickAlways"));
                Console.WriteLine(": The value of SendClickAlways is " + SendClickAlways);

                MenuItem[] ControlInactive = new MenuItem[2];
                MenuItem Inactive = new MenuItem("Inactive Only");
                MenuItem AlwaysRun = new MenuItem("Alway Run");
                ControlInactive[0] = Inactive;
                ControlInactive[1] = AlwaysRun;

                Inactive.Checked = true;

                if (SendClickAlways)
                {
                    AlwaysRun.Checked = true;
                    Inactive.Checked = false;
                };


                Inactive.Click += new EventHandler(MyMenuClickInactive);
                AlwaysRun.Click += new EventHandler(MyMenuClickInactive);

                void MyMenuClickInactive(Object sender, EventArgs e)
                {
                    if (sender == Inactive)
                    {
                        Inactive.Checked = true;
                        AlwaysRun.Checked = false;

                        SendClickAlways = false;
                        Native.Program.AddUpdateAppSettings("SendClickAlways", "false");
                    }

                    if (sender == AlwaysRun)
                    {

                        AlwaysRun.Checked = true;
                        Inactive.Checked = false;

                        SendClickAlways = true;
                        Native.Program.AddUpdateAppSettings("SendClickAlways", "true");
                    }
                };


                n = new NotifyIcon
                {
                    Icon = icon,
                    Visible = true,
                    Text = "Anti AFK Kick next key stroke in: " + 1 + (NextKeyPress - Environment.TickCount / 1000 / 60) + " minutes.",
                    ContextMenu = new ContextMenu(new MenuItem[]
                    {
                        new MenuItem("Anti AFK Kick") { Enabled = false },
                        new MenuItem("-"),
                        new MenuItem("Report issue", delegate { Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = "https://github.com/Eternita-S/AntiAfkKick/issues" }); }),
                        new MenuItem("Min Delay", ControlMin),
                        new MenuItem("Max Delay", ControlMax),
                        new MenuItem("Run While",ControlInactive),
                        new MenuItem("-"),
                        new MenuItem("Exit", delegate { n.Dispose(); Environment.Exit(0); }),
                    })
                };


                new Thread((ThreadStart)delegate
                {
                    while (true)
                    {
                        Thread.Sleep(10000);
                        //Console.WriteLine("Cycle begins");
                        Console.WriteLine(": The current TickCount is at " + Environment.TickCount / 1000 / 60 + " next key stroke in " + (NextKeyPress - Environment.TickCount) / 1000 / 60 + " minutes.");

                        try
                        {
                            if (Environment.TickCount > NextKeyPress)
                            {
                                foreach (var handle in Native.GetGameWindows())
                                {
                                    //Verifies window is inactive,sends key press.
                                    if (Native.GetForegroundWindow() != handle || Native.IdleTimeFinder.GetIdleTime() > 60 * 1000 | SendClickAlways)
                                    {
                                        Console.WriteLine(Environment.TickCount + ": Sending keypress to FFXIV window " + handle.ToString());
                                        Native.Keypress.SendKeycode(handle, Native.Keypress.LControlKey);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No click sent, Idle time on " + handle.ToString() + " instance is :" + Native.IdleTimeFinder.GetIdleTime());
                                        Console.WriteLine("Always send is set to:" + SendClickAlways);
                                    }

                                }
                                // Randomizes time based off Config file min and max values.
                                Random rnd = new Random();
                                int rInt = rnd.Next(DMinMin, DMaxMin);
                                Console.WriteLine(": The value of random is " + rInt);
                                NextKeyPress = Environment.TickCount + rInt * 60 * 1000;

                            }
                            n.Text = "Anti AFK Kick. Next key stroke in: " + (1 + ((NextKeyPress - Environment.TickCount) / 1000 / 60)) + " minute(s).";
                        }
                        catch (Exception) { }
                    }
                }).Start();
                Application.Run();
            }
        }

        private static void EventHandler(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
