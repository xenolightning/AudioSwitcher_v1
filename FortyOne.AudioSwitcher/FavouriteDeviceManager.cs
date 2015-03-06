using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AudioSwitcher.AudioApi;

namespace FortyOne.AudioSwitcher
{
    public static class FavouriteDeviceManager
    {
        public delegate void FavouriteDeviceIDsChangedEventHandler(List<Guid> ids);

        private static List<Guid> FavouriteDeviceIDs = new List<Guid>();

        static FavouriteDeviceManager()
        {
            FavouriteDeviceIDs = new List<Guid>();
        }

        public static int FavouriteDeviceCount
        {
            get { return FavouriteDeviceIDs.Count; }
        }

        public static ReadOnlyCollection<Guid> FavouriteDevices
        {
            get { return new ReadOnlyCollection<Guid>(FavouriteDeviceIDs); }
        }

        public static event FavouriteDeviceIDsChangedEventHandler FavouriteDevicesChanged;

        public static bool LoadFavouriteDevices(List<Guid> favouriteIDs)
        {
            return LoadFavouriteDevices(favouriteIDs.ToArray());
        }

        public static bool LoadFavouriteDevices(Guid[] favouriteIDs)
        {
            FavouriteDeviceIDs = new List<Guid>();

            foreach (Guid s in favouriteIDs)
            {
                if (AudioDeviceManager.Controller.GetDevice(s) != null)
                    AddFavouriteDevice(s);
                else
                    RemoveFavouriteDevice(s);
            }
            return true;
        }

        public static bool IsFavouriteDevice(IDevice ad)
        {
            return FavouriteDeviceIDs.Contains(ad.Id);
        }

        public static bool IsFavouriteDevice(Guid id)
        {
            return FavouriteDeviceIDs.Contains(id);
        }

        public static Guid AddFavouriteDevice(Guid id)
        {
            if (FavouriteDeviceIDs.Contains(id))
                return Guid.Empty;

            FavouriteDeviceIDs.Add(id);

            FireFavouriteDeviceChanged();

            return id;
        }

        public static Guid RemoveFavouriteDevice(Guid id)
        {
            FavouriteDeviceIDs.Remove(id);

            FireFavouriteDeviceChanged();

            return id;
        }

        private static void FireFavouriteDeviceChanged()
        {
            if (FavouriteDevicesChanged != null)
                FavouriteDevicesChanged(FavouriteDeviceIDs);
        }

        public static Guid GetNextFavouritePlaybackDevice()
        {
            //Start at the next device
            int index = (FavouriteDeviceIDs.IndexOf(AudioDeviceManager.Controller.DefaultPlaybackDevice.Id) + 1)%
                        FavouriteDeviceIDs.Count;

            int i = index;

            while (true)
            {
                var id = FavouriteDeviceIDs[i%FavouriteDeviceIDs.Count];
                IDevice ad = AudioDeviceManager.Controller.GetDevice(id);

                i++;

                if (ad == null)
                    continue;

                if (ad.DeviceType == DeviceType.Playback)
                    return id;

                if (i == index)
                    break;
            }

            return Guid.Empty;
        }
    }
}