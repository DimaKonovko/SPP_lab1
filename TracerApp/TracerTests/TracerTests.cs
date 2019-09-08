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
        public void StartTrace_should_set_StartTime()
        {
            Tracer tracer = new Tracer();

            tracer.StartTrace();

            Assert.AreEqual(tracer.StartTime.GetType(), typeof(DateTime));
        }

        [TestMethod]
        public void StartTrace_should_set_TraceRes_callerName()
        {
            StackFrame sf = new StackFrame(0);

            string callerName = sf.GetMethod().Name;
            Tracer tracer = new Tracer();
            tracer.StartTrace();

            Assert.AreEqual(tracer.TraceRes.callerName, callerName);
        }

        [TestMethod]
        public void StartTrace_should_set_TraceRes_callerType()
        {
            StackFrame sf = new StackFrame(0);

            string callerType = sf.GetMethod().DeclaringType.Name;
            Tracer tracer = new Tracer();
            tracer.StartTrace();

            Assert.AreEqual(tracer.TraceRes.callerType, callerType);
        }

        [TestMethod]
        public void StopTrace_should_set_StopTime()
        {
            Tracer tracer = new Tracer();

            tracer.StopTrace();

            Assert.AreEqual(tracer.StopTime.GetType(), typeof(DateTime));
        }

        [TestMethod]
        public void GetTraceResult_should_throw_StartTime_is_not_init()
        {
            Tracer tracer = new Tracer();
            string exMsg = "StartTime is not initialized";

            // tracer.StartTrace(); is missed
            Thread.Sleep(1000); // method invocation
            tracer.StopTrace();
            var ex = Assert.ThrowsException<Exception>(() => tracer.GetTraceResult());

            Assert.AreEqual(ex.Message, exMsg);
        }

        [TestMethod]
        public void GetTraceResult_should_throw_StopTime_is_not_init()
        {
            Tracer tracer = new Tracer();
            string exMsg = "StopTime is not initialized";

            tracer.StartTrace();
            Thread.Sleep(1000); // Method invocation
            // tracer.StopTrace(); is missed
            var ex = Assert.ThrowsException<Exception>(() => tracer.GetTraceResult());

            Assert.AreEqual(ex.Message, exMsg);
        }

        [TestMethod]
        public void GetTraceResult_should_throw_StopTime_is_earlier_than_StartTime()
        {
            Tracer tracer = new Tracer();
            string exMsg = "StopTime is earlier than StartTime";

            tracer.StopTrace(); // StopTrace method called before StartTrace
            Thread.Sleep(1000); // Method invocation
            tracer.StartTrace();
            var ex = Assert.ThrowsException<Exception>(() => tracer.GetTraceResult());

            Assert.AreEqual(ex.Message, exMsg);
        }
    }
}
