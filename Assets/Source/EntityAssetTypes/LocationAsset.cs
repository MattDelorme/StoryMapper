using UnityEngine;

namespace StoryMapper
{
    [CreateAssetMenu(menuName="Entities/Location")]
    public class LocationAsset : AbstractEntityAsset, ILocation
    {
        [SerializeField] string _name = null;
        public string Name { get { return _name; } }

        [TextArea]
        [SerializeField] string description = null;
        public string Description { get { return description; } }
    }
}
