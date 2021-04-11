using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class WxinFoStrDto
    {
        public int ChildNameLength { get; set; }
        public int NameLength { get; set; }
        public string Name { get; set; }
        public string ChildName { get; set; }

        public string CreateTime { get; set; }
    }
}
