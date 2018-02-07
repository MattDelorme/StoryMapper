using UnityEngine;
using System.Collections.Generic;

namespace StoryMapper
{
    [CreateAssetMenu(menuName="Entities/MapRoute")]
    public class MapRouteAsset : AbstractEntityAsset, IMapRoute
    {
        [SerializeField] RouteAsset route = null;
        public IRoute Route { get { return route; } }

        [SerializeField] List<Vector3> points = new List<Vector3>();
        public List<Vector3> Points
        {
            get { return points; }
            set { points = value; }
        }
    }
}
