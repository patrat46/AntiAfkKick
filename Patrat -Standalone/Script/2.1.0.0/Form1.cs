using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AntiAfkKick
{

    public partial class AntiAFK : Form
    {
        int RemainingTime;
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]

        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public AntiAFK()
        {
            InitializeComponent();
            Console.WriteLine("Manual Click window is open.");

            RemainingTime = ((30 - AntiAfkKick.RandomResults) * 60);
            progressBar1.Increment((30*60) - RemainingTime);
        }
        
        private void AntiAFK_Load(object sender, EventArgs e)

        {

            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
            Console.WriteLine("Set Manual Click window to top.");
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            foreach (var handle in Native.GetGameWindows())
            {
                Native.Keypress.SendKeycode(handle, Native.Keypress.LControlKey);
                Console.WriteLine(Environment.TickCount + ": Sending keypress to FFXIV window " + handle.ToString());
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
            //Dispose(); Environment.Exit(0);
            //delegate { AntiAfkKick.n.Dispose(); Environment.Exit(0); };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            this.progressBar1.Increment(1);
            if(RemainingTime > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                int minsleft = (RemainingTime / 60);
                int secondsleft = (RemainingTime - (minsleft * 60) );
                RemainingTime = RemainingTime - 1;
                TimeRemaining.Text = "Time till Kicked:" + minsleft + "Min(s)" + secondsleft + " Sec(s)";
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                TimeRemaining.Text = "Time's up!";
                MessageBox.Show("If you have been kicked due to inactivity, Sorry.", "Sorry.");

            }

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

            
            progressBar1.Step = 60;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}
