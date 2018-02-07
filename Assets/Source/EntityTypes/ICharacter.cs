using System.Collections.Generic;

namespace StoryMapper
{
    public interface ICharacter
    {
        string Name { get; }
        IEnumerable<IEvent> GetEvents();
    }
}
