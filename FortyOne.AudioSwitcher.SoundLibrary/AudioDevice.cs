using System;
using FortyOne.AudioSwitcher.SoundLibrary.Audio;
using FortyOne.AudioSwitcher.SoundLibrary.Audio.Interfaces;

namespace FortyOne.AudioSwitcher.SoundLibrary
{
    public partial class AudioDevice : IMMNotificationClient
    {
        /// <summary>
        ///     Internal constructor. All accessors to devices should be done through the manager class
        /// </summary>
        /// <param name="device"></param>
        internal AudioDevice(MMDevice device)
        {
            if (device == null)
                throw new Exception("Device cannot be null. Something bad went wrong");
            Device = device;
        }

        /// <summary>
        ///     Unique identifier for this device
        /// </summary>
        public string ID
        {
            get { return Device.ID; }
        }

        public string DeviceDescription
        {
            get
            {
                if (Device == null)
                    return "Unknown";
                return Device.DeviceDescription;
            }
        }

        public string DeviceName
        {
            get
            {
                if (Device == null)
                    return "Unknown";
                return Device.DeviceName;
            }
        }

        public string FullName
        {
            get
            {
                if (Device != null)
                    return Device.FullName;
                return "Unknown Device";
            }
        }

        /// <summary>
        ///     Returns the name of the device icon embedded into the windows resources
        ///     probably useless to most people unless you have access to the resources
        /// </summary>
        public string Icon
        {
            get
            {
                if (Device.IconPath.IndexOf("-") > 0)
                {
                    return Device.IconPath.Substring(Device.IconPath.LastIndexOf("-") + 1);
                }
                return "";
            }
        }

        public AudioDeviceState State
        {
            get { return (AudioDeviceState) Device.State; }
        }

        public EDataFlow DataFlow
        {
            get { return Device.DataFlow; }
        }

        public bool IsPlaybackDevice
        {
            get { return Device.DataFlow == EDataFlow.eRender || Device.DataFlow == EDataFlow.eAll; }
        }

        public bool IsRecordingDevice
        {
            get { return Device.DataFlow == EDataFlow.eCapture || Device.DataFlow == EDataFlow.eAll; }
        }

        /// <summary>
        ///     Accesssor to lower level device
        /// </summary>
        internal MMDevice Device { get; private set; }

        public void OnDeviceStateChanged(string deviceId, EDeviceState newState)
        {
            throw new NotImplementedException();
        }

        public void OnDeviceAdded(string pwstrDeviceId)
        {
            throw new NotImplementedException();
        }

        public void OnDeviceRemoved(string deviceId)
        {
            throw new NotImplementedException();
        }

        public void OnDefaultDeviceChanged(EDataFlow flow, ERole role, string defaultDeviceId)
        {
            throw new NotImplementedException();
        }

        public void OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Overriden to return a more meaningful name
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FullName;
        }

        /// <summary>
        ///     Set this device as the the default device
        /// </summary>
        public void SetAsDefaultDevice()
        {
            AudioDeviceManager.SetAsDefaultDevice(this);
        }

        /// <summary>
        ///     Set this device as the default communication device
        /// </summary>
        public void SetAsDefaultCommunicationDevice()
        {
            AudioDeviceManager.SetAsDefaultCommunicationDevice(this);
        }

        /// <summary>
        ///     Set the volume level on a scale between 0-100
        /// </summary>
        /// <param name="level"></param>
        public void SetVolumeLevel(int level)
        {
            if (level < 0)
                level = 0;
            else if (level > 100)
                level = 100;

            Device.AudioEndpointVolume.MasterVolumeLevelScalar = (float) level/100;
        }

        /// <summary>
        ///     Mute this device
        /// </summary>
        public void Mute()
        {
            Device.AudioEndpointVolume.Mute = true;
        }

        /// <summary>
        ///     Unmute this device
        /// </summary>
        public void UnMute()
        {
            Device.AudioEndpointVolume.Mute = false;
        }


        /// <summary>
        ///     Toggle the mute on this device
        /// </summary>
        public void MuteToggle()
        {
            Device.AudioEndpointVolume.Mute = !Device.AudioEndpointVolume.Mute;
        }
    }
}