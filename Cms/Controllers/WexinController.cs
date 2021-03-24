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
    public class WexinController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetWeChatNoPubliList(int start, int length)
        {
            using (var db = new dbContext())
            {
                var search = Request.Query["search[value]"].ToString();
                var query = db.TWeChatNoPublicTemplate.Include(x => x.CreateUser).Where(t => t.IsDelete == false);
                var recordsTotal = query.Count();
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(t => t.Content.Contains(search));
                }
                var recordsFiltered = query.Count();

                var list = query.Where(t => t.IsDelete == false).OrderBy(t => t.CreateTime).Skip(start).Take(length).ToList();
                return Json(new { data = list, recordsTotal = recordsTotal, recordsFiltered = recordsFiltered });
            }
        }
        public IActionResult WexinEdit(Guid id)
        {

            if (id == default)
            {
                return View(new TWeChatNoPublicTemplate());
            }
            else
            {
                using (var db = new dbContext())
                {
                    var UserSys = db.TWeChatNoPublicTemplate.Where(t => t.Id == id).FirstOrDefault();
                    return View(UserSys);
                }
            }

        }


        public bool WexinSave(TWeChatNoPublicTemplate user)
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
                    db.TWeChatNoPublicTemplate.Add(user);
                }
                else
                {
                    //执行修改
                    var dbUserSys = db.TWeChatNoPublicTemplate.Where(t => t.Id == user.Id).FirstOrDefault();

                    dbUserSys.Content = user.Content; 
                    dbUserSys.UpdateTime = user.UpdateTime;
                    dbUserSys.UpdateUserId = userid; 
                }

                db.SaveChanges();
                return true;
            }
        }

        public JsonResult WexinDelete(Guid id)
        {
            using (var db = new dbContext())
            {
                var userid = Guid.Parse(HttpContext.Session.GetString("userid"));
                var user = db.TWeChatNoPublicTemplate.Where(t => t.Id == id).FirstOrDefault();

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
