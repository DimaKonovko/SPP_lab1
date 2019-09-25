using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TracerLib
{
    class XmlSerialize : ISerialize
    {
        public TraceResult TraceRes { get; set; }
        public string PathToSave { get; set; }
        public XmlSerialize(TraceResult traceRes, string pathToSave)
        {
            TraceRes = traceRes;
            PathToSave = pathToSave;
        }

        public void Perform()
        {
            XmlWriter xmlWriter = XmlWriter.Create(PathToSave);

           
        }

        public void WriteRes(TraceResult traceRes)
        {

        }
    }
}
