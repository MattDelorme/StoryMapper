using UnityEngine;

namespace StoryMapper
{
    public interface IMapLocation
    {
        ILocation Location { get; }

        Vector3 Position { get; }
    }
}
