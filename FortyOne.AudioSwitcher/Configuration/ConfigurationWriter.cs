using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace FortyOne.AudioSwitcher.Configuration
{
    public class ConfigurationWriter
    {
        private static ConfigurationWriter pConfigWriter;

        private string path;

        /// <summary>
        ///     INIFile Constructor.
        /// </summary>
        /// <PARAM name="INIPath"></PARAM>
        private ConfigurationWriter()
        {
        }

        public static ConfigurationWriter ConfigWriter
        {
            get
            {
                if (pConfigWriter == null)
                    pConfigWriter = new ConfigurationWriter();
                return pConfigWriter;
            }
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal,
            int size, string filePath);

        public void SetPath(string INIPath)
        {
            if (!File.Exists(INIPath))
                File.Create(INIPath).Close();

            path = INIPath;
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
            if (!File.Exists(path))
                File.Create(path).Close();

            WritePrivateProfileString(Section, Key, Value, path);
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
            var temp = new StringBuilder(4096);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                4096, path);

            if (string.IsNullOrEmpty(temp.ToString()))
                throw new KeyNotFoundException();

            return temp.ToString();
        }
    }
}