using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib
{
    public class Tracer : ITracer
    {
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public TraceResult TraceRes;

        public Tracer()
        {
            this.TraceRes = new TraceResult();
        }

        public TraceResult GetTraceResult()
        {
            if (StopTime == default(DateTime))
            {
                throw new Exception("StopTime is not initialized");
            }
            if (StartTime == default(DateTime))
            {
                throw new Exception("StartTime is not initialized");
            }

            int comparisonResult = StopTime.CompareTo(StartTime);
            if (comparisonResult == -1)
            {
                throw new Exception("StopTime is earlier than StartTime");
            }

            this.TraceRes.invocationTime = this.StopTime - this.StartTime;
            return TraceRes;
        }

        public void StartTrace()
        {
            StackFrame sf = new StackFrame(1);
            this.TraceRes.callerName = sf.GetMethod().Name;
            this.TraceRes.callerType = sf.GetMethod().DeclaringType.Name;
            this.StartTime = DateTime.Now;
        }

        public void StopTrace()
        {
            this.StopTime = DateTime.Now;
        }
    }
}
