using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib
{
    class JsonSerialize : ISerialize
    {
        public TraceResult TraceRes { get; set; }
        public string PathToSave { get; set; }
        public JsonSerialize(TraceResult traceRes, string pathToSave)
        {
            TraceRes = traceRes;
            PathToSave = pathToSave;
        }

        public string Perform()
        {
            return "";
        }
    }
}
