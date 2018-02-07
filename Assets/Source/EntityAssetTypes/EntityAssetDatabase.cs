//#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace StoryMapper
{
    public class EntityAssetDatabase : IEntityDatabase
    {
        private const string ENTITIES = "Assets/Entities";

        public IMapRoute CreateRoute()
        {
            return ScriptableObject.CreateInstance<MapRouteAsset>();
        }

        public void SaveRoute(IMapRoute mapRoute, string name)
        {
            AssetDatabase.CreateAsset(mapRoute as MapRouteAsset, string.Format("{0}/Routes/{1}.asset", ENTITIES, name));
        }

        public IMapRoute LoadRoute(string name)
        {
            return AssetDatabase.LoadAssetAtPath<MapRouteAsset>(string.Format("{0}/Routes/{1}.asset", ENTITIES, name));
        }

        public IList<T> LoadAllEntities<T>()
        {
            List<T> entities = new List<T>();
            if (AbstractEntityAsset.InterfaceTypesToAssetTypes.ContainsKey(typeof(T)))
            {
                Type assetType = AbstractEntityAsset.InterfaceTypesToAssetTypes[typeof(T)];
                string [] guids = AssetDatabase.FindAssets(string.Format("t:{0}", assetType.Name));
                for (int i = 0; i < guids.Length; i++)
                {
                    string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
                    UnityEngine.Object entityObject = AssetDatabase.LoadAssetAtPath(assetPath, assetType);
                    T entity = (T)Convert.ChangeType(entityObject, typeof(T));
                    entities.Add(entity);
                }
            }
            else
            {
                Debug.LogErrorFormat("{0} is not a supported type", typeof(T).Name);
            }
            return entities;
        }
    }
}
//#endif
