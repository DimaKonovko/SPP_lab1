using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib
{
    public class MethodTracerResult
    {
        public string ClassName { get; private set; }
        public string MethodName { get; private set; }
        public TimeSpan Time { get; private set; }
        public List<MethodTracerResult> lInnerMethodTracerResults;

        public static MethodTracerResult GetTraceResult(MethodTracer methodTracer)
        {
            MethodTracerResult methodTracerResult = new MethodTracerResult();
            methodTracerResult.ClassName = methodTracer.ClassName;
            methodTracerResult.MethodName = methodTracer.MethodName;
            methodTracerResult.Time = methodTracer.Time;
            methodTracerResult.lInnerMethodTracerResults = new List<MethodTracerResult>();

            foreach (var innerMethodTracer in methodTracer.lInnerMethodTracers)
            {
                methodTracerResult.lInnerMethodTracerResults.Add(MethodTracerResult.GetTraceResult(innerMethodTracer));
            }

            return methodTracerResult;
        }
    }
}
