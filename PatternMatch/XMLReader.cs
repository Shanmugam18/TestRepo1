using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatch
{
      class XMLConfigFile
    {
        private string attributeName;
        private string partType;
        private string regexMatch;
        private string regexReplace;
        private string prefixText;
        private string suffixText;
        private string format;

        public XMLConfigFile()
        {

        }

        public string AttributeName
        {
            get { return attributeName; }
            set { attributeName = value; }
        }

        public string PartType
        {
            get { return partType; }
            set { partType = value; }
        }

        public string RegexMatch
        {
            get { return regexMatch; }
            set { regexMatch = value; }
        }

        public string RegexReplace
        {
            get { return regexReplace; }
            set { regexReplace = value; }
        }

        public string PrefixText
        {
            get { return prefixText; }
            set { prefixText = value; }
        }

        public string SuffixText
        {
            get { return suffixText; }
            set { suffixText = value; }
        }

        public string Format
        {
            get { return format; }
            set { format = value; }
        }
    }

    
}
