using FortyOne.AudioSwitcher.SoundLibrary;

namespace FortyOne.AudioSwitcher
{
    public class AudioDeviceUIWrapper
    {
        private readonly AudioDevice Device;

        public AudioDeviceUIWrapper(AudioDevice ad)
        {
            Device = ad;
        }

        public string DeviceName
        {
            get { return Device.DeviceName; }
        }

        public string DeviceDescription
        {
            get { return Device.DeviceName; }
        }

        public string State
        {
            get
            {
                switch (Device.State)
                {
                    case AudioDeviceState.Active:
                        return "Ready";
                    case AudioDeviceState.Disabled:
                        return "Disabled";
                    case AudioDeviceState.Unplugged:
                        return "Not Plugged In";
                }
                return "Unknown";
            }
        }
    }
}