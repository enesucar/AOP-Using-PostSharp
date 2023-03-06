using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Diagnostics;
using System.Transactions;

namespace WebAPI.Aspects
{
    [PSerializable]
    public class PerformanceAspect : MethodInterceptionAspect
    {
        public async override Task OnInvokeAsync(MethodInterceptionArgs args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            await args.ProceedAsync();
            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds > 5000)
            {
                Console.WriteLine(args.Method.Name + " - Elapsed Milliseconds:" + stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
