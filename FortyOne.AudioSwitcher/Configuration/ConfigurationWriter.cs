using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace FortyOne.AudioSwitcher.Configuration
{
    public class ConfigurationWriter
    {

        private string _path;
        private readonly object _mutex = new object();

        /// <summary>
        ///     INIFile Constructor.
        /// </summary>
        /// <PARAM name="INIPath"></PARAM>
        public ConfigurationWriter(string iniPath)
        {
            SetPath(iniPath);
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal,
            int size, string filePath);

        public void SetPath(string iniPath)
        {
            if (!File.Exists(iniPath))
                File.Create(iniPath).Close();

            _path = iniPath;
        }

        /// <summary>
        ///     Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Section name
        /// <PARAM name="Key"></PARAM>
        /// Key Name
        /// <PARAM name="Value"></PARAM>
        /// Value Name
        public void IniWriteValue(string Section, string Key, string Value)
        {
            lock (_mutex)
            {
                if (!File.Exists(_path))
                    File.Create(_path).Close();

                WritePrivateProfileString(Section, Key, Value, _path);
            }
        }

        /// <summary>
        ///     Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public string IniReadValue(string Section, string Key)
        {
            lock (_mutex)
            {
                var temp = new StringBuilder(8192);
                int i = GetPrivateProfileString(Section, Key, "", temp, 8192, _path);

                if (string.IsNullOrEmpty(temp.ToString()))
                    throw new KeyNotFoundException(Section + " - " + Key);

                return temp.ToString();
            }
        }
    }
}