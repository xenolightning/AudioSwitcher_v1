namespace FortyOne.AudioSwitcher.SoundLibrary
{
    public enum AudioDeviceEventType
    {
        DefaultDevice,
        DefaultCommunicationDevice,
        Volume,
        Level
    }

    /// <summary>
    ///     Event args passed back when an attribute on the device changes
    /// </summary>
    public class AudioDeviceChangedEventArgs
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="dev"></param>
        public AudioDeviceChangedEventArgs(AudioDevice dev, AudioDeviceEventType type)
        {
            Device = dev;
            EventType = type;
        }

        /// <summary>
        ///     Device that fired this event
        /// </summary>
        public AudioDevice Device { get; private set; }

        /// <summary>
        ///     Get the change type
        /// </summary>
        public AudioDeviceEventType EventType { get; private set; }
    }

    /// <summary>
    ///     Delegate for the event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void AudioDeviceChangedHandler(object sender, AudioDeviceChangedEventArgs e);

    public static partial class AudioDeviceManager
    {
        /// <summary>
        ///     Event that is fired whenever anything on a device is updated
        /// </summary>
        public static event AudioDeviceChangedHandler AudioDeviceChanged;

        private static void FireAudioDeviceChanged(AudioDeviceChangedEventArgs e)
        {
            if (AudioDeviceChanged != null)
                AudioDeviceChanged(e.Device, e);
        }
    }
}