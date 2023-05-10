namespace BL.Exceptions
{
    public class EntityWithGivenIdDoesNotExistException<T> : Exception
    {
        public EntityWithGivenIdDoesNotExistException() : base($"Entity of type {typeof(T)} with given id does not exist.")
        {
        }
    }
}
