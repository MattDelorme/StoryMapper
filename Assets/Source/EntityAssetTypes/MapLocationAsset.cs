using System;
using UnityEngine;

namespace StoryMapper
{
    [CreateAssetMenu(menuName="Entities/MapLocation")]
    public class MapLocationAsset : AbstractEntityAsset, IMapLocation
    {
        [SerializeField] LocationAsset location = null;
        public ILocation Location { get { return location; } }

        [SerializeField] Vector3 position = default(Vector3);
        public Vector3 Position { get { return position; } }
    }
}
