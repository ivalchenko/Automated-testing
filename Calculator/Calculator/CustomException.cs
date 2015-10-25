using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class CustomException : Exception
    {
        public CustomException(dynamic json)
            : base("Plep")
        {
            _Message = json.message;
        }

        public override string Message
        {
            get { return _Message; }
        }

        private string _Message;
    }
}
