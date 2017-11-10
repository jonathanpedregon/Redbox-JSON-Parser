using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redbox_JSON_Parser.Exceptions
{
    public class EmptyJsonException : ScreenBuddyException
    {
        public EmptyJsonException()
        {
            SubjectLine = "ScreenBuddy Error: An Empty JSON Was Returned";
            Body = "An empty JSON was returned from the RedBox API.\nThe database has not been updated.";
        }
    }
}
