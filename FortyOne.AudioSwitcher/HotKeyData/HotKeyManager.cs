using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using FortyOne.AudioSwitcher.Configuration;

namespace FortyOne.AudioSwitcher.HotKeyData
{
    public static class HotKeyManager
    {
        private static readonly List<HotKey> _hotkeys = new List<HotKey>();

        public static BindingList<HotKey> HotKeys = new BindingList<HotKey>();


        static HotKeyManager()
        {
            LoadHotKeys();
            RefreshHotkeys();
        }

        public static event EventHandler HotKeyPressed;

        public static void LoadHotKeys()
        {
            try
            {
                foreach (HotKey hk in _hotkeys)
                {
                    hk.UnregsiterHotkey();
                }

                string hotkeydata = ConfigurationSettings.HotKeys;
                if (string.IsNullOrEmpty(hotkeydata))
                    return;

                string[] entries = hotkeydata.Split(new[] { ",", "[", "]" }, StringSplitOptions.RemoveEmptyEntries);

                _hotkeys.Clear();

                for (int i = 0; i < entries.Length; i++)
                {
                    int key = int.Parse(entries[i++]);
                    int modifiers = int.Parse(entries[i++]);
                    var hk = new HotKey();
                    hk.DeviceId = new Guid(entries[i]);
                    hk.Modifiers = (Modifiers)modifiers;
                    hk.Key = (Keys)key;
                    _hotkeys.Add(hk);
                    hk.HotKeyPressed += hk_HotKeyPressed;
                    hk.RegisterHotkey();
                }
            }
            catch
            {
                ConfigurationSettings.HotKeys = "";
            }
        }

        private static void hk_HotKeyPressed(object sender, EventArgs e)
        {
            if (HotKeyPressed != null)
                HotKeyPressed(sender, e);
        }

        public static void SaveHotKeys()
        {
            string hotkeydata = "";
            foreach (HotKey hk in _hotkeys)
            {
                hotkeydata += "[" + (int)hk.Key + "," + (int)hk.Modifiers + "," + hk.DeviceId + "]";
            }
            ConfigurationSettings.HotKeys = hotkeydata;

            RefreshHotkeys();
        }

        public static bool AddHotKey(HotKey hk)
        {
            //Check that there is no duplicate
            if (DuplicateHotKey(hk))
                return false;

            try
            {
                hk.HotKeyPressed += hk_HotKeyPressed;
                hk.RegisterHotkey();

                _hotkeys.Add(hk);

                SaveHotKeys();
            }
            catch
            {
                return false;
            }

            return true;
        }

        private static void RefreshHotkeys()
        {
            HotKeys.Clear();
            foreach (HotKey k in _hotkeys.Where(x => x.Device != null))
            {
                HotKeys.Add(k);
            }
        }

        public static bool DuplicateHotKey(HotKey hk)
        {
            foreach (HotKey k in _hotkeys)
            {
                if (hk.Key == k.Key && hk.Modifiers == k.Modifiers)
                    //((int)hk.Key & (int)hk.Modifiers) == ((int)k.Key & (int)k.Modifiers))
                    return true;
            }
            return false;
        }

        public static void DeleteHotKey(HotKey hk)
        {
            //Ensure its unregistered
            hk.UnregsiterHotkey();
            _hotkeys.Remove(hk);
            SaveHotKeys();
        }
    }
}