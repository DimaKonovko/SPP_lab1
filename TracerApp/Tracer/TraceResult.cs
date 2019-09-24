using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib
{
    public class TraceResult
    {
        public Stack<TraceResultItem> ItemsStack { get; private set; }

        public TraceResult()
        {
            this.ItemsStack = new Stack<TraceResultItem>();
        }
    }
}
