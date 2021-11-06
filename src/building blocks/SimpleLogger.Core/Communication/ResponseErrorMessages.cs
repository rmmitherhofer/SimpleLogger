using System.Collections.Generic;

namespace Core.Communication
{

    public class ResponseErrorMessages
    {
        public IEnumerable<string> Messages { get; set; }

        public ResponseErrorMessages()
        {
            Messages = new List<string>();
        }
    }
}
