using Repository.Database.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    /// <summary>
    /// 上课日志
    /// </summary>
   public  class TMenmberGoLog : CUD_User
    {
        public Guid MemberId { get; set; }
        public TMember Member { get; set; }

        /// <summary>
        /// 上课课程次数
        /// </summary>
        public int GoCourseCount { get; set; } 
        /// <summary>
        ///剩余课程次数
        /// </summary>
        public int LastCourseCount { get; set; }
    }
}
