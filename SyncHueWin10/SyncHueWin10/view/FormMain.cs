using SyncHueWin10.util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using CSCore.CoreAudioAPI;

namespace SyncHueWin10.view
{
    public partial class FormMain : Form
    {
        System.Timers.Timer timerPeak = new System.Timers.Timer(1000 / 50);
        System.Timers.Timer timerGC = new System.Timers.Timer(1000 * 10);
        List<AudioApplication> aps;
        AudioSessionControl2 audioSessionControl2;
        HueUtil hueUtil = new HueUtil();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            labelHint.Text = "Initializing";

            // init hueUtil
            hueUtil.Init(labelHint);

            // init audio
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

            // init timers
            timerPeak.Elapsed += Timer_GetPeakValue;
            timerPeak.Start();
            timerGC.Elapsed += Timer_TrigerGC;
            timerGC.Start();

        }

        private void Timer_GetPeakValue(object sender, ElapsedEventArgs e)
        {
            if (audioSessionControl2 != null)
            {
                float peakValue = audioSessionControl2.QueryInterface<AudioMeterInformation>().GetPeakValue();
                Console.WriteLine(audioSessionControl2.DisplayName + " : " + peakValue);
                SetBrightness(peakValue);
            }
        }
        private void Timer_TrigerGC(object sender, ElapsedEventArgs e)
        {
            if (audioSessionControl2 != null)
            {
                GC.Collect();
            }
        }

        private void SetBrightness(float level)
        {
            if (hueUtil.isInit)
            {
                hueUtil.SetBrightness(level, 100, 254);
            }
        }
    }
}
