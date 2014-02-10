using CoreAudio.Interfaces;
using FortyOne.AudioSwitcher.SoundLibrary.Audio;

namespace CoreAudio
{
    internal class CPolicyConfigClient
    {
        private readonly IPolicyConfig _policyConfigClient = (new _CPolicyConfigClient() as IPolicyConfig);

        public static int SetDefaultDeviceStatic(string deviceID, ERole role)
        {
            return new CPolicyConfigClient().SetDefaultDevice(deviceID, role);
        }

        public int SetDefaultDevice(string deviceID, ERole role)
        {
            _policyConfigClient.SetDefaultEndpoint(deviceID, role);
            return 0;
        }
    }
}