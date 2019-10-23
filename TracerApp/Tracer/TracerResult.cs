using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib
{
    public class TracerResult
    {
        public IDictionary<int, ThreadTracerResult> dThreadTracerResults { get; private set; }

        public TracerResult(ConcurrentDictionary<int, ThreadTracer> cdThreadTracers)
        {
            dThreadTracerResults = new Dictionary<int, ThreadTracerResult>();
            foreach (var threadTracer in cdThreadTracers)
            {
                dThreadTracerResults[threadTracer.Key] = ThreadTracerResult.GetTraceResult(threadTracer.Value);
            }
        }
    }
}
