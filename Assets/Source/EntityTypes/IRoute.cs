
namespace StoryMapper
{
    public interface IRoute
    {
        ILocation From { get; }
        ILocation To { get; }
    }
}
