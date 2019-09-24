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
        public TraceResult TraceResult;

        public int Depth { get; set; }

        public Tracer()
        {
            this.TraceResult = new TraceResult();
            this.Depth = 0;
        }

        public void StartTrace()
        {
            StackFrame sf = new StackFrame(1);
            string methodName = sf.GetMethod().Name;
            string className = sf.GetMethod().DeclaringType.Name;
          
            TraceResultItem item = new TraceResultItem(methodName, className, this.Depth);
            this.TraceResult.ItemsStack.Push(item);
            this.Depth++;
        }

        public void StopTrace()
        {
            this.Depth--;
        }

        public TraceResult GetTraceResult()
        {
            return this.TraceResult;
        }
    }
}
