using System.Numerics;


namespace Byui.Games.Services
{
    public interface ISettingsService
    {
        double GetDouble(string key);
        float GetFloat(string key);
        int GetInt(string key);
        string GetString(string key);
        T[] GetArray<T>(string key);
        Vector2 GetVector2(string key);
        void PutDouble(string key, double value);
        void PutFloat(string key, float value);
        void PutInt(string key, int value);
        void PutString(string key, string value);
        void PutArray<T>(string key, T[] value);
        void PutVector2(string key, Vector2 value);
        void Save();
    }
}