using System;
using System.Collections.Generic;

namespace StoryMapper
{
    public interface IEvent
    {
        string Name { get; }
        string Description { get; }
        ILocation Location { get; }
        IList<ICharacter> Characters { get; }
    }
}
