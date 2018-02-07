
namespace StoryMapper
{
    public static class EntityDatabase
    {
        // TODO Get this from Service
        private static IEntityDatabase entityAssetDatabase;
        public static IEntityDatabase GetEntityDatabase()
        {
            if (entityAssetDatabase == null)
            {
//                #if UNITY_EDITOR
                entityAssetDatabase = new EntityAssetDatabase();
//                #else
//                entityAssetDatabase = new EntityJsonAssetDatabase();
//                #endif
            }
            return entityAssetDatabase;
        }
    }
}
