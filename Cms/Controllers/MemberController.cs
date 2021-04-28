using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cms.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new dbContext())
            {
                List<TCoursePackage> coursePackageList = db.TCoursePackage.Where(x => x.IsDelete == false).ToList();
                ViewData["coursePackageList"] = coursePackageList;
                return View();
            }
          
        }

        [HttpGet]
        public JsonResult GetMemberList(int start, int length,string select)
        {
            using (var db = new dbContext())
            {
                var search = Request.Query["search[value]"].ToString();
                var query = db.TMember.Include(x=>x.CoursePackage).Include(x => x.CreateUser).Where(t => t.IsDelete == false);
                var recordsTotal = query.Count();
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(t => t.ChildName.Contains(search) || t.ParentName.Contains(search) || t.PhoneNumber.Contains(search) || t.CoursePackage.Name.Contains(search) || t.SchoolName.Contains(search) || t.Remarks.Contains(search));
                }
                if (!string.IsNullOrEmpty(select))
                {
                    query = query.Where(t => t.CoursePackageId== Guid.Parse(select));
                }
                var recordsFiltered = query.Count();

                var list = query.Where(t => t.IsDelete == false).OrderByDescending(t => t.CreateTime).Skip(start).Take(length).ToList();
       
                return Json(new { data = list, recordsTotal = recordsTotal, recordsFiltered = recordsFiltered });
            }
        }
        public IActionResult MemberEdit(Guid id)
        {

            if (id == default)
            {
                using (var db = new dbContext())
                {
                    List<TCoursePackage> coursePackageList = db.TCoursePackage.Where(x => x.IsDelete == false).ToList();
                    ViewData["coursePackageList"] = coursePackageList;

                    return View(new TMember());
                }
            }
            else
            {
                using (var db = new dbContext())
                {
                    List<TCoursePackage> coursePackageList = db.TCoursePackage.Where(x => x.IsDelete == false).ToList();
                    ViewData["coursePackageList"] = coursePackageList;
                    var UserSys = db.TMember.Where(t => t.Id == id).FirstOrDefault();
                    return View(UserSys);
                }
            }

        }


        public JsonResult MemberSave(TMember user)
        {
            var userid = Guid.Parse(HttpContext.Session.GetString("userid"));
            using (var db = new dbContext())
            {

                if (user.Id == default)
                {
                   //查找是否有重复课程数据
                   var Member = db.TMember.Where(t => t.PhoneNumber == user.PhoneNumber&&t.CoursePackageId== user.CoursePackageId&&t.ChildName==user.ChildName).FirstOrDefault();
                    if (Member != null)
                    {
                        var jsondata= new { status = false, msg = "报名失败 当前课程孩子已经报名 请再原来的数据上修改或者删除历史数据！" };
                        return Json(jsondata);
                    }
                    //执行添加
                    user.Id = Guid.NewGuid();
                    user.IsDelete = false;
                    user.CreateTime = DateTime.Now;
                    user.CreateUserId = userid;
                   
                    db.TMember.Add(user);
                }
                else
                {
                    //执行修改
                    var dbUserSys = db.TMember.Where(t => t.Id == user.Id).FirstOrDefault();

                    dbUserSys.SchoolName = user.SchoolName;
                    dbUserSys.PhoneNumber = user.PhoneNumber;
                    dbUserSys.ParentName = user.ParentName;
                    dbUserSys.ChildName = user.ChildName;
                    dbUserSys.CourseCount = user.CourseCount;
                    dbUserSys.CoursePackageId = user.CoursePackageId;
                    dbUserSys.UpdateTime = user.UpdateTime;
                    dbUserSys.UpdateUserId = userid;
                    dbUserSys.Remarks = user.Remarks;
                    dbUserSys.Class = user.Class;
                }

                db.SaveChanges();
                var data = new { status = true, msg = "新增成功！" };
                return Json(data);
            }
        }

        public JsonResult MemberDelete(Guid id)
        {
            using (var db = new dbContext())
            {
                var userid = Guid.Parse(HttpContext.Session.GetString("userid"));
                var user = db.TMember.Where(t => t.Id == id).FirstOrDefault();

                user.IsDelete = true;
                user.DeleteTime = DateTime.Now;
                user.DeleteUserId = userid;
                db.SaveChanges();

                var data = new { status = true, msg = "删除成功！" };
                return Json(data);
            }

        }

        public JsonResult GoMember(Guid id)
        {
            using (var db = new dbContext())
            {
                var userid = Guid.Parse(HttpContext.Session.GetString("userid"));
                var Member = db.TMember.Where(t => t.Id == id).FirstOrDefault();
                Member.CourseUpdate = DateTime.Now;
                Member.CourseUpdateUserId = userid;
                Member.CourseCount -= 1;
                TMenmberGoLog goLog = new TMenmberGoLog();
                goLog.Id = Guid.NewGuid();
                goLog.IsDelete = false;
                goLog.CreateTime = DateTime.Now;
                goLog.CreateUserId = userid;
                goLog.GoCourseCount = 1;
                goLog.LastCourseCount = Member.CourseCount;
                goLog.MemberId = Member.Id;
                db.TMenmberGoLog.Add(goLog);
                db.SaveChanges();

                var data = new { status = true, msg = "上课成功！" };
                return Json(data);
            }

        }

        public IActionResult IndexGoLog()
        {
            using (var db = new dbContext())
            {
                List<TCoursePackage> coursePackageList = db.TCoursePackage.Where(x => x.IsDelete == false).ToList();
                ViewData["coursePackageList"] = coursePackageList;
                ViewData["memberid"] = Request.Query["memberid"];
                return View();
            } 
        }

        [HttpGet]
        public JsonResult GetMemberGoLogList(int start, int length, string select,Guid memberId)
        {
            using (var db = new dbContext())
            {
                var search = Request.Query["search[value]"].ToString();
                var query = db.TMenmberGoLog.Include(x => x.Member).Include(x => x.Member.CoursePackage).Include(x => x.CreateUser).Where(t => t.IsDelete == false);
                var recordsTotal = query.Count();
                if (!string.IsNullOrEmpty(memberId.ToString())&& memberId!=Guid.Empty)
                {
                    query = query.Where(t =>t.MemberId== memberId);
                }
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(t => t.Member.ChildName.Contains(search) || t.Member.ParentName.Contains(search) || t.Member.PhoneNumber.Contains(search) || t.Member.CoursePackage.Name.Contains(search) || t.Member.SchoolName.Contains(search));
                }
                if (!string.IsNullOrEmpty(select))
                {
                    query = query.Where(t => t.Member.CoursePackageId == Guid.Parse(select));
                }
                var recordsFiltered = query.Count();

                var list = query.Where(t => t.IsDelete == false).OrderByDescending(t => t.CreateTime).Skip(start).Take(length).ToList();

                return Json(new { data = list, recordsTotal = recordsTotal, recordsFiltered = recordsFiltered });
            }
        }

        public JsonResult MemberGoLogDelete(Guid id)
        {
            using (var db = new dbContext())
            {
                var userid = Guid.Parse(HttpContext.Session.GetString("userid"));
                var user = db.TMenmberGoLog.Where(t => t.Id == id).FirstOrDefault();

                user.IsDelete = true;
                user.DeleteTime = DateTime.Now;
                user.DeleteUserId = userid;
                var member = db.TMember.Where(t => t.Id == user.MemberId).FirstOrDefault();
                member.CourseCount += user.GoCourseCount;
                //找到对应的课程 恢复次数 
                db.SaveChanges();

                var data = new { status = true, msg = "删除成功！" };
                return Json(data);
            }

        }
    }
}
