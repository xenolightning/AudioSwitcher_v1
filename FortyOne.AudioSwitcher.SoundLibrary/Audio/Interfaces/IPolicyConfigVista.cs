using System.Runtime.InteropServices;
using FortyOne.AudioSwitcher.SoundLibrary.Audio;

namespace CoreAudio.Interfaces
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("568b9108-44bf-40b4-9006-86afe5b5a620")]
    internal interface IPolicyConfigVista
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