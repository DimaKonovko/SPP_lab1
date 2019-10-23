using System;
using System.Collections.Generic;
using System.IO;
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
            this.Tracer = new Tracer();

            TestMethod_1();
            TestMethod_2();
 
            SaveToXml();
            SaveToJson();

            Console.ReadLine();
        }

        public void SaveToXml()
        {
            string pathToSave = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\Save\\TraseResult.xml");

            FileStream fileStream = new FileStream(pathToSave, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            TracerResult tracerResult = this.Tracer.GetTraceResult();

            XmlSerializer xmlSerializer = new XmlSerializer();
            xmlSerializer.SaveTraceResult(streamWriter, tracerResult);
            xmlSerializer.SaveTraceResult(Console.Out, tracerResult);
        }

        public void SaveToJson()
        {

        }

        public void TestMethod_1()
        {
            this.Tracer.StartTrace();
            TestMethod_1_1();
            TestMethod_1_2();
            TestMethod_1_3();
            TestMethod_1_4();
            this.Tracer.StopTrace();            
        }

        public void TestMethod_1_1()
        {
            this.Tracer.StartTrace();
            Thread.Sleep(100);
            this.Tracer.StopTrace();
        }

        public void TestMethod_1_2()
        {
            this.Tracer.StartTrace();
            Thread.Sleep(100);
            this.Tracer.StopTrace();
        }

        public void TestMethod_1_3()
        {
            this.Tracer.StartTrace();
            Thread.Sleep(100);
            this.Tracer.StopTrace();
        }

        public void TestMethod_1_4()
        {
            this.Tracer.StartTrace();
            Thread.Sleep(100);
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
            Thread.Sleep(100);
            TestMethod_2_1_1();
            this.Tracer.StopTrace();
        }
        public void TestMethod_2_1_1()
        {
            this.Tracer.StartTrace();
            Thread.Sleep(100);
            this.Tracer.StopTrace();
        }
    }
}
