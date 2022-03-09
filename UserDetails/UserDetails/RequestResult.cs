using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDetails
{
    public enum RequestResultType
    {
        UserQuit,
        InvalidEntry,
        ValidEntry
    }

    public class RequestResult
    {
        public RequestResult(RequestResultType resultType, string text)
        {
            this.ResultType = resultType;
            this.Text = text;
        }

        public RequestResultType ResultType { get; set; }

        public string Text { get; set; }
    }
}
