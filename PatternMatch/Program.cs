//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Text.RegularExpressions;
//using System.Xml;


//namespace PatternMatch
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //Unit
//            //string input = "VW416A-41-10-TT-U01_A";
//            //string Pattern = "^([A-Z0-9]{5,6})-([0-9]{2})-([0-9]{2})(-([A-Z0-9]{2}))?(-([A-Z0-9]{2,4})?)-U([0-9]{2})_([A-Z]{1})$";
//            //String SubstituteValue = "ToolEDS-0$8";

//            ////MakeDetail // Welded Parent
//            //string input = "VW416A-43-10-R3-MH1-U01-001_A";
//            //string Pattern = "^([A-Z0-9]{5,6})-([0-9]{2})-([0-9]{2})(-([A-Z0-9]{2}))?(-([A-Z0-9]{2,4})?)-U([0-9]{2})-([0-9]{3})_([A-Z]{1})$";
//            //String SubstituteValue = "ToolEDS-0$8-0$9";


//            ////WeldedChild
//            //string input = "VW416A-43-10-R3-MH1-U01-001-a_A";
//            //string Pattern = "^([A-Z0-9]{5,6})-([0-9]{2})-([0-9]{2})(-([A-Z0-9]{2}))?(-([A-Z0-9]{2,4})?)-U([0-9]{2})-([0-9]{3})-([a-z]{1,2})_([A-Z]{1})$";
//            //String SubstituteValue = "ToolEDS-0$8-0$9-$10";

//            //string Output = "";

//            //Output = SubstituteRegex(input, Pattern, SubstituteValue);

//            //Console.WriteLine(Output);


//            //Read the OemSupplier Config file
//            Constants.ReadOemSupplier();
//            Console.WriteLine(Constants.Oem);

//            //Read the Config XML File
//            List<XMLConfigFile> XmlConfigFile = Constants.ReadXML();

//            //Test case
//            List<StringFormat> lstofStng = new List<StringFormat>();
//            StringFormat stng = new StringFormat();
//            stng.AttrName = "B_EDSNo";
//            stng.PartName = "VW416A-41-10-TT-U01-001_A";
//            stng.PartType = "MakeDetail";
//            stng.ReplaceName = "120-123-1234-5";
//            stng.PartNewName = "";
//            lstofStng.Add(stng);
//            StringFormat stng1 = new StringFormat();
//            stng1.AttrName = "B_EDSNo";
//            stng1.PartName = "VW416A-41-10-TT-U01_A";
//            stng1.PartType = "Unit";
//            stng1.ReplaceName = "120-123-1234-5";
//            stng1.PartNewName = "";
//            lstofStng.Add(stng1);

//            //Update the RegexFiles

//            UpdateAndReplaceString(ref lstofStng, XmlConfigFile);

//        }

//        public static void UpdateAndReplaceString(ref List<StringFormat> InputDataCollectionList, List<XMLConfigFile> XmlConfigFile)
//        {

//            if (InputDataCollectionList != null)
//            {
//                foreach (StringFormat InputData in InputDataCollectionList)
//                {
//                    // Get the input Attribute Name and the Part Type
//                    string InputAttrValue = InputData.AttrName;
//                    string InputPrtType = InputData.PartType;
//                    // Collect the Config file data which matches with the Attribute Name and Part Type                                                       
//                    var FilteredConfigData = XmlConfigFile.Where(a => a.AttributeName == InputAttrValue && a.PartType ==InputPrtType);
//                    string PrefixFromConfig = "";
//                    string SuffixFromConfig = "";

//                    String ReplacedValue = "";
//                    foreach(XMLConfigFile ConfigData in FilteredConfigData)
//                    {
//                       ReplacedValue=SubstituteRegex(InputData.PartName, ConfigData.RegexMatch, ConfigData.RegexReplace);
//                        PrefixFromConfig = ConfigData.PrefixText;
//                        SuffixFromConfig = ConfigData.SuffixText;
//                        break;
//                    }
//                    //Replace with the matched value
//                    if (ReplacedValue != "")
//                    {
//                        InputData.PartNewName = InputData.ReplaceName + ReplacedValue;
//                    }
//                    //Add Constant Prefix value to the replaced Value
//                    if (PrefixFromConfig != "")
//                    {
//                        InputData.PartNewName = PrefixFromConfig + InputData.PartNewName;
//                    }
//                    //Add Suffix to the replaced value
//                    if (SuffixFromConfig != "")
//                    {
//                        InputData.PartNewName =  InputData.PartNewName +SuffixFromConfig;
//                    }
//                }
//            }
                       
//        }

//        public static string SubstituteRegex(string input, string Pattern, string ReplaceValue)
//        {
//            string Output = "";

//            Regex objRegex;
//            Match objRegexMatch;
//            string[] GroupNames;
//            int[] GroupNumbers;
//            objRegex = new Regex(Pattern, RegexOptions.IgnoreCase);

//            if (objRegex.IsMatch(input))
//            {
//                //objRegexMatch = objRegex.Match(input);
//                //Group GroupNum = objRegexMatch.Groups[7];
//                //string s = GroupNum.Value;
//                //GroupNames = objRegex.GetGroupNames();
//                //GroupNumbers = objRegex.GetGroupNumbers();

//                Output = Regex.Replace(input, Pattern, ReplaceValue);

//            }
//            return Output;
//        }


//    }
//}
