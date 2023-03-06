using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Reflection;

namespace WebAPI.Aspects
{
    [PSerializable]
    public class LoggingAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine(args.Method.Name + " - On Entry");
            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine(args.Method.Name + " - On Exit");
            base.OnExit(args);
        }

        public override void OnYield(MethodExecutionArgs args)
        {
            Console.WriteLine(args.Method.Name + " - On Yield...");
            base.OnYield(args);
        }

        public override void OnResume(MethodExecutionArgs args)
        {
            Console.WriteLine(args.Method.Name + " - On Resume...");
            base.OnResume(args);
        }
    }
}
