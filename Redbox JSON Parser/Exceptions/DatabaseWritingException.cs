using System;
using System.Text;

namespace Redbox_JSON_Parser.Exceptions
{
    public class DatabaseWritingException : ScreenBuddyException
    {
        public DatabaseWritingException(RedboxMovie movie)
        {
            SubjectLine = "ScreenBuddy Error: Error During A Database Write";
            var bodySb = new StringBuilder();
            bodySb.AppendLine($"Error occured while writing to the ScreenBuddy database at {DateTime.Now}");
            bodySb.AppendLine($"The RedBox movie that caused the error was: {movie.ToString()}");
            bodySb.AppendLine("Only some of the new records were updated. None of the old records were removed.");
        }
    }
}
