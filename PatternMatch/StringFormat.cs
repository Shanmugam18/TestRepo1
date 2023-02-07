using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatch
{

    public class StringFormat
    {

        private string partNumber;
        private string replaceName;
        private string partType;
        private string partNewName;
        private string attrName;
        public  StringFormat()
        {
            
        }

        public string PartName
        {
            get {return partNumber; }
            set { partNumber = value; }//
        }

        public string  ReplaceName 
        {
            get { return replaceName; }
            set { replaceName = value; }//
        }

        public string PartType
        {
            get { return partType; }
            set { partType = value; }//
        }
        public String PartNewName
        {
            get { return partNewName; }
            set{ partNewName = value; } 
        }
        public string AttrName
        {
            get { return attrName; }
            set { attrName = value; } //
        }
    }
}
