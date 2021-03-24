using Repository.Bases;
using Repository.Database.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    public class TWeChatNoPublicTemplate: CUD_User
    {
        public string Content { get; set; }
    }
}
