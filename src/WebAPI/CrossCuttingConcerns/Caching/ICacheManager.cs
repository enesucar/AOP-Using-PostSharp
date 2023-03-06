namespace WebAPI.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        object Get(string key);
        void Set(string key, object value);
        void Remove(string key);
    }
}
