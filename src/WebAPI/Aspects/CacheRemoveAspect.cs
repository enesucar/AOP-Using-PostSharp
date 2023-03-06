using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Serialization;
using WebAPI.CrossCuttingConcerns.Caching;
using WebAPI.Utilities;

namespace WebAPI.Aspects
{
    [PSerializable]
    public class CacheRemoveAspect : OnMethodBoundaryAspect
    {
        private static readonly ICacheManager _cacheManager;
        private string _cacheKey;

        static CacheRemoveAspect()
        {
            if (!PostSharpEnvironment.IsPostSharpRunning)
            {
                _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            }
        }

        public CacheRemoveAspect(string cacheKey)
        {
            _cacheKey = cacheKey;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            _cacheManager.Remove(_cacheKey);
            base.OnEntry(args);
        }
    }
}
