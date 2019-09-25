using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib
{
    public class TraceResultItem
    {
        public string MethodName { get; private set; }

        public string ClassName { get; set; }

        public int Depth { get; private set; }

        public TraceResultItem(string methodName, string className, int depth)
        {
            MethodName = methodName;
            ClassName = className;
            Depth = depth;
        }
    }
}
