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
using WebApi.Actions;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiVersionNeutral]
    [Route("api/WeOfficialAccount/[action]")]
    [ApiController]
    public class WeOfficialAccountController : ControllerBase
    {
        private readonly static string _defaultMessage = "童心教育机器人为你服务，发送关键词进行查询\n\n回复【1】查看全部课程套餐\n\n回复【2】查看我的课程套餐\n\n回复【3】查看近十天上课记录\n\n回复【4】查看近二十天上课记录\n\n回复【5】查看近一个月上课记录";

        #region 公众号自动回复服务
        [HttpGet]
        public ContentResult RobotsReply(string signature, string timestamp, string nonce, string echostr)
        {
            //暂不验证
            return Content(string.IsNullOrWhiteSpace(echostr) ? "success" : echostr);
        }

        [HttpPost]
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
                        // 事件类型
                        case "event":
                            {
                                string eventType = xmlElement.SelectSingleNode("Event").InnerText;
                                switch (eventType)
                                {
                                    case "subscribe":
                                        {
                                            //订阅事件
                                            return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "终于等到你~\n\n请发送手机号码绑定会员信息"));
                                        }
                                    default:
                                        break;
                                }
                            }
                            break;
                        // 消息类型
                        case "text":
                            {
                                string content = xmlElement.SelectSingleNode("Content").InnerText.Trim();      //消息内容
                                if (string.IsNullOrWhiteSpace(content))
                                {
                                    return Content(null);
                                }

                                //绑定手机号码
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
                                            return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "此手机号码已绑定个人信息\n" + _defaultMessage));
                                        }
                                        if (!db.TMember.Any(p => p.PhoneNumber == content))
                                        {
                                            return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "您的会员信息暂未录入，请联系工作人员"));
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
                                            return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, $"绑定成功\n{_defaultMessage}"));
                                        }
                                        return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "绑定失败，请稍后重试"));
                                    }
                                }

                                //校验是否绑定手机号码
                                using (var db = new dbContext())
                                {
                                    if (!db.TMemberWxPhone.Any(p => p.WeixinCode == userOpenID))
                                    {
                                        return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "河北童心教育机构智能机器人提示您,暂未绑定手机号码，请发送手机号码进行绑定"));
                                    }
                                }

                                // 关键词处理
                                switch (content)
                                {
                                    // 查看全部课程套餐
                                    case "1":
                                        {
                                            using (var db = new dbContext())
                                            {
                                                List<string> courses = db.TCoursePackage.Where(p => !p.IsDelete).Select(p => p.Name).ToList();
                                                if (courses == null)
                                                {
                                                    return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "暂无课程信息"));
                                                }
                                                string courseInfoStr = $"全部课程如下：\n\n{string.Join("\n\n", courses)}";
                                                return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, courseInfoStr));
                                            }
                                        }
                                    // 查看我的课程套餐 
                                    case "2":
                                        {
                                            using (var db = new dbContext())
                                            {
                                                var data = (from m in db.TMember
                                                            join w in db.TMemberWxPhone on m.PhoneNumber equals w.PhoneNumber
                                                            join c in db.TCoursePackage on m.CoursePackageId equals c.Id
                                                            where w.WeixinCode == userOpenID && m.IsDelete==false  
                                                            select new
                                                            {
                                                                contents = $"{m.ChildName}的{c.Name}剩余：{m.CourseCount}次"
                                                            }).ToList();
                                                if (data == null)
                                                {
                                                    return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "暂无课程信息"));
                                                }
                                                string myCourseInfoStr = $"您的课程信息如下：\n{string.Join("\n", data.Select(p => p.contents))}";
                                                return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, myCourseInfoStr));
                                            }
                                        }
                                    // 查看近十天上课记录
                                    case "3":
                                        {
                                            using (var db = new dbContext())
                                            {
                                                var data = (from m in db.TMember
                                                            join w in db.TMemberWxPhone on m.PhoneNumber equals w.PhoneNumber
                                                            join g in db.TMenmberGoLog on m.Id equals g.MemberId into g2
                                                            from g in g2.DefaultIfEmpty()
                                                            join c in db.TCoursePackage on m.CoursePackageId equals c.Id
                                                            where w.WeixinCode == userOpenID && g.CreateTime >= DateTime.Now.AddDays(-10) && m.IsDelete == false
                                                            orderby g.CreateTime descending
                                                            select new WxinFoStrDto
                                                            {
                                                                ChildNameLength = m.ChildName.Length,
                                                                NameLength = c.Name.Length,
                                                                Name = c.Name,
                                                                ChildName = m.ChildName,
                                                                CreateTime = g.CreateTime.ToString("MM月dd号 HH点"),
                                                            }).ToList();
                                                if (data.Count == 0)
                                                {
                                                    return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "暂无上课记录"));
                                                }
                                                string infoStr = WeOfficialAction.GetWxinfoStr(data);
                                                return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, infoStr));
                                            }
                                        }
                                    // 查看近二十天上课记录
                                    case "4":
                                        {
                                            using (var db = new dbContext())
                                            { 
                                                var data = (from m in db.TMember
                                                            join w in db.TMemberWxPhone on m.PhoneNumber equals w.PhoneNumber
                                                            join g in db.TMenmberGoLog on m.Id equals g.MemberId into g2
                                                            from g in g2.DefaultIfEmpty()
                                                            join c in db.TCoursePackage on m.CoursePackageId equals c.Id
                                                            where w.WeixinCode == userOpenID && g.CreateTime >= DateTime.Now.AddDays(-20) && m.IsDelete == false
                                                            orderby g.CreateTime descending
                                                            select new WxinFoStrDto
                                                            {
                                                                ChildNameLength = m.ChildName.Length,
                                                                NameLength = c.Name.Length,
                                                                Name = c.Name,
                                                                ChildName = m.ChildName,
                                                                CreateTime = g.CreateTime.ToString("MM月dd号 HH点"),
                                                            }).ToList();
                                                if (data.Count == 0)
                                                {
                                                    return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "暂无上课记录"));
                                                }
                                                string infoStr = WeOfficialAction.GetWxinfoStr(data);
                                                return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, infoStr));
                                            }
                                        }
                                    // 查看近一个月上课记录
                                    case "5":
                                        {
                                            using (var db = new dbContext())
                                            {
                                                var data = (from m in db.TMember
                                                            join w in db.TMemberWxPhone on m.PhoneNumber equals w.PhoneNumber
                                                            join g in db.TMenmberGoLog on m.Id equals g.MemberId into g2
                                                            from g in g2.DefaultIfEmpty()
                                                            join c in db.TCoursePackage on m.CoursePackageId equals c.Id
                                                            where w.WeixinCode == userOpenID && g.CreateTime >= DateTime.Now.AddMonths(-1) && m.IsDelete == false
                                                            orderby  g.CreateTime descending
                                                            select new WxinFoStrDto
                                                            {
                                                                ChildNameLength = m.ChildName.Length,
                                                                NameLength = c.Name.Length,
                                                                Name = c.Name,
                                                                ChildName = m.ChildName,
                                                                CreateTime = g.CreateTime.ToString("MM月dd号 HH点"),
                                                            }).ToList();
                                                if (data.Count == 0)
                                                {
                                                    return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, "暂无上课记录"));
                                                }
                                                string infoStr = WeOfficialAction.GetWxinfoStr(data);
                                                return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, infoStr));
                                            }
                                        }
                                    default:
                                        break;
                                }

                                //文本消息默认回复
                                return Content(WeOfficialAccountReplyHelper.TextReply(userOpenID, developID, _defaultMessage));
                            }
                        default:
                            break;
                    }
                    return Content(null);
                }
            }
            catch (Exception)
            {
                return Content(null);
            }
        }


        [HttpGet]
        public string ceshi()
        {
            using (var db = new dbContext())
            {
                var data = (from m in db.TMember
                            join w in db.TMemberWxPhone on m.PhoneNumber equals w.PhoneNumber
                            join g in db.TMenmberGoLog on m.Id equals g.MemberId into g2
                            from g in g2.DefaultIfEmpty()
                            join c in db.TCoursePackage on m.CoursePackageId equals c.Id
                            where m.IsDelete == false
                            orderby g.CreateTime descending
                            select new WxinFoStrDto
                            {
                                ChildNameLength = m.ChildName.Length,
                                NameLength = c.Name.Length,
                                Name = c.Name,
                                ChildName = m.ChildName,
                                CreateTime = g.CreateTime.ToString("MM月dd号 HH点"),
                            }).ToList(); ;
                string infoStr = WeOfficialAction.GetWxinfoStr(data);
                return infoStr;

            }
        }
        #endregion
    }
}
