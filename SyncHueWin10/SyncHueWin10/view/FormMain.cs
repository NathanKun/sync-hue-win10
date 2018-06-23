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
        System.Timers.Timer timerPeak = new System.Timers.Timer(1000 / 9);
        System.Timers.Timer timerGC = new System.Timers.Timer(1000 * 10);
        List<AudioApplication> aps;
        AudioSessionControl2 audioSessionControl2;
        HueUtil hueUtil = new HueUtil();
        double brightnessMin = 0;
        double brightnessMax = 1;
        int saturationValue = 90;

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
                    RadioButton rb = new RadioButton
                    {
                        Text = ap.sessionName,
                        Width = 280
                    };
                    rb.Click += (o, i) =>
                    {
                        (new Thread(() => audioSessionControl2 = AudioUtil.GetAudioSessionControlByPid(ap.pid))).Start();
                    };
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

            // trackbar saturation
            trackBarSaturation.Minimum = 0;
            trackBarSaturation.Maximum = 255;
            trackBarSaturation.Value = saturationValue;
            labelSaturation.Text = "Saturation: " + trackBarSaturation.Value;
            trackBarSaturation.ValueChanged += OnTrackBarSaturationChanged;

        }

        private void OnTrackBarSaturationChanged(object sender, EventArgs e)
        {
            labelSaturation.Text = "Saturation: " + trackBarSaturation.Value;
            saturationValue = trackBarSaturation.Value;
        }

        private void Timer_GetPeakValue(object sender, ElapsedEventArgs e)
        {
            if (audioSessionControl2 != null)
            {
                float peakValue = audioSessionControl2.QueryInterface<AudioMeterInformation>().GetPeakValue();
                if(peakValue != 0) Console.WriteLine(audioSessionControl2.DisplayName + " : " + peakValue);
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
                hueUtil.SetBrightnessAndSaturation(level, brightnessMin, brightnessMax, saturationValue);
            }
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            audioSessionControl2 = null;
            if (hueUtil.isInit) hueUtil.Stop();
            Thread.Sleep(500);
        }

        private void ButtonSetRange_Click(object sender, EventArgs e)
        {
            rangerBrightness.QueryRange(out string strRange1, out string strRange2);
            brightnessMin = double.Parse(strRange1) / 100;
            brightnessMax = double.Parse(strRange2) / 100;
        }
    }
}
