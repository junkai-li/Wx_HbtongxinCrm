using Repository.Database.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
   public  class TMember : CUD_User
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 班级
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 家长姓名
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 小孩姓名
        /// </summary>
        public string ChildName { get; set; }
        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        ///   课程名称
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// 课程次数
        /// </summary>
        public int CourseCount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
