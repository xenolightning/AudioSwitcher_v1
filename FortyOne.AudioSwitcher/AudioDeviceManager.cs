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

        static AudioDeviceManager()
        {
            Controller = new CoreAudioController();
        }

        public static AudioController Controller
        {
            get;
            private set;
        }

    }
}
