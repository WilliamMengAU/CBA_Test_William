using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CBA_Test_ConsoleApp.Models
{
    public enum RuleResultCode
    {
        Success = 0,
        Error = 1
    }

    public class RuleResult
    {
        public RuleResultCode ResultCode { get; set; }
        public dynamic Value { get; set; }
        public string Message { get; set; }

        // functions
        public string OutputStr()
        {
            if (RuleResultCode.Success == ResultCode)
            {
                if (Value is float) return Value.ToString("0.##");
                else return Value.ToString();
            }
            else
            {
                return Message;
            }
        }

        public string JsonStr()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(this);
        }

    }
}
