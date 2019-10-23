using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib
{
    interface ISerialize
    {
        void SaveTraceResult(TextWriter textWriter, TracerResult traceResult);
    }
}
