using Q42.HueApi.ColorConverters;
using Q42.HueApi.Models.Groups;
using Q42.HueApi.Streaming;
using Q42.HueApi.Streaming.Extensions;
using Q42.HueApi.Streaming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncHueWin10.util
{
    class HueUtil
    {

        private StreamingHueClient client;
        private StreamingGroup entGroup;
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

            //Optional: Check if streaming is currently active
            var bridgeInfo = await client.LocalHueClient.GetBridgeAsync();
            Console.WriteLine(bridgeInfo.IsStreamingActive ? "Streaming is active" : "Streaming is not active");
            labelHint.Text = bridgeInfo.IsStreamingActive ? "Streaming is active" : "Streaming is not active";
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
            double brightness = min + (max - min) * level;
            //entGroup.SetBrightness(brightness);
            entGroup.SetState(new RGBColor("FF0000"), brightness);
            if (brightness != min) Console.WriteLine("set brightness : " + brightness);
        }

        public void Stop()
        {
            client.Close();
        }
    }
}
