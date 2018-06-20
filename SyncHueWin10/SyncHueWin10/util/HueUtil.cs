using Q42.HueApi.Streaming;
using Q42.HueApi.Streaming.Extensions;
using Q42.HueApi.Streaming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncHueWin10.util
{
    class HueUtil
    {
        private string ip = "";
        private string key = "";
        private string entertainmentKey = "";

        private StreamingGroup entGroup;
        public bool isInit = false;

        public HueUtil()
        { }

        public async void Init()
        {
            StreamingHueClient client = new StreamingHueClient(ip, key, entertainmentKey);

            //Get the entertainment group
            var all = await client.LocalHueClient.GetEntertainmentGroups();
            var group = all.FirstOrDefault();

            if (group == null)
                throw new Exception("No Entertainment Group found. Create one using the Q42.HueApi.UniversalWindows.Sample");
            else
                Console.WriteLine($"Using Entertainment Group {group.Id}");

            //Create a streaming group
            entGroup = new StreamingGroup(group.Locations);

            //Connect to the streaming group
            await client.Connect(group.Id);

            //Start auto updating this entertainment group
            client.AutoUpdate(entGroup, 50);

            //Optional: Check if streaming is currently active
            var bridgeInfo = await client.LocalHueClient.GetBridgeAsync();
            Console.WriteLine(bridgeInfo.IsStreamingActive ? "Streaming is active" : "Streaming is not active");

            isInit = true;
        }

        public void SetBrightness(int brigntness)
        {
            entGroup.SetBrightness(brigntness);
        }

        /// <summary>
        /// Set group brightness by percentage with min and max
        /// </summary>
        /// <param name="level">from 0.0 to 1.0</param>
        /// <param name="min">minimum brightness, between 0 and 254</param>
        /// <param name="max">maximum brightness, between 0 and 254</param>
        public void SetBrightness(float level, int min, int max)
        {
            entGroup.SetBrightness(min + (max - min) * level);
        }
    }
}
