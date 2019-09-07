using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    class Tracer : ITracer
    {
        private DateTime StartTime { get; set; }
        private DateTime StopTime { get; set; }
        public TraceResult GetTraceResult()
        {
            throw new NotImplementedException();
        }

        public void StartTrace()
        {
            this.StartTime = new DateTime();
        }

        public void StopTrace()
        {
            this.StopTime = new DateTime();
        }
    }
}
