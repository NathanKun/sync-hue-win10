using Q42.HueApi.ColorConverters;
using Q42.HueApi.Models.Groups;
using Q42.HueApi.Streaming;
using Q42.HueApi.Streaming.Extensions;
using Q42.HueApi.Streaming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SyncHueWin10.util
{
    class HueUtil
    {

        private StreamingHueClient client;
        private StreamingGroup entGroup;
        private int hue;
        private const int HUE_STEP = 50;
        public bool isInit = false;

        public HueUtil()
        { }

        public async void Init(Label labelHint)
        {
            client = new StreamingHueClient(ip, key, entertainmentKey);

            //Get the entertainment group
            IReadOnlyList<Group> all = null;
            try
            {
                all = await client.LocalHueClient.GetEntertainmentGroups();
            }
            catch (Exception e)
            {
                labelHint.Text = "Hue init exception: " + e.Message;
                return;
            }
            var group = all.FirstOrDefault();

            if (group == null)
            {
                //throw new Exception("No Entertainment Group found. Create one using the Q42.HueApi.UniversalWindows.Sample");
                labelHint.Text = "No Entertainment Group found";
                return;
            }
            else
            {
                labelHint.Text = $"Using Entertainment Group {group.Id}";
                Console.WriteLine($"Using Entertainment Group {group.Id}");
            }

            //Create a streaming group
            entGroup = new StreamingGroup(group.Locations);

            //Connect to the streaming group
            await client.Connect(group.Id);

            //Start auto updating this entertainment group
            client.AutoUpdate(entGroup, 50);

            //Optional: calculated effects that are placed in the room
            client.AutoCalculateEffectUpdate(entGroup);

            //Optional: Check if streaming is currently active
            var bridgeInfo = await client.LocalHueClient.GetBridgeAsync();
            Console.WriteLine(bridgeInfo.IsStreamingActive ? "Streaming is active" : "Streaming is not active");
            labelHint.Text = bridgeInfo.IsStreamingActive ? "Streaming is active" : "Streaming is not active";

            //Order lights based on position in the room
            var orderedLeft = entGroup.GetLeft().OrderByDescending(x => x.LightLocation.Y).ThenBy(x => x.LightLocation.X);
            var orderedRight = entGroup.GetRight().OrderByDescending(x => x.LightLocation.Y).ThenByDescending(x => x.LightLocation.X);
            var allLightsOrdered = orderedLeft.Concat(orderedRight.Reverse()).ToArray();

            var allLightsReverse = allLightsOrdered.ToList();
            allLightsReverse.Reverse();

            Random rnd = new Random();
            hue = rnd.Next(0, 65535);

            entGroup.SetState(HueToRGB(hue, 1, 1), 1, TimeSpan.FromMilliseconds(0));

            isInit = true;
        }

        /// <summary>
        /// Set group brightness by percentage with min and max
        /// </summary>
        /// <param name="level">from 0.0 to 1.0</param>
        /// <param name="min">minimum brightness, from 0.0 to 1.0<</param>
        /// <param name="max">maximum brightness, from 0.0 to 1.0<</param>
        public void SetBrightness(double level, double min, double max)
        {
            NextHue();
            double brightness = min + (max - min) * level;
            entGroup.SetState(HueToRGB(hue, 255, 255), brightness, TimeSpan.FromMilliseconds(0));
            //if (brightness != min) Console.WriteLine("set brightness : " + brightness);
        }

        public void Stop()
        {
            entGroup.SetState(new RGBColor("FFFFFF"), 1, TimeSpan.FromMilliseconds(0));
            System.Threading.Timer timer = null;
            timer = new System.Threading.Timer((obj) =>
            {
                client.Close();
                timer.Dispose();
            },
                        null, 200, System.Threading.Timeout.Infinite);
        }

        private void NextHue()
        {
            if (hue <= 65535 - HUE_STEP)
            {
                hue = hue + HUE_STEP;
            }
            else
            {
                hue = 0;
            }
        }

        private RGBColor HueToRGB(double hue, double saturation, double brightness)
        {

            //Convert Hue into degrees for HSB
            hue = hue / 182.04;
            //Bri and Sat must be values from 0-1 (~percentage)
            brightness = brightness / 255.0;
            saturation = saturation / 255.0;

            double r = 0;
            double g = 0;
            double b = 0;

            if (saturation == 0)
            {
                r = g = b = brightness;
            }
            else
            {
                // the color wheel consists of 6 sectors.
                double sectorPos = hue / 60.0;
                int sectorNumber = (int)(Math.Floor(sectorPos));
                // get the fractional part of the sector
                double fractionalSector = sectorPos - sectorNumber;

                // calculate values for the three axes of the color. 
                double p = brightness * (1.0 - saturation);
                double q = brightness * (1.0 - (saturation * fractionalSector));
                double t = brightness * (1.0 - (saturation * (1 - fractionalSector)));

                // assign the fractional colors to r, g, and b based on the sector the angle is in.
                switch (sectorNumber)
                {
                    case 0:
                        r = brightness;
                        g = t;
                        b = p;
                        break;
                    case 1:
                        r = q;
                        g = brightness;
                        b = p;
                        break;
                    case 2:
                        r = p;
                        g = brightness;
                        b = t;
                        break;
                    case 3:
                        r = p;
                        g = q;
                        b = brightness;
                        break;
                    case 4:
                        r = t;
                        g = p;
                        b = brightness;
                        break;
                    case 5:
                        r = brightness;
                        g = p;
                        b = q;
                        break;
                }
            }

            //Check if any value is out of byte range
            if (r < 0)
            {
                r = 0;
            }
            if (g < 0)
            {
                g = 0;
            }
            if (b < 0)
            {
                b = 0;
            }
            return new RGBColor(r, g, b);
        }

    }
}
