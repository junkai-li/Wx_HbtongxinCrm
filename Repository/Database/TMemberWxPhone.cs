using Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    /// <summary>
    /// 手机号 微信绑定表  用于发送消息
    /// </summary>
    public class TMemberWxPhone : CUD
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 微信Code
        /// </summary>
        public string WeixinCode { get; set; }
    }
}
