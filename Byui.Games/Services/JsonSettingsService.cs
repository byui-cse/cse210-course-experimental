using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Byui.Games.Services
{
    public class JsonSettingsService : ISettingsService
    {
        private string _filepath = "settings.json";
        private JsonNode _settings = null;

        public JsonSettingsService()
        {
            if (!File.Exists(_filepath))
            {
                Init();
                Save();
            }
            Load();
        }

        public JsonSettingsService(String filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException($"Unable to locate {filepath}");
            }
            _filepath = filepath;
            Load();
        }

        public double GetDouble(string key)
        {
            return _settings[key].GetValue<double>();
        }

        public float GetFloat(string key)
        {
            return _settings[key].GetValue<float>();
        }
        
        public int GetInt(string key)
        {
            return _settings[key].GetValue<int>();
        }
        
        public string GetString(string key)
        {
            return _settings[key].GetValue<string>();
        }
        
        public T[] GetArray<T>(string key)
        {
            JsonArray array = _settings[key].AsArray();
            T[] results = new T[array.Count];
            for (int i = 0; i < array.Count; i++)
            {
                results[i] = array[i].GetValue<T>();
            }
            return results;
        }

        public Vector2 GetVector2(string key)
        {
            JsonArray array = _settings[key].AsArray();
            float x = array[0].GetValue<float>();
            float y = array[1].GetValue<float>();
            return new Vector2(x, y);
        }

        public void PutDouble(string key, double value)
        {
            _settings[key] = value;
        }

        public void PutFloat(string key, float value)
        {
            _settings[key] = value;
        }

        public void PutInt(string key, int value)
        {
            _settings[key] = value;
        }

        public void PutString(string key, string value)
        {   
            _settings[key] = value;
        }

        public void PutArray<T>(string key, T[] value)
        {
            JsonNode[] nodes = new JsonNode[value.Count()];
            for (int i = 0; i < value.Count(); i++)
            {
                nodes[i] = JsonValue.Create<T>(value[i]);
            }
            _settings[key] = new JsonArray(nodes);
        }

        public void PutVector2(string key, Vector2 value)
        {
            JsonNode[] nodes = new JsonNode[2];
            nodes[0] = JsonValue.Create<float>(value.X);
            nodes[1] = JsonValue.Create<float>(value.Y);
            _settings[key] = new JsonArray(nodes);
        }

        public void Save()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string json = _settings.ToJsonString(options);
            File.WriteAllText(_filepath, json);
        }

        private void Init()
        {
            string json = @"{ 
                ""frameRate"": 60, 
                ""screenCaption"": ""CSE210"",
                ""screenWidth"": 640, 
                ""screenHeight"": 480 }";
            _settings = JsonNode.Parse(json);
        }

        private void Load()
        {
            string json = File.ReadAllText(_filepath);
            _settings = JsonNode.Parse(json);
        }
    }
}
