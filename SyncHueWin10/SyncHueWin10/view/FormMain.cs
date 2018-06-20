using SyncHueWin10.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using CSCore.CoreAudioAPI;

namespace SyncHueWin10.view
{
    public partial class FormMain : Form
    {
        System.Timers.Timer timerPeak = new System.Timers.Timer(1000 / 30);
        System.Timers.Timer timerGC = new System.Timers.Timer(5000);
        List<AudioApplication> aps;
        AudioSessionControl2 audioSessionControl2;

        public FormMain()
        {
            InitializeComponent();

            Thread t = new Thread(() =>
            {
                aps = AudioUtil.GetAudioApplications();

                foreach (AudioApplication ap in aps)
                {
                    RadioButton rb = new RadioButton();
                    rb.Text = ap.sessionName;
                    rb.Width = 280;
                    rb.Click += (o, i) =>
                    {
                        Console.WriteLine(ap.sessionName + " on click");
                        (new Thread(() => audioSessionControl2 = AudioUtil.GetAudioSessionControlByPid(ap.pid))).Start();
                    };
                    Console.WriteLine(ap.sessionName + " added");
                    this.Invoke(new Action(() => { radioButtonslayout.Controls.Add(rb); }));
                }
            });
            t.SetApartmentState(ApartmentState.MTA);
            t.Start();

            timerPeak.Elapsed += timer_GetPeakValue;
            timerPeak.Start();
            timerGC.Elapsed += timer_TrigerGC;
            timerGC.Start();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        private void timer_GetPeakValue(object sender, ElapsedEventArgs e)
        {
            if (audioSessionControl2 != null)
            {
                Console.WriteLine(audioSessionControl2.DisplayName + " : " + audioSessionControl2.QueryInterface<AudioMeterInformation>().GetPeakValue());
            }
        }
        private void timer_TrigerGC(object sender, ElapsedEventArgs e)
        {
            if (audioSessionControl2 != null)
            {
                GC.Collect();
            }
        }
    }
}
