using System.Runtime.InteropServices;
using FortyOne.AudioSwitcher.SoundLibrary.Audio;

namespace CoreAudio.Interfaces
{
    [Guid("f8679f50-850a-41cf-9c72-430f290290c8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPolicyConfig
    {
        [PreserveSig]
        int GetMixFormat();

        [PreserveSig]
        int GetDeviceFormat();

        [PreserveSig]
        int SetDeviceFormat();

        [PreserveSig]
        int GetProcessingPeriod();

        [PreserveSig]
        int SetProcessingPeriod();

        [PreserveSig]
        int GetShareMode();

        [PreserveSig]
        int SetShareMode();

        [PreserveSig]
        int GetPropertyValue();

        [PreserveSig]
        int SetPropertyValue();

        [PreserveSig]
        int SetDefaultEndpoint([MarshalAs(UnmanagedType.LPWStr)] string wszDeviceId, ERole eRole);

        [PreserveSig]
        int SetEndpointVisibility();
    }
}