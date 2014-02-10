using System.Collections.Generic;
using System.Collections.ObjectModel;
using FortyOne.AudioSwitcher.SoundLibrary;
using FortyOne.AudioSwitcher.SoundLibrary.Audio;

namespace FortyOne.AudioSwitcher
{
    public static class FavouriteDeviceManager
    {
        public delegate void FavouriteDeviceIDsChangedEventHandler(List<string> IDs);

        private static List<string> FavouriteDeviceIDs = new List<string>();

        static FavouriteDeviceManager()
        {
            FavouriteDeviceIDs = new List<string>();
        }

        public static int FavouriteDeviceCount
        {
            get { return FavouriteDeviceIDs.Count; }
        }

        public static ReadOnlyCollection<string> FavouriteDevices
        {
            get { return new ReadOnlyCollection<string>(FavouriteDeviceIDs); }
        }

        public static event FavouriteDeviceIDsChangedEventHandler FavouriteDevicesChanged;

        public static bool LoadFavouriteDevices(List<string> favouriteIDs)
        {
            return LoadFavouriteDevices(favouriteIDs.ToArray());
        }

        public static bool LoadFavouriteDevices(string[] favouriteIDs)
        {
            FavouriteDeviceIDs = new List<string>();

            foreach (string s in favouriteIDs)
            {
                if (AudioDeviceManager.GetAudioDevice(s) != null)
                    AddFavouriteDevice(s);
                else
                    RemoveFavouriteDevice(s);
            }
            return true;
        }

        public static bool IsFavouriteDevice(AudioDevice ad)
        {
            return FavouriteDeviceIDs.Contains(ad.ID);
        }

        public static bool IsFavouriteDevice(string ID)
        {
            return FavouriteDeviceIDs.Contains(ID);
        }

        public static string AddFavouriteDevice(string ID)
        {
            if (FavouriteDeviceIDs.Contains(ID))
                return "";

            FavouriteDeviceIDs.Add(ID);

            FireFavouriteDeviceChanged();

            return ID;
        }

        public static string RemoveFavouriteDevice(string ID)
        {
            FavouriteDeviceIDs.Remove(ID);

            FireFavouriteDeviceChanged();

            return ID;
        }

        private static void FireFavouriteDeviceChanged()
        {
            if (FavouriteDevicesChanged != null)
                FavouriteDevicesChanged(FavouriteDeviceIDs);
        }

        public static string GetNextFavouritePlaybackDevice()
        {
            //Start at the next device
            int index = (FavouriteDeviceIDs.IndexOf(AudioDeviceManager.DefaultPlaybackDevice.ID) + 1)%
                        FavouriteDeviceIDs.Count;

            int i = index;

            while (true)
            {
                AudioDevice ad = AudioDeviceManager.GetAudioDevice(FavouriteDeviceIDs[i%FavouriteDeviceIDs.Count]);
                if (ad.DataFlow == EDataFlow.eRender)
                    return FavouriteDeviceIDs[i%FavouriteDeviceIDs.Count];

                i++;

                if (i == index)
                    break;
            }

            return "";
        }
    }
}