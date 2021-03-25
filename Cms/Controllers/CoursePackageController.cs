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
    public class CoursePackageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCourseList(int start, int length)
        {
            using (var db = new dbContext())
            {
                var search = Request.Query["search[value]"].ToString();
                var query = db.TCoursePackage.Include(x => x.CreateUser).Where(t => t.IsDelete == false);
                var recordsTotal = query.Count();
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(t => t.Name.Contains(search));
                }
                var recordsFiltered = query.Count();

                var list = query.Where(t => t.IsDelete == false).OrderBy(t => t.CreateTime).Skip(start).Take(length).ToList();
                return Json(new { data = list, recordsTotal = recordsTotal, recordsFiltered = recordsFiltered });
            }
        }
        public IActionResult CourseEdit(Guid id)
        {

            if (id == default)
            {
                return View(new TCoursePackage());
            }
            else
            {
                using (var db = new dbContext())
                {
                    var UserSys = db.TCoursePackage.Where(t => t.Id == id).FirstOrDefault();
                    return View(UserSys);
                }
            }

        }


        public bool CourseSave(TCoursePackage user)
        {
            var userid = Guid.Parse(HttpContext.Session.GetString("userid"));
            using (var db = new dbContext())
            {

                if (user.Id == default)
                {
                    //执行添加
                    user.Id = Guid.NewGuid();
                    user.IsDelete = false;
                    user.CreateTime = DateTime.Now;
                    user.CreateUserId = userid;
                    db.TCoursePackage.Add(user);
                }
                else
                {
                    //执行修改
                    var dbUserSys = db.TCoursePackage.Where(t => t.Id == user.Id).FirstOrDefault();

                    dbUserSys.Name = user.Name;
                    dbUserSys.UpdateTime = user.UpdateTime;
                    dbUserSys.UpdateUserId = userid;
                }

                db.SaveChanges();
                return true;
            }
        }

        public JsonResult CourseDelete(Guid id)
        {
            using (var db = new dbContext())
            {
                var userid = Guid.Parse(HttpContext.Session.GetString("userid"));
                var user = db.TCoursePackage.Where(t => t.Id == id).FirstOrDefault();

                user.IsDelete = true;
                user.DeleteTime = DateTime.Now;
                user.DeleteUserId = userid;
                db.SaveChanges();

                var data = new { status = true, msg = "删除成功！" };
                return Json(data);
            }

        }
    }
}
