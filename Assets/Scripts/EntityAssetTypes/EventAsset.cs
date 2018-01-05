using System.Collections.Generic;
using UnityEngine;

namespace StoryMapper
{
    [CreateAssetMenu(menuName="Entities/Event")]
    public class EventAsset : ScriptableObject
    {
        public string Name;

        [TextArea]
        public string Description;

        public LocationAsset Location;

        public List<CharacterAsset> Characters;
    }
}
