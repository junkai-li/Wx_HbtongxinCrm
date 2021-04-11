using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Actions
{
    public class WeOfficialAction
    {
        public static string GetWxinfoStr(List<WxinFoStrDto> data)
        {
            int MaxNameLength = data.Select(x => x.NameLength).Max();
            int MaxChildNameLength = data.Select(x => x.ChildNameLength).Max();
            string infoStr = "上课记录如下：\n";
            //计算占位符 
            string hangcontent = "{0}";
            for (int i = 2; i < MaxChildNameLength; i++)
            {
                hangcontent += "\t";
            }
            if (2 == MaxChildNameLength)
            {
                hangcontent += "\t";
            } 
            hangcontent += "{1}";
            for (int i = 3; i < MaxNameLength; i++)
            {
                hangcontent += "\t";
            }
            if (3 == MaxNameLength)
            {
                hangcontent += "\t";
            }
            hangcontent += "{2}\n";
            var hang = string.Format(hangcontent, "姓名", "课程名", "上课时间");
            infoStr += hang;
            foreach (var item in data)
            {
                string itemcontent = "{0}";
                for (int i = item.ChildName.Length; i < MaxChildNameLength; i++)
                {
                    itemcontent += "\t";
                }
                if (item.ChildName.Length == MaxChildNameLength)
                {
                    itemcontent += "\t";
                }
                itemcontent += "{1}";
                for (int i = item.Name.Length; i < MaxNameLength; i++)
                {
                    itemcontent += "\t";
                }
                if (item.Name.Length == MaxNameLength)
                {
                    itemcontent += "\t";
                }
                itemcontent += "{2}\n";
                var cont = string.Format(itemcontent, item.ChildName, item.Name, item.CreateTime);
                infoStr += cont;
            }
            infoStr += "\n上课时间仅供参考";
            return infoStr;


        }
    }
}
