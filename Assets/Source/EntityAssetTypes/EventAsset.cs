using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace StoryMapper
{
    [CreateAssetMenu(menuName="Entities/Event")]
    public class EventAsset : AbstractEntityAsset, IEvent
    {
        [SerializeField] string _name = null;
        public string Name { get { return _name; } }

        [TextArea]
        [SerializeField] string description = null;
        public string Description { get { return description; } }
        
        [SerializeField] LocationAsset location = null;
        public ILocation Location { get { return location; } }
        
        [SerializeField] List<CharacterAsset> characters = null;
        public IList<ICharacter> Characters { get { return characters.Cast<ICharacter>().ToList(); } }
    }
}
