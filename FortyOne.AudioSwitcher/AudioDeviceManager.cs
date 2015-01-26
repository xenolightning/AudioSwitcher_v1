using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;

namespace FortyOne.AudioSwitcher
{
    public static class AudioDeviceManager
    {
        private static CoreAudioController _instance;


        public static AudioController Controller
        {
            get
            {
                //Lazy initialization of Controller
                return _instance ?? (_instance = new CoreAudioController());
            }
        }

    }
}
