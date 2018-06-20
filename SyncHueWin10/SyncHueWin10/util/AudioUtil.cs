using CSCore.CoreAudioAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncHueWin10.util
{

    class AudioApplication
    {
        public string sessionId;
        public int pid;
        public string sessionName;
    }

    class AudioUtil
    {

        public static List<AudioApplication> GetAudioApplications()
        {
            var aps = new List<AudioApplication>();

            using (var sessionManager = GetDefaultAudioSessionManager2(DataFlow.Render))
            {
                using (var sessionEnumerator = sessionManager.GetSessionEnumerator())
                {
                    foreach (var session in sessionEnumerator)
                    {
                        using (var audioSessionControl2 = session.QueryInterface<AudioSessionControl2>())
                        {
                            var process = audioSessionControl2.Process;

                            string sessionid = audioSessionControl2.SessionIdentifier;
                            int pid = audioSessionControl2.ProcessID;
                            string name = audioSessionControl2.DisplayName;
                            if (process != null)
                            {
                                if (name == "") { name = process.MainWindowTitle; }
                                if (name == "") { name = process.ProcessName; }
                            }
                            if (name == "") { name = "--unnamed--"; }

                            AudioApplication ap = new AudioApplication();
                            ap.pid = pid;
                            ap.sessionId = sessionid;
                            ap.sessionName = name;

                            aps.Add(ap);
                        }
                    }
                }
            }

            return aps;
        }

        /// <summary>
        /// Get the application's audio peak value by it's pid
        /// </summary>
        /// <param name="targetPid">Application's pid</param>
        /// <returns>Application's audio peak value</returns>
        public static float GetPeakValueByPid(int targetPid)
        {
            using (var sessionManager = GetDefaultAudioSessionManager2(DataFlow.Render))
            {
                using (var sessionEnumerator = sessionManager.GetSessionEnumerator())
                {
                    foreach (var session in sessionEnumerator)
                    {
                        using (var audioSessionControl2 = session.QueryInterface<AudioSessionControl2>())
                        {
                            int pid = audioSessionControl2.ProcessID;
                            if (pid == targetPid)
                            {
                                using (var audioMeterInformation = session.QueryInterface<AudioMeterInformation>())
                                {
                                    return audioMeterInformation.GetPeakValue();
                                }
                            } // else continue
                        }
                    }
                }
            }
            return 0;
        }


        public static AudioSessionControl2 GetAudioSessionControlByPid(int targetPid)
        {
            using (var sessionManager = GetDefaultAudioSessionManager2(DataFlow.Render))
            {
                using (var sessionEnumerator = sessionManager.GetSessionEnumerator())
                {
                    foreach (var session in sessionEnumerator)
                    {
                        var audioSessionControl2 = session.QueryInterface<AudioSessionControl2>();
                        int pid = audioSessionControl2.ProcessID;
                        if (pid == targetPid)
                        {
                            return audioSessionControl2;
                        }
                        else
                        {
                            audioSessionControl2.Dispose();
                        }

                    }
                }
            }
            return null;
        }

        private static AudioSessionManager2 GetDefaultAudioSessionManager2(DataFlow dataFlow)
        {
            using (var enumerator = new MMDeviceEnumerator())
            {
                using (var device = enumerator.GetDefaultAudioEndpoint(dataFlow, Role.Multimedia))
                {
                    Console.WriteLine("DefaultDevice: " + device.FriendlyName);
                    var sessionManager = AudioSessionManager2.FromMMDevice(device);
                    return sessionManager;
                }
            }
        }
    }
}
