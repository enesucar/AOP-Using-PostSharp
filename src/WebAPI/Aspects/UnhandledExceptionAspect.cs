using PostSharp.Aspects;
using PostSharp.Serialization;

namespace WebAPI.Aspects
{
    [PSerializable]
    public class UnhandledExceptionAspect : OnMethodBoundaryAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine("Error: " + args.Exception.Message);
            base.OnException(args);
        }
    }
}
