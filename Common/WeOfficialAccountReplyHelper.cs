using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 微信公众号回复帮助类
    /// </summary>
    public class WeOfficialAccountReplyHelper
    {
        /// <summary>
        /// 回复文本消息
        /// </summary>
        /// <param name="toUser">接收方帐号（收到的OpenID）</param>
        /// <param name="fromUser">开发者微信号</param>
        /// <param name="content">回复的消息内容（换行：在content中能够换行，微信客户端就支持换行显示）</param>
        /// <returns></returns>
        public static string TextReply(string toUser, string fromUser, string content)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<xml>");
            sb.Append($"<ToUserName><![CDATA[{toUser}]]></ToUserName>");
            sb.Append($"<FromUserName><![CDATA[{fromUser}]]></FromUserName>");
            sb.Append($"<CreateTime>{DateTimeHelper.TimeToUnix(DateTime.Now)}</CreateTime>");
            sb.Append($"<MsgType><![CDATA[text]]></MsgType>");
            sb.Append($"<Content><![CDATA[{content}]]></Content>");
            sb.Append($"</xml>");
            return sb.ToString();
        }
    }
}
