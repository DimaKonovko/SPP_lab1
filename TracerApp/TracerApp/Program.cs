using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TracerLib;

namespace TracerApp
{
    class Program
    {
        public Tracer Tracer { get; set; }

        static void Main(string[] args)
        {
            new Program().Perform();
        }

        public void Perform()
        {
            Tracer = new Tracer();

            TestMethod_1();
            TestMethod_2();
            Console.ReadLine();
        }

        public void TestMethod_1()
        {
            this.Tracer.StartTrace();
            TestMethod_1_1();
            TestMethod_1_2();
            this.Tracer.StopTrace();            
        }

        public void TestMethod_1_1()
        {
            this.Tracer.StartTrace();
            Thread.Sleep(1000);
            this.Tracer.StopTrace();
        }

        public void TestMethod_1_2()
        {
            this.Tracer.StartTrace();
            Thread.Sleep(1000);
            this.Tracer.StopTrace();
        }

        public void TestMethod_2()
        {
            this.Tracer.StartTrace();
            TestMethod_2_1();
            this.Tracer.StopTrace();
        }

        public void TestMethod_2_1()
        {
            this.Tracer.StartTrace();
            Thread.Sleep(1000);
            TestMethod_2_1_1();
            this.Tracer.StopTrace();
        }
        public void TestMethod_2_1_1()
        {
            this.Tracer.StartTrace();
            Thread.Sleep(1000);
            this.Tracer.StopTrace();
        }
    }
}
