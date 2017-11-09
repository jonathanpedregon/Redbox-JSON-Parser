using System;

namespace Redbox_JSON_Parser.Exceptions
{
    public class InvalidJsonException : ScreenBuddyException
    {
        public InvalidJsonException(string Json)
        {
            SubjectLine = "ScreenBuddy Error: Invalid JSON Format Returned";
            Body = $"Unable to parse JSON at {DateTime.Now}\nThe database was not updated.\nThe provided JSON was: {Json}";
        }
    }
}
