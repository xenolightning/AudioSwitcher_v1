using System.Collections.Generic;
using System.Collections.ObjectModel;
using CoreAudio;
using FortyOne.AudioSwitcher.SoundLibrary.Audio;

namespace FortyOne.AudioSwitcher.SoundLibrary
{
    /// <summary>
    ///     Static class that provides useful functions to the end user
    /// </summary>
    public static partial class AudioDeviceManager
    {
        /// <summary>
        ///     For thread safety accessing to the collections
        /// </summary>
        private static readonly object CollectionMutex = new object();

        private static readonly MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();

        private static readonly List<AudioDevice> playbackdevices = new List<AudioDevice>();

        private static readonly List<AudioDevice> recordingdevices = new List<AudioDevice>();

        /// <summary>
        ///     Returns a list of all non-disabled playback devices available on the machine
        /// </summary>
        public static ReadOnlyCollection<AudioDevice> PlayBackDevices
        {
            get
            {
                lock (CollectionMutex)
                {
                    playbackdevices.Clear();
                    MMDeviceCollection mmColl = DevEnum.EnumerateAudioEndPoints(EDataFlow.eRender,
                        EDeviceState.DEVICE_STATE_ACTIVE | EDeviceState.DEVICE_STATE_UNPLUGGED);
                    for (int i = 0; i < mmColl.Count; i++)
                        if (mmColl[i] != null)
                            playbackdevices.Add(new AudioDevice(mmColl[i]));
                    return new ReadOnlyCollection<AudioDevice>(playbackdevices);
                }
            }
        }

        /// <summary>
        ///     Returns a list of all non-disabled capture devices available on the machine
        /// </summary>
        public static ReadOnlyCollection<AudioDevice> RecordingDevices
        {
            get
            {
                lock (CollectionMutex)
                {
                    recordingdevices.Clear();
                    MMDeviceCollection mmColl = DevEnum.EnumerateAudioEndPoints(EDataFlow.eCapture,
                        EDeviceState.DEVICE_STATE_ACTIVE | EDeviceState.DEVICE_STATE_UNPLUGGED);
                    for (int i = 0; i < mmColl.Count; i++)
                        if (mmColl[i] != null)
                            recordingdevices.Add(new AudioDevice(mmColl[i]));
                    return new ReadOnlyCollection<AudioDevice>(recordingdevices);
                }
            }
        }

        /// <summary>
        ///     Returns AudioDevice that is set as the Default Playback Device
        /// </summary>
        public static AudioDevice DefaultPlaybackDevice
        {
            get
            {
                return
                    new AudioDevice(DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender,
                        ERole.eMultimedia | ERole.eConsole));
            }
        }

        /// <summary>
        ///     Returns AudioDevice that is set as the Default Communication Playback Device
        /// </summary>
        public static AudioDevice DefaultPlaybackCommDevice
        {
            get { return new AudioDevice(DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eCommunications)); }
        }

        /// <summary>
        ///     Returns AudioDevice that is set as the Default Capture Device
        /// </summary>
        public static AudioDevice DefaultRecordingDevice
        {
            get
            {
                return
                    new AudioDevice(DevEnum.GetDefaultAudioEndpoint(EDataFlow.eCapture,
                        ERole.eMultimedia | ERole.eConsole));
            }
        }

        /// <summary>
        ///     Returns AudioDevice that is set as the Default Communication Capture Device
        /// </summary>
        public static AudioDevice DefaultRecordingCommDevice
        {
            get { return new AudioDevice(DevEnum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eCommunications)); }
        }

        /// <summary>
        ///     Returns the audio device by the device ID if it exists.
        ///     If the device does not exist it will return null
        /// </summary>
        /// <param name="ID">The ID of the device</param>
        /// <returns>A valid AudioDevice or null</returns>
        public static AudioDevice GetAudioDevice(string ID)
        {
            //Try get it from our list of cached devices first
            foreach (AudioDevice ad in PlayBackDevices)
            {
                if (ad.ID == ID)
                    return ad;
            }

            foreach (AudioDevice ad in RecordingDevices)
            {
                if (ad.ID == ID)
                    return ad;
            }

            MMDeviceCollection devColl = DevEnum.EnumerateAudioEndPoints(EDataFlow.eAll,
                EDeviceState.DEVICE_STATEMASK_ALL);
            try
            {
                if (DevEnum.GetDevice(ID).ID != ID)
                    return null;

                return new AudioDevice(DevEnum.GetDevice(ID));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     Set this device as the the default device
        /// </summary>
        public static void SetAsDefaultDevice(AudioDevice dev)
        {
            try
            {
                if (dev.ID != DefaultPlaybackDevice.ID && dev.State == AudioDeviceState.Active)
                {
                    CPolicyConfigVistaClient.SetDefaultDeviceStatic(dev.ID, ERole.eMultimedia | ERole.eConsole);
                    FireAudioDeviceChanged(new AudioDeviceChangedEventArgs(dev, AudioDeviceEventType.DefaultDevice));
                }
            }
            catch
            {
            }
        }

        /// <summary>
        ///     Set this device as the default communication device
        /// </summary>
        public static void SetAsDefaultCommunicationDevice(AudioDevice dev)
        {
            try
            {
                if (dev.ID != DefaultPlaybackCommDevice.ID && dev.State == AudioDeviceState.Active)
                {
                    CPolicyConfigVistaClient.SetDefaultDeviceStatic(dev.ID, ERole.eCommunications);
                    FireAudioDeviceChanged(new AudioDeviceChangedEventArgs(dev,
                        AudioDeviceEventType.DefaultCommunicationDevice));
                }
            }
            catch
            {
            }
        }
    }
}