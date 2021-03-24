using Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    /// <summary>
    /// 发送消息日志表
    /// </summary>
    public class TMemberWxPhoneMessgeLog : CUD
    {
        public TMemberWxPhone TMember_Wx_Phone { get; set; }
        public string TMemberWxPhoneId { get; set; } 
        public string Content { get; set; }

    }
}
