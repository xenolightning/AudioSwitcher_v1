using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FortyOne.AudioSwitcher.Configuration
{
    public class JsonSettings : ISettingsSource
    {
        private readonly object _mutex = new object();
        private JObject _settingsObject = new JObject();
        private string _path;

        public void SetFilePath(string path)
        {
            _path = path;
        }

        public void Load()
        {
            if (File.Exists(_path))
                _settingsObject = JObject.Parse(File.ReadAllText(_path));
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(_settingsObject, Formatting.Indented);
            File.WriteAllText(_path, json);
        }

        public string Get(string key)
        {
            lock (_mutex)
            {
                return _settingsObject[key].Value<string>();
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
