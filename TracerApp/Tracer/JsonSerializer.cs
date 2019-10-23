using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TracerLib
{
    public class JsonSerializer
    {
        public void SaveTraceResult(TextWriter textWriter, TracerResult traceResult)
        {
            var jtokens = from threadTracerResult in traceResult.dThreadTracerResults.Values
                          select SaveThreads(threadTracerResult);
            JObject traceResultJSON = new JObject
            {
                { "Thread", new JArray(jtokens) }
            };

            using (var jsonWriter = new JsonTextWriter(textWriter))
            {
                jsonWriter.Formatting = Formatting.Indented;
                traceResultJSON.WriteTo(jsonWriter);
            }
        }

        private JToken SaveThreads(ThreadTracerResult threadTracerResult)
        {
            var lFirstLvlMethods = from methodTracerResult in threadTracerResult.lFirstLvlMethodTracersResult
                                   select SaveMethods(methodTracerResult);
            return new JObject
            {
                { "Id", threadTracerResult.Id },
                { "Time", threadTracerResult.Time.Milliseconds + "ms"},
                { "Methods", new JArray(lFirstLvlMethods) }
            };
        }

        private JToken SaveMethods(MethodTracerResult methodTracerResult)
        {
            var savedTracedMetod = new JObject
            {
                { "Name", methodTracerResult.MethodName },
                { "Class", methodTracerResult.ClassName },
                { "Time", methodTracerResult.Time.Milliseconds + "ms" }
            };

            if (methodTracerResult.lInnerMethodTracerResults.Any())
                savedTracedMetod.Add("Methods", new JArray(from mt in methodTracerResult.lInnerMethodTracerResults
                                                           select SaveMethods(mt)));
            return savedTracedMetod;
        }
    }
}
