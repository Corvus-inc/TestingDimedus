using System.IO;
using UnityEngine;

namespace SavingSystem
{
    public static class SavingSystem
    {
        public static void Save<T>(T model, string path)
        {
            using (var stream = new StreamWriter(path))
            {
                var json = JsonUtility.ToJson(model);
                stream.Write(json);
            }
        }


        public static T Load<T>(string path, T defaultValue = default) where T : class
        {
            using (var stream = new StreamReader(path))
            {
                var content = stream.ReadToEnd();
                var result = JsonUtility.FromJson<T>(content);

                return result ?? defaultValue;
            }
        }
    }
}

