namespace Alka.Collections.Interfaces
{
    public interface IAlkaCollection<T> where T : class
    {
        T Add<U>(T item) where U : class;

        T Remove();

        event EventHandler<AddedEventArgs> AddedEvent;

        event EventHandler<RemovedEventArgs> RemovedEvent;
    }
}
