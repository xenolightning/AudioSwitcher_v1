using System.Collections.Generic;
using System.IO;
using fastJSON;

namespace FortyOne.AudioSwitcher.Configuration
{
    public class JsonSettings : ISettingsSource
    {
        private readonly object _mutex = new object();
        private string _path;
        private IDictionary<string, string> _settingsObject;

        public void SetFilePath(string path)
        {
            _path = path;
        }

        public void Load()
        {
            lock (_mutex)
            {
                try
                {
                    if (File.Exists(_path))
                        _settingsObject = JSON.ToObject<Dictionary<string, string>>(File.ReadAllText(_path));
                }
                catch
                {
                    _settingsObject = new Dictionary<string, string>();
                }
            }
        }

        public void Save()
        {
            //Write the result to file
            File.WriteAllText(_path, JSON.Beautify(JSON.ToJSON(_settingsObject)));
        }

        public string Get(string key)
        {
            lock (_mutex)
            {
                return _settingsObject[key];
            }
        }

        public void Set(string key, string value)
        {
            lock (_mutex)
            {
                _settingsObject[key] = value;
                Save();
            }
        }
    }
}