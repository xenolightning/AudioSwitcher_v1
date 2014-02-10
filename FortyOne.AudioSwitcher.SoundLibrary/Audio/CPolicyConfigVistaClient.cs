using CoreAudio.Interfaces;
using FortyOne.AudioSwitcher.SoundLibrary.Audio;

namespace CoreAudio
{
    internal class CPolicyConfigVistaClient
    {
        private readonly IPolicyConfigVista _policyConfigVistaClient =
            (new _CPolicyConfigVistaClient() as IPolicyConfigVista);

        public static int SetDefaultDeviceStatic(string deviceID, ERole role)
        {
            return new CPolicyConfigVistaClient().SetDefaultDevice(deviceID, role);
        }

        public int SetDefaultDevice(string deviceID, ERole role)
        {
            _policyConfigVistaClient.SetDefaultEndpoint(deviceID, role);
            return 0;
        }
    }
}