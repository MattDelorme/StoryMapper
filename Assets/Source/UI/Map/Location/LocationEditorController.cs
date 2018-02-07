using System.Collections.Generic;
using UnityEngine;

namespace StoryMapper
{
    public class LocationEditorController : MonoBehaviour
    {
        public LocationMarker LocationMarkerPrefab;

        private List<LocationMarker> locationMarkersList;

        void Start()
        {
            IList<IMapLocation> mapLocations = EntityDatabase.GetEntityDatabase().LoadAllEntities<IMapLocation>();
            locationMarkersList = new List<LocationMarker>();
            for (int i = 0; i < mapLocations.Count; i++)
            {
                var locationMarker = Object.Instantiate(LocationMarkerPrefab, transform);
                locationMarker.MapLocation = mapLocations[i];
                locationMarkersList.Add(locationMarker);
            }
        }
    }
}
