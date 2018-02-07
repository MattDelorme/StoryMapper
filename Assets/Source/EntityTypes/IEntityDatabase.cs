using System.Collections.Generic;

namespace StoryMapper
{
    public interface IEntityDatabase
    {
        IMapRoute CreateRoute();
        void SaveRoute(IMapRoute mapRoute, string name);
        IMapRoute LoadRoute(string name);
        IList<T> LoadAllEntities<T>();
    }
}
