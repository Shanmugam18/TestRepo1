using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;


namespace PatternMatch
{
  public class Constants
    {
        internal static string Oem;
        internal static string Supplier;
        internal static string Division;
        internal static string OemSupplier = Path.Combine(GetExecutionFolder(), "Config", "OemSupplier.Config");
        internal static string XMLFile = Path.Combine(GetExecutionFolder(), "Config", "Replace_Regex.xml");
        internal static string GetExecutionFolder()
        {
            string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileInfo fileInfo = new FileInfo(location);
            string directory = fileInfo.Directory.FullName;
            return directory;
        }

        internal static void ReadOemSupplier()
        {
            string[] texts = File.ReadAllLines(OemSupplier)[0].Split(';');
            string Oem = texts[0].Split('=')[1];
            string Supplier = texts[1].Split('=')[1];
            String Division;
            try
            {
                Division = texts[2].Split('=')[1];
            }
            catch
            {
                Division = "NA";
            }

            Constants.Oem = Oem.ToUpper();
            Constants.Supplier = Supplier.ToUpper();
            Constants.Division = Division.ToUpper();
        }

        internal static List<XMLConfigFile> ReadXML()
        {
            List<XMLConfigFile> XmlConfigFile = new List<XMLConfigFile>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XMLFile);


            //XmlNodeList xmlNodeList = xmlDoc.SelectNodes("//*");
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes($"/RegexReplacePattern/SUPPLIER[@Name='{Constants.Supplier.ToString().ToUpper()}']/OEM[@Name='{Constants.Oem.ToString().ToUpper()}']/DIVISION[@Name='{Constants.Division.ToString().ToUpper()}']/*");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                string sAttrName = xmlNode.Attributes["Name"].Value;
                foreach (XmlNode childnode in xmlNode.ChildNodes)
                {
                    XMLConfigFile xmlRowData = new XMLConfigFile();
                    xmlRowData.PartType = childnode.Attributes["Type"].Value;
                    xmlRowData.RegexMatch = childnode.Attributes["RegexMatch"].Value;
                    xmlRowData.RegexReplace = childnode.Attributes["RegexReplace"].Value;
                    xmlRowData.PrefixText = childnode.Attributes["PrefixText"].Value;
                    xmlRowData.SuffixText = childnode.Attributes["SuffixText"].Value;
                    xmlRowData.AttributeName = sAttrName;
                    XmlConfigFile.Add(xmlRowData);
                }
            }
            return XmlConfigFile;
        }
    }


}
