using System;
using System.Text;

namespace Redbox_JSON_Parser.Exceptions
{
    class DatabaseConnectionException : ScreenBuddyException
    {
        public DatabaseConnectionException()
        {
            SubjectLine = "ScreenBuddy Error: Unable to Connect To Database";
            var bodySb = new StringBuilder();
            bodySb.AppendLine($"Database writer was unable to write to the ScreenBuddy database at {DateTime.Now}");
            bodySb.AppendLine("The database has not been updated. Older values have not been removed.");
            Body = bodySb.ToString();
        }
    }
}
