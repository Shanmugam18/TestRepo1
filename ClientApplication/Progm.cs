using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternMatch;
using Newtonsoft.Json;

namespace ClientApplication
{
    class Progm
    {
        static void Main(string[] args)
        {

           ////Test Case
           ////Convert the test case to a JSOn File

           // List<StringFormat> lstofStng = new List<StringFormat>();
           // StringFormat stng = new StringFormat();
           // stng.AttrName = "B_EDSNo";
           // stng.PartName = "VW416A-41-10-TT-U01-001_A";
           // stng.PartType = "MakeDetail";
           // stng.ReplaceName = "120-123-1234-5";
           // stng.PartNewName = "";
           // lstofStng.Add(stng);
           // StringFormat stng1 = new StringFormat();
           // stng1.AttrName = "B_EDSNo";
           // stng1.PartName = "VW416A-41-10-TT-U01_A";
           // stng1.PartType = "Unit";
           // stng1.ReplaceName = "120-123-1234-5";
           // stng1.PartNewName = "";
           // lstofStng.Add(stng1);

           // string json = JsonConvert.SerializeObject(lstofStng);
           // System.IO.File.WriteAllText(@"C:\Users\Admin\Desktop\PatternMatch\PatternMatch\ClientApplication\bin\Debug\Output\file.json", json);

            //Get the Input Data from the JSOn file and deserialize it
            string inputJson = @"C:\Users\Admin\Desktop\PatternMatch\PatternMatch\ClientApplication\bin\Debug\Output\file.json";
            string jsonstring = System.IO.File.ReadAllText(inputJson);
            List<StringFormat> InputData = JsonConvert.DeserializeObject<List<StringFormat>>(jsonstring);
            //Update the Regex
            ReplaceText replaceRegex = new ReplaceText();
            
            replaceRegex.VCTReplacePattern(ref InputData);
            //Serialize the JSON file
            string UpdatedJson = JsonConvert.SerializeObject(InputData);
            System.IO.File.WriteAllText(@"C:\Users\Admin\Desktop\PatternMatch\PatternMatch\ClientApplication\bin\Debug\Output\updatedfile.json", UpdatedJson);

        }
    }
}
