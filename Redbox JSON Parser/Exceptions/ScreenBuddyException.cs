using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redbox_JSON_Parser.Exceptions
{
    public class ScreenBuddyException : Exception
    {
        public string SubjectLine { get; set; }
        public string Body { get; set; }
    }
}
