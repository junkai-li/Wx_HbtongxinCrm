using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WebApi.Controllers
{
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class WeOfficialAccountController : ControllerBase
    {
        #region 公众号自动回复服务
        [HttpGet("RobotsReply")]
        public ContentResult RobotsReply(string signature, string timestamp, string nonce, string echostr)
        {
            //暂不验证
            return Content(string.IsNullOrWhiteSpace(echostr) ? "success" : echostr);
        }

        [HttpPost("RobotsReply")]
        public ContentResult RobotsReply()
        {
            try
            {
                using (Stream stream = HttpContext.Request.Body)
                {
                    byte[] buffer = new byte[HttpContext.Request.ContentLength.Value];
                    stream.Read(buffer, 0, buffer.Length);
                    string paramentStr = Encoding.UTF8.GetString(buffer);
                    if (string.IsNullOrWhiteSpace(paramentStr))
                    {
                        return Content(null);
                    }
                    XmlDocument requestXml = new XmlDocument();
                    requestXml.LoadXml(XmlHelper.CleanInvalidCharsForXML(paramentStr));
                    XmlElement xmlElement = requestXml.DocumentElement;
                    string userOpenID = xmlElement.SelectSingleNode("FromUserName").InnerText;      //发送方 用户OpenID
                    string developID = xmlElement.SelectSingleNode("ToUserName").InnerText;         //接收方 公众号ID
                    string msgType = xmlElement.SelectSingleNode("MsgType").InnerText;              //消息类型
                    switch (msgType)
                    {
                        case "event":
                            {
                                //事件类型
                                string eventType = xmlElement.SelectSingleNode("Event").InnerText;
                                switch (eventType)
                                {
                                    case "subscribe":
                                        {
                                            //订阅事件
                                            return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "终于等到你~\n\n请发送手机号码绑定会员信息"));
                                        }
                                    default:
                                        return Content(null);
                                }
                            }
                        case "text":
                            {
                                //消息类型
                                string content = xmlElement.SelectSingleNode("Content").InnerText.Trim();      //消息内容
                                if (string.IsNullOrWhiteSpace(content))
                                {
                                    return Content(null);
                                }

                                //绑定手机号
                                if (content.Length == 11 && long.TryParse(content, out long phone))
                                {
                                    if (!RegularRegexHelper.CheckPhoneNumber(content))
                                    {
                                        return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "手机号码不正确"));
                                    }
                                    using (var db = new dbContext())
                                    {
                                        if (db.TMemberWxPhone.Any(p => p.PhoneNumber == content))
                                        {
                                            return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "此手机号码已绑定个人信息"));
                                        }
                                        if (!db.TMember.Any(p => p.PhoneNumber == content))
                                        {
                                            return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "会员信息暂未录入，请稍后重试"));
                                        }
                                        TMemberWxPhone wxPhone = new TMemberWxPhone()
                                        {
                                            PhoneNumber = content,
                                            WeixinCode = userOpenID,
                                            CreateTime = DateTime.Now
                                        };
                                        db.Add(wxPhone);
                                        if (db.SaveChanges() > 0)
                                        {
                                            return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "绑定成功"));
                                        }
                                        return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "绑定失败，请稍后重试"));
                                    }
                                }

                                //关键词指令
                                switch (content)
                                {
                                    case "1":
                                        //查看全部课程套餐
                                        break;
                                    case "2":
                                        //查看我的课程套餐
                                        break;
                                    case "3":
                                        //查看一个月内上课记录
                                        break;
                                    default:
                                        break;
                                }
                                return Content(null);
                            }
                        default:
                            return Content(null);
                    }
                }
            }
            catch (Exception)
            {
                return Content(null);
            }
        }
        #endregion
    }
}
