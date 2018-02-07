using System.Collections.Generic;
using UnityEngine;

namespace StoryMapper
{
    [CreateAssetMenu(menuName="Entities/Character")]
    public class CharacterAsset : AbstractEntityAsset, ICharacter
    {
        [SerializeField] string _name = null;
        public string Name { get { return _name; } }

        public IEnumerable<IEvent> GetEvents()
        {
            IList<IEvent> allEvents = EntityDatabase.GetEntityDatabase().LoadAllEntities<IEvent>();

            List<IEvent> events = new List<IEvent>();
            for (int i = 0; i < allEvents.Count; i++)
            {
                if (allEvents[i].Characters.Contains(this))
                {
                    events.Add(allEvents[i]);
                }
            }
            return events;
        }
    }
}
