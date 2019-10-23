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

            StackFrame sf = new StackFrame(0);
            string methodName = sf.GetMethod().Name;
            string className = sf.GetMethod().DeclaringType.Name;
        }

        void Method1()
        {
            Thread.Sleep(100);
        }
    }
}
