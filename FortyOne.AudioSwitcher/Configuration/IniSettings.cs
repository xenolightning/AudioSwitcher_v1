using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FortyOne.AudioSwitcher.Configuration
{
    public class IniSettings : ISettingsSource
    {
        private const string SECTION_NAME = "Settings";
        readonly ConfigurationWriter _writer = new ConfigurationWriter();

        public void SetFilePath(string path)
        {
            _writer.SetPath(path);
        }

        public void Load()
        {
            //Do nothing
        }

        public void Save()
        {
            //Do nothing
        }

        public string Get(string key)
        {
            return _writer.IniReadValue(SECTION_NAME, key);
        }

        public void Set(string key, string value)
        {
            _writer.IniWriteValue(SECTION_NAME, key, value);
        }
    }
}
