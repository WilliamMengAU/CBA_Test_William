using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CBA_Test_ConsoleApp.Models
{
    public enum ProcessRulesResultCode
    {
        Success = 0,
        PartlyError = 1,
        AllFailed = 2
    }

    public class ProcessRulesResult
    {
        public ProcessRulesResultCode ResultCode { get; set; } = ProcessRulesResultCode.AllFailed;
        public int TotalRules { get; set; } = 0;
        public int TotalSuccessRules { get; set; } = 0;
        public int TotalDisabledRules { get; set; } = 0;
        public int TotalFailedRules { get; set; } = 0;
        public string Message { get; set; } = string.Empty;

        public string ToJsonStr()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(this);
        }

    }
}
