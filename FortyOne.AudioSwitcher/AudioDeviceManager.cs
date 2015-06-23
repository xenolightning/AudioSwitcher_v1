using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;

namespace FortyOne.AudioSwitcher
{
    public static class AudioDeviceManager
    {
        private static IAudioController _instance;

        public static IAudioController Controller
        {
            get
            {
                //Lazy initialization of Controller
                return _instance ?? (_instance = new CoreAudioController());
            }
        }
    }
}