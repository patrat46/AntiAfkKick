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
        public static int NextKeyPress = 0;
        static NotifyIcon n = null;
        public static int RandomResults = 0;
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

                DMinMin = int.Parse(ConfigurationManager.AppSettings.Get("DelayMinMinutes"));
                DMaxMin = int.Parse(ConfigurationManager.AppSettings.Get("DelayMaxMinutes"));

                Console.WriteLine(": The value of DelayMinMinutes is " + DMinMin);
                Console.WriteLine(": The value of DelayMaxMinutes is " + DMaxMin);

                MenuItem[] ControlMin = new MenuItem[2];
                MenuItem[] ControlMax = new MenuItem[2];
                MenuItem[] ControlStatic = new MenuItem[3];


                MenuItem Min5 = new MenuItem("Delay 5 mins");
                MenuItem Min10 = new MenuItem("Delay 10 mins");
                
                ControlMin[0] = Min5;
                ControlMin[1] = Min10;

                MenuItem Max15 = new MenuItem("Delay 15 min");
                MenuItem Max25 = new MenuItem("Delay 25 min");

                ControlMax[0] = Max15;
                ControlMax[1] = Max25;

                MenuItem Static5 = new MenuItem("Delay 5 mins");
                MenuItem Static15 = new MenuItem("Delay 15 min");
                MenuItem Static25 = new MenuItem("Delay 25 min");

                ControlStatic[0] = Static5;
                ControlStatic[1] = Static15;
                ControlStatic[2] = Static25;

                Min5.Click += new EventHandler(MyMenuClick);
                Min10.Click += new EventHandler(MyMenuClick);

                Max15.Click += new EventHandler(MyMenuClick);
                Max25.Click += new EventHandler(MyMenuClick);

                Static5.Click += new EventHandler(MyMenuClick);
                Static15.Click += new EventHandler(MyMenuClick);
                Static25.Click += new EventHandler(MyMenuClick);


                void MyMenuClick(Object sender, EventArgs e)
                {
                    //string MinOrMax = sender;

                    if (sender == Min5 || sender == Min10 || sender == Max15 || sender == Max25)
                    {
                        Static5.Checked = false;
                        Static15.Checked = false;
                        Static25.Checked = false;
                    }
                    if (sender == Min5)
                    {
                        DMinMin = 5;
                        Native.Program.AddUpdateAppSettings("DelayMinMinutes", "5");
                    }

                    else if (sender == Min10)
                    {
                        DMinMin = 10;
                        Native.Program.AddUpdateAppSettings("DelayMinMinutes", "10");
                    }
                    if (sender == Max15)
                    {
                        DMaxMin = 15;
                        Native.Program.AddUpdateAppSettings("DelayMaxMinutes", "15");
                    }
                    else if (sender == Max25)
                    {
                        DMaxMin = 25;
                        Native.Program.AddUpdateAppSettings("DelayMaxMinutes", "25");
                    };

                    
                    if (sender == Static5)
                    {
                        Static5.Checked = true;

                        Static15.Checked = false;
                        Static25.Checked = false;

                        DMinMin = 5;
                        DMaxMin = 5;

                    }
                    else if (sender == Static15)
                    {
                        Static15.Checked = true;

                        Static5.Checked = false;
                        Static25.Checked = false;

                        DMinMin = 15;
                        DMaxMin = 15;
                    }
                    else if (sender == Static25)
                    {
                        Static25.Checked = true;

                        Static5.Checked = false;
                        Static15.Checked = false;

                        DMinMin = 25;
                        DMaxMin = 25;
                    };

                    if (sender == Static5 || sender == Static15 || sender == Static25)
                    {
                        Min5.Checked = false;
                        Min10.Checked = false;
                        Max15.Checked = false;
                        Max25.Checked = false;

                        Native.Program.AddUpdateAppSettings("DelayMaxMinutes", DMinMin.ToString());
                        Native.Program.AddUpdateAppSettings("DelayMinMinutes", DMaxMin.ToString());


                    }


                    if (DMinMin == 5)
                    {
                        Min5.Checked = true;
                        Min10.Checked = false;
                    }
                    else if (DMinMin == 10)
                    {
                        Min10.Checked = true;
                        Min5.Checked = false;
                    };
                    if (DMaxMin == 15)
                    {
                        Max15.Checked = true;
                        Max25.Checked = false;
                    }
                    else if (DMaxMin == 25)
                    {
                        Max25.Checked = true;
                        Max15.Checked = false;
                    };

                    Console.WriteLine(": The value of DelayMinMinutes is " + DMinMin);
                    Console.WriteLine(": The value of DelayMaxMinutes is " + DMaxMin);

                };

                int RunType;
                RunType = int.Parse(ConfigurationManager.AppSettings.Get("RunType"));
                Console.WriteLine(": The value of RunType is " + RunType);

                MenuItem[] ControlInactive = new MenuItem[3];

                MenuItem Inactive = new MenuItem("Inactive Only");
                MenuItem AlwaysRun = new MenuItem("Alway Run");
                MenuItem ManuallyRun = new MenuItem("Manually run");

                ControlInactive[0] = Inactive;
                ControlInactive[1] = AlwaysRun;
                ControlInactive[2] = ManuallyRun;

                Inactive.Checked = true;

                if (RunType == 2)
                {
                    AlwaysRun.Checked = true;
                    Inactive.Checked = false;
                    ManuallyRun.Checked = false;
                }
                else if (RunType == 3)
                {
                    ManuallyRun.Checked = true;
                    AlwaysRun.Checked = false;
                    Inactive.Checked = false;
                }
                else if (RunType == 1)
                {
                    Inactive.Checked = true;
                    ManuallyRun.Checked = false;
                    AlwaysRun.Checked = false;
                };


                Inactive.Click += new EventHandler(MyMenuClickInactive);
                AlwaysRun.Click += new EventHandler(MyMenuClickInactive);
                ManuallyRun.Click += new EventHandler(MyMenuClickInactive);

                void MyMenuClickInactive(Object sender, EventArgs e)
                {
                    if (sender == Inactive)
                    {
                        Inactive.Checked = true;
                        AlwaysRun.Checked = false;
                        ManuallyRun.Checked = false;

                        RunType = 1;
                        Native.Program.AddUpdateAppSettings("RunType", "1");
                    }
                    if (sender == AlwaysRun)
                    {

                        AlwaysRun.Checked = true;
                        Inactive.Checked = false;
                        ManuallyRun.Checked = false;

                        RunType = 2;
                        Native.Program.AddUpdateAppSettings("RunType", "2");
                    }
                    if (sender == ManuallyRun)
                    {
                        ManuallyRun.Checked = true;
                        AlwaysRun.Checked = false;
                        Inactive.Checked = false;

                        RunType = 3;
                        Native.Program.AddUpdateAppSettings("RunType", "3");
                    };
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
                        new MenuItem("MinDelay", ControlMin),
                        new MenuItem("Max Delay", ControlMax),
                        new MenuItem("Static Delay", ControlStatic),
                        new MenuItem("Run selection",ControlInactive),
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
                                if (ManuallyRun.Checked == true)
                                {
                                    Console.WriteLine("Opening Manual Click window.");
                                    Application.Run(new AntiAFK());
                                }
                                else
                                {
                                    foreach (var handle in Native.GetGameWindows())
                                    {
                                        //Verifies window is inactive,sends key press.
                                        if (Native.GetForegroundWindow() != handle || Native.IdleTimeFinder.GetIdleTime() > 60 * 1000 | RunType == 2)
                                        {
                                            Console.WriteLine(Environment.TickCount + ": Sending keypress to FFXIV window " + handle.ToString());
                                            Native.Keypress.SendKeycode(handle, Native.Keypress.LControlKey);
                                        }
                                        else
                                        {
                                            Console.WriteLine("No click sent, Idle time on " + handle.ToString() + " instance is :" + Native.IdleTimeFinder.GetIdleTime());
                                            Console.WriteLine("Always send is set to:" + RunType);
                                        }
                                    }

                                }
                                // Randomizes time based off Config file min and max values.
                                Random rnd = new Random();
                                int rInt = rnd.Next(DMinMin, DMaxMin);
                                RandomResults = rInt;
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
