using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace StoryMapper
{
    public class EntityJsonAssetDatabase : IEntityDatabase
    {
        public IMapRoute CreateRoute()
        {
            return ScriptableObject.CreateInstance<MapRouteAsset>();
        }

        public void SaveRoute(IMapRoute mapRoute, string name)
        {
            var directoryPath = Path.Combine(Application.persistentDataPath, "Entities/Routes");
            string filePath = string.Format("{0}/{1}.json", directoryPath, name);
            var json = JsonUtility.ToJson(mapRoute as MapRouteAsset, true);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            File.WriteAllText(filePath, json);
        }

        public IMapRoute LoadRoute(string name)
        {
            var filePath = string.Format("{0}/Entities/Routes/{1}.json", Application.persistentDataPath, name);
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var route = ScriptableObject.CreateInstance<MapRouteAsset>();
                JsonUtility.FromJsonOverwrite(json, route);
                return route;
            }
            return null;
        }

        public IList<T> LoadAllEntities<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}
