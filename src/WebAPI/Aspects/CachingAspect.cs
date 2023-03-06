using Microsoft.Extensions.Logging;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Extensibility;
using PostSharp.Serialization;
using WebAPI.CrossCuttingConcerns.Caching;
using WebAPI.Utilities;

namespace WebAPI.Aspects
{
    [PSerializable]
    public class CachingAspect : MethodInterceptionAspect
    {
        private static readonly ICacheManager _cacheManager;
        private string _cacheKey;

        static CachingAspect()
        {
            if (!PostSharpEnvironment.IsPostSharpRunning)
            {
                _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            }
        }

        public CachingAspect(string cacheKey)
        {
            _cacheKey = cacheKey;
        }

        public async override Task OnInvokeAsync(MethodInterceptionArgs args)
        {
            var data = _cacheManager.Get(_cacheKey);
            if (data == null)
            {
                await args.ProceedAsync();
                var result = args.ReturnValue;
                _cacheManager.Set(_cacheKey, result);
            }
            else
            {
                args.ReturnValue = data;
            }
        }
    }
}
