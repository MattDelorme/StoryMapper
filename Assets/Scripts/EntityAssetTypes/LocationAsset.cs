using UnityEngine;

namespace StoryMapper
{
    [CreateAssetMenu(menuName="Entities/Location")]
    public class LocationAsset : ScriptableObject
    {
        public string Name;

        [TextArea]
        public string Description;
    }
}
