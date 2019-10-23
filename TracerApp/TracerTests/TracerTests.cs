using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TracerLib;

namespace TracerTests
{
    [TestClass]
    public class TracerTests
    {
        [TestMethod]
        public void ShouldTraceSingleThreadSingleMethod()
        {
            Tracer tracer = new Tracer();

            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
            
            TracerResult tracerResult = tracer.GetTraceResult();

            ThreadTracerResult[] threadTracersResults = new ThreadTracerResult[tracer.GetTraceResult().dThreadTracerResults.Count];
            tracer.GetTraceResult().dThreadTracerResults.Values.CopyTo(threadTracersResults, 0);

            Assert.AreEqual(1, threadTracersResults.Length);
            Assert.AreEqual(1, threadTracersResults[0].lFirstLvlMethodTracersResult.Count);

            StackFrame sf = new StackFrame(0);
            string methodName = sf.GetMethod().Name;
            string className = sf.GetMethod().DeclaringType.Name;
            string methodNameFromTraceResult = threadTracersResults[0].lFirstLvlMethodTracersResult[0].MethodName;
            string classNameFromTraceResult = threadTracersResults[0].lFirstLvlMethodTracersResult[0].ClassName;

            Assert.AreEqual(methodName, methodNameFromTraceResult);
            Assert.AreEqual(className, classNameFromTraceResult);
        }

        void Method1()
        {
            Thread.Sleep(100);
        }
    }
}
