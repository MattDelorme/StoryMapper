using UnityEngine;

namespace StoryMapper
{
    [CreateAssetMenu(menuName="Entities/Route")]
    public class RouteAsset : AbstractEntityAsset, IRoute
    {
        [SerializeField] LocationAsset from = null;
        public ILocation From { get { return from; } }
        
        [SerializeField] LocationAsset to = null;
        public ILocation To { get { return to; } }
    }
}
