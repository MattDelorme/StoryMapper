using System.Collections.Generic;
using UnityEngine;

namespace StoryMapper
{
    public interface IMapRoute
    {
        IRoute Route { get; }
        List<Vector3> Points { get; }
    }
}
