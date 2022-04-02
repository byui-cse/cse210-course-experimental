using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;


namespace Byui.Games.Casting
{
    public class Settings
    {
        private Dictionary<string, string> _settings = new Dictionary<string, string>();
        
        /// <summary>
        /// Opens the settings file at the given path and enumerates the values.
        /// </summary>
        /// <param name="filepath">Full path to INI file.</param>
        public Settings(String filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException("Unable to locate " + filepath);
            }
            ParseData(filepath);
        }

        public float GetFloat(string section, string setting)
        {
            string value = GetString(section, setting);
            return float.Parse(value);
        }

        public int GetInt(string section, string setting)
        {
            string value = GetString(section, setting);
            return int.Parse(value);
        }

        public string GetString(string section, string setting)
        {
            string key = MakeKey(section, setting);
            return _settings[key];
        }

        public Vector2 GetVector2(string section, string setting)
        {
            string value = GetString(section, setting);
            string[] coords = value.Split(",");
            float x = float.Parse(coords[0]);
            float y = float.Parse(coords[1]);
            return new Vector2(x, y);
        }

        public bool Has(string section, string setting)
        {
            string key = MakeKey(section, setting);
            return _settings.ContainsKey(key);
        }

        private string MakeKey(string section, string setting)
        {
            return $"{section}:{setting}";
        }

        private void ParseData(string filepath)
        {
            using (var streamReader = new StreamReader(filepath))
            {
                string section = "Root";
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    if (line != "" && !line.StartsWith(";"))
                    {
                        if (line.StartsWith("[") && line.EndsWith("]"))
                        {
                            section = line.Substring(1, line.Length - 2).Trim();
                        }
                        else
                        {
                            string[] keyValuePair = line.Split('=');
                            string setting = keyValuePair[0].Trim();
                            string key = MakeKey(section, setting);
                            string value = keyValuePair[1].Trim();
                            _settings.Add(key, value);
                        }
                    }
                    line = streamReader.ReadLine();
                }
            }
        }
    }
}
