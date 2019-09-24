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
        public void StartTrace_should_push_TraceResultItem_on_stack_and_inc_Depth()
        {
            Tracer tracer = new Tracer();
            StackFrame sf = new StackFrame(0);
            string methodName = sf.GetMethod().Name;
            string className = sf.GetMethod().DeclaringType.Name;
            int depth = 0;

            tracer.StartTrace();
            TraceResultItem item = tracer.TraceResult.ItemsStack.Pop();

            Assert.AreEqual(item.MethodName, methodName);
            Assert.AreEqual(item.ClassName, className);
            Assert.AreEqual(item.Depth, depth);

            Assert.AreEqual(tracer.Depth, 1);
        }

        [TestMethod]
        public void StopTrace_should_dec_Depth()
        {
            Tracer tracer = new Tracer();

            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();

            Assert.AreEqual(tracer.Depth, 0);
        }

        [TestMethod]
        public void GetTraceResult_should_return_TraceResult()
        {
            Tracer tracer = new Tracer();

            Assert.AreEqual(tracer.TraceResult.GetType(), typeof(TraceResult));
        }
    }
}
