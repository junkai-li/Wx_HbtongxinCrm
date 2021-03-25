using Repository.Database.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
   public class TCoursePackage : CUD_User
    {
        /// <summary>
        /// 课程名称
        /// </summary>
        public string Name { get; set; }
    }
}
