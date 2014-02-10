/*
  LICENSE
  -------
  Copyright (C) 2007-2010 Ray Molenkamp

  This source code is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this source code or the software it produces.

  Permission is granted to anyone to use this source code for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this source code must not be misrepresented; you must not
     claim that you wrote the original source code.  If you use this source code
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original source code.
  3. This notice may not be removed or altered from any source distribution.
*/

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using FortyOne.AudioSwitcher.SoundLibrary.Audio.Interfaces;

namespace FortyOne.AudioSwitcher.SoundLibrary.Audio
{
    internal class MMDevice
    {
        #region Variables

        private readonly IMMDevice _RealDevice;
        private AudioEndpointVolume _AudioEndpointVolume;
        private AudioMeterInformation _AudioMeterInformation;
        private AudioSessionManager _AudioSessionManager;
        private PropertyStore _PropertyStore;

        #endregion

        #region Guids

        private static Guid IID_IAudioMeterInformation = typeof (IAudioMeterInformation).GUID;
        private static Guid IID_IAudioEndpointVolume = typeof (IAudioEndpointVolume).GUID;
        private static Guid IID_IAudioSessionManager = typeof (IAudioSessionManager2).GUID;

        #endregion

        #region Init

        private void GetPropertyInformation()
        {
            try
            {
                IPropertyStore propstore;
                Marshal.ThrowExceptionForHR(_RealDevice.OpenPropertyStore(EStgmAccess.STGM_READ, out propstore));
                _PropertyStore = new PropertyStore(propstore);
            }
            catch
            {
                _PropertyStore = null;
            }
        }

        private void GetAudioSessionManager()
        {
            try
            {
                object result;
                Marshal.ThrowExceptionForHR(_RealDevice.Activate(ref IID_IAudioSessionManager, CLSCTX.ALL, IntPtr.Zero,
                    out result));
                _AudioSessionManager = new AudioSessionManager(result as IAudioSessionManager2);
            }
            catch
            {
                _AudioSessionManager = null;
            }
        }

        private void GetAudioMeterInformation()
        {
            try
            {
                object result;
                Marshal.ThrowExceptionForHR(_RealDevice.Activate(ref IID_IAudioMeterInformation, CLSCTX.ALL, IntPtr.Zero,
                    out result));
                _AudioMeterInformation = new AudioMeterInformation(result as IAudioMeterInformation);
            }
            catch
            {
                _AudioMeterInformation = null;
            }
        }

        private void GetAudioEndpointVolume()
        {
            try
            {
                object result;
                Marshal.ThrowExceptionForHR(_RealDevice.Activate(ref IID_IAudioEndpointVolume, CLSCTX.ALL, IntPtr.Zero,
                    out result));
                _AudioEndpointVolume = new AudioEndpointVolume(result as IAudioEndpointVolume);
            }
            catch
            {
                _AudioEndpointVolume = null;
            }
        }

        #endregion

        #region Properties

        public AudioSessionManager AudioSessionManager
        {
            get
            {
                if (_AudioSessionManager == null)
                    GetAudioSessionManager();

                return _AudioSessionManager;
            }
        }

        public AudioMeterInformation AudioMeterInformation
        {
            get
            {
                if (_AudioMeterInformation == null)
                    GetAudioMeterInformation();

                return _AudioMeterInformation;
            }
        }

        public AudioEndpointVolume AudioEndpointVolume
        {
            get
            {
                if (_AudioEndpointVolume == null)
                    GetAudioEndpointVolume();

                return _AudioEndpointVolume;
            }
        }

        public PropertyStore Properties
        {
            get
            {
                if (_PropertyStore == null)
                    GetPropertyInformation();
                return _PropertyStore;
            }
        }

        [Obfuscation]
        public string DeviceDescription
        {
            get
            {
                try
                {
                    if (_PropertyStore == null)
                        GetPropertyInformation();
                    if (_PropertyStore.Contains(PKEY.PKEY_Device_DeviceDescription))
                    {
                        return (string) _PropertyStore[PKEY.PKEY_Device_DeviceDescription].Value;
                    }
                    return "Unknown";
                }
                catch
                {
                    return "Unknown";
                }
            }
        }

        [Obfuscation]
        public string DeviceName
        {
            get
            {
                try
                {
                    if (_PropertyStore == null)
                        GetPropertyInformation();
                    if (_PropertyStore.Contains(PKEY.PKEY_Device_DeviceName))
                    {
                        return (string) _PropertyStore[PKEY.PKEY_Device_DeviceName].Value;
                    }
                    return "Unknown";
                }
                catch
                {
                    return "Unknown";
                }
            }
        }

        [Obfuscation]
        public string FriendlyName
        {
            get
            {
                try
                {
                    if (_PropertyStore == null)
                        GetPropertyInformation();
                    if (_PropertyStore.Contains(PKEY.PKEY_Device_FriendlyName))
                    {
                        return (string) _PropertyStore[PKEY.PKEY_Device_FriendlyName].Value;
                    }
                    return "Unknown";
                }
                catch
                {
                    return "Unknown";
                }
            }
        }

        [Obfuscation]
        public string IconPath
        {
            get
            {
                try
                {
                    if (_PropertyStore == null)
                        GetPropertyInformation();
                    if (_PropertyStore.Contains(PKEY.PKEY_Device_IconPath))
                    {
                        return (string) _PropertyStore[PKEY.PKEY_Device_IconPath].Value;
                    }
                    return "Unknown";
                }
                catch
                {
                    return "Unknown";
                }
            }
        }

        [Obfuscation]
        public string FullName
        {
            get
            {
                try
                {
                    if (_PropertyStore == null)
                        GetPropertyInformation();
                    if (_PropertyStore.Contains(PKEY.PKEY_Device_FriendlyName) &&
                        _PropertyStore.Contains(PKEY.PKEY_DeviceInterface_FriendlyName))
                    {
                        return _PropertyStore[PKEY.PKEY_Device_FriendlyName].Value + " (" +
                               _PropertyStore[PKEY.PKEY_DeviceInterface_FriendlyName].Value + ")";
                    }
                    return "Unknown";
                }
                catch
                {
                    return "Unknown";
                }
            }
        }

        [Obfuscation]
        public string ID
        {
            get
            {
                try
                {
                    string Result;
                    Marshal.ThrowExceptionForHR(_RealDevice.GetId(out Result));
                    return Result;
                }
                catch
                {
                    return Guid.NewGuid().ToString(); //Random unique string
                }
            }
        }

        [Obfuscation]
        public EDataFlow DataFlow
        {
            get
            {
                try
                {
                    EDataFlow Result;
                    var ep = _RealDevice as IMMEndpoint;
                    ep.GetDataFlow(out Result);
                    return Result;
                }
                catch
                {
                    return EDataFlow.None;
                }
            }
        }

        [Obfuscation]
        public EDeviceState State
        {
            get
            {
                try
                {
                    EDeviceState Result;
                    Marshal.ThrowExceptionForHR(_RealDevice.GetState(out Result));
                    return Result;
                }
                catch
                {
                    return EDeviceState.DEVICE_STATE_NOTPRESENT;
                }
            }
        }

        #endregion

        #region Constructor

        internal MMDevice(IMMDevice realDevice)
        {
            _RealDevice = realDevice;
        }

        internal MMDevice()
        {
            _RealDevice = null;
        }

        #endregion
    }
}