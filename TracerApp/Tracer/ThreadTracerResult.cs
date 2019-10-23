using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib
{
    public class ThreadTracerResult
    {
        public IList<MethodTracerResult> lFirstLvlMethodTracersResult { get; private set; }
        public int Id { get; private set; }
        public TimeSpan Time { get; private set; }

        public static ThreadTracerResult GetTraceResult(ThreadTracer threadTracer)
        {
            ThreadTracerResult threadTracerResult = new ThreadTracerResult();
            threadTracerResult.lFirstLvlMethodTracersResult = new List<MethodTracerResult>();
            threadTracerResult.Id = threadTracer.Id;
            threadTracerResult.Time = threadTracer.Time;

            foreach (var firstLvlMethodTracer in threadTracer.lFirstLvlMethodTracers)
            {
                threadTracerResult.lFirstLvlMethodTracersResult.Add(MethodTracerResult.GetTraceResult(firstLvlMethodTracer));
            }

            return threadTracerResult;
        }
    }
}
