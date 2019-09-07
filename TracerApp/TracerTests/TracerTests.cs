using System;
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
        public void StopTrace_should_set_StopTime()
        {
            Tracer tracer = new Tracer();
            tracer.StopTrace();
            Assert.AreEqual(tracer.StopTime.GetType(), typeof(DateTime));
        }
    }
}
