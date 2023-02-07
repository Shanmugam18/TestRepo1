using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml;
using PatternMatch;

namespace PatternMatch
{

    public class ReplaceText //: IVCTReplaceRegex

    {
        /// <summary>
        /// The input string would be replaced by the Regex replace if it matched the Regex pattern
        /// </summary>
        /// <param name="lstofStng"> List of Input string</param>
        public void VCTReplacePattern(ref List<StringFormat> lstofStng)
        {
            //Read the OemSupplier Config file
            Constants.ReadOemSupplier();
            Console.WriteLine(Constants.Oem);

            //Read the Config XML File
            List<XMLConfigFile> XmlConfigFile = Constants.ReadXML();

            //Update the RegexFiles
            UpdateAndReplaceString(ref lstofStng, XmlConfigFile);
        }
        /// <summary>
        /// Input String will be replaced by the Regex value if it matches the Regex Pattern
        /// </summary>
        /// <param name="InputDataCollectionList"> Collection of Input String</param>
        /// <param name="XmlConfigFile">OEM Specific Config file containing the Regex Patterns</param>
       internal static void UpdateAndReplaceString(ref List<StringFormat> InputDataCollectionList, List<XMLConfigFile> XmlConfigFile)
        {

            if (InputDataCollectionList != null)
            {
                foreach (StringFormat InputData in InputDataCollectionList)
                {
                    // Get the input Attribute Name and the Part Type
                    string InputAttrValue = InputData.AttrName;
                    string InputPrtType = InputData.PartType;
                    // Collect the Config file data which matches with the Attribute Name and Part Type                                                       
                    var FilteredConfigData = XmlConfigFile.Where(a => a.AttributeName == InputAttrValue && a.PartType == InputPrtType);
                    string PrefixFromConfig = "";
                    string SuffixFromConfig = "";

                    String ReplacedValue = "";
                    foreach (XMLConfigFile ConfigData in FilteredConfigData)
                    {
                        ReplacedValue = SubstituteRegex(InputData.PartName, ConfigData.RegexMatch, ConfigData.RegexReplace);
                        PrefixFromConfig = ConfigData.PrefixText;
                        SuffixFromConfig = ConfigData.SuffixText;
                        break;
                    }
                    //Replace with the matched value
                    if (ReplacedValue != "")
                    {
                        InputData.PartNewName = InputData.ReplaceName + ReplacedValue;
                    }
                    //Add Constant Prefix value to the replaced Value
                    if (PrefixFromConfig != "")
                    {
                        InputData.PartNewName = PrefixFromConfig + InputData.PartNewName;
                    }
                    //Add Suffix to the replaced value
                    if (SuffixFromConfig != "")
                    {
                        InputData.PartNewName = InputData.PartNewName + SuffixFromConfig;
                    }
                }
            }

        }
        /// <summary>
        /// Input string would be replaced by the value
        /// </summary>
        /// <param name="input">Input String</param>
        /// <param name="Pattern">Pattern to match the input String</param>
        /// <param name="ReplaceValue">Value to be replaced upon matching the input value</param>
        /// <returns></returns>
        internal static string SubstituteRegex(string input, string Pattern, string ReplaceValue)
        {
            string Output = "";

            Regex objRegex;
            Match objRegexMatch;
            string[] GroupNames;
            int[] GroupNumbers;
            objRegex = new Regex(Pattern, RegexOptions.IgnoreCase);

            if (objRegex.IsMatch(input))
            {
                Output = Regex.Replace(input, Pattern, ReplaceValue);
            }
            return Output;
        }
    }
}
