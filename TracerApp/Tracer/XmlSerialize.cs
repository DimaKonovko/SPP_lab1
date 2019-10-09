using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TracerLib
{
    public class XmlSerialize : ISerialize
    {
        public TraceResult TraceResult { get; set; }

        public string PathToSave { get; set; }

        public XmlSerialize(TraceResult traceRes, string pathToSave)
        {
            this.PathToSave = pathToSave;
            this.TraceResult = traceRes;
            this.TraceResult.ReversItemsStack();
        }

        public string Perform()
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Indent = true;

            using (XmlWriter xmlWriter = XmlWriter.Create(sb, xws))
            {
                XElement root = new XElement("root");
                XDocument xmlDoc = new XDocument(root);
                BuildNodeTree(root);
                xmlDoc.Save(xmlWriter);
            }

            using (StreamWriter file = File.CreateText(PathToSave))
            {
                file.Write(sb.ToString());
            }

            return sb.ToString();
        }

        public void BuildNodeTree(XElement root)
        {
            while (this.TraceResult.ItemsStack.Any())
            {
                XElement xElement = BuildNode(root);
                root.Add(xElement);
            }
            
        }

        public XElement BuildNode(XElement parentElement)
        {
            TraceResultItem item = this.TraceResult.ItemsStack.Pop();
            XElement currElement = new XElement(
                    "method",
                    new XAttribute("name", item.MethodName),
                    new XAttribute("class", item.ClassName),
                    new XAttribute("depth", item.Depth)
                );

            if (this.TraceResult.ItemsStack.Any())
            {
                TraceResultItem nextItem = this.TraceResult.ItemsStack.Peek();
                if (nextItem.Depth == item.Depth)
                {
                    parentElement.Add(currElement);
                    while (this.TraceResult.ItemsStack.Any() && nextItem.Depth == item.Depth)
                    {
                        XElement neighborElement = BuildNode(parentElement);
                    }
                }
                else if (nextItem.Depth > item.Depth)
                {
                    XElement nestedElement = BuildNode(currElement);
                    currElement.Add(nestedElement);
                }
            }

            return currElement;

            //if (nextItem.Depth == 0 || nextItem.Depth <= item.Depth)
            //{
            //    return currElement;
            //}
            //else
            //{
            //    XElement nestedElement = BuildNode(currElement);
            //    if (nextItem.Depth > item.Depth)
            //    {
            //        currElement.Add(nestedElement);
            //        return currElement;
            //    }
            //    //else
            //    //{
            //    //    while (this.TraceResult.ItemsStack.Any())
            //    //    {

            //    //    }
            //    //    parentNode.Add(nestedElement);
            //    //}
            //}

        }
    }
}
