using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FortyOne.AudioSwitcher.Configuration
{
    public interface ISettingsSource
    {

        void SetFilePath(string path);

        void Load();

        void Save();

        string Get(string key);

        void Set(string key, string value);

    }
}

