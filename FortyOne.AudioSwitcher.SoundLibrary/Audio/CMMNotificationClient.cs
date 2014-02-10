using System;
using FortyOne.AudioSwitcher.SoundLibrary.Audio.Interfaces;

namespace FortyOne.AudioSwitcher.SoundLibrary.Audio
{
    public class CMMNotificationClient : IMMNotificationClient
    {
        public delegate void DefaultDeviceChangedEventHandler(EDataFlow flow, ERole role, string pwstrDefaultDevice);

        public delegate void DeviceAddedEventHandler(string pwstrDeviceId);

        public delegate void DeviceRemovedEventHandler(string pwstrDeviceId);

        public delegate void DeviceStateChangedEventHandler(string pwstrDeviceId, EDeviceState dwNewState);

        public delegate void PropertyValueChangedEventHandler(string pwstrDeviceId, PropertyKey key);


        public void OnDeviceStateChanged(string deviceId, EDeviceState newState)
        {
            if (DeviceStateChanged != null)
            {
                DeviceStateChanged(deviceId, newState);
            }
        }

        void IMMNotificationClient.OnDeviceAdded(string pwstrDeviceId)
        {
            if (DeviceAdded != null)
            {
                DeviceAdded(pwstrDeviceId);
            }
        }

        void IMMNotificationClient.OnDeviceRemoved(string deviceId)
        {
            if (DeviceAdded != null)
            {
                DeviceAdded(deviceId);
            }
        }

        public void OnDefaultDeviceChanged(EDataFlow flow, ERole role, string defaultDeviceId)
        {
            try
            {
                if (DefaultDeviceChanged != null)
                {
                    DefaultDeviceChanged(flow, role, defaultDeviceId);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key)
        {
            if (PropertyValueChanged != null)
            {
                PropertyValueChanged(pwstrDeviceId, key);
            }
        }

        public event DefaultDeviceChangedEventHandler DefaultDeviceChanged;
        public event DeviceAddedEventHandler DeviceAdded;
        public event DeviceRemovedEventHandler DeviceRemoved;
        public event DeviceStateChangedEventHandler DeviceStateChanged;
        public event PropertyValueChangedEventHandler PropertyValueChanged;
    }
}