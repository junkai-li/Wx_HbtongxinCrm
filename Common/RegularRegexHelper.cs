using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 常用正则
    /// </summary>
    public class RegularRegexHelper
    {
        /// <summary>
        /// 校验手机号码
        /// true：正确手机号码
        /// </summary>
        /// <param name="phoneNum">手机号</param>
        /// <returns></returns>
        public static bool CheckPhoneNumber(string phoneNum)
        {
            if (string.IsNullOrWhiteSpace(phoneNum) || phoneNum.Length < 11)
            {
                return false;
            }
            Regex regex = new Regex(@"^1[3456789]\d{9}$");
            if (regex.IsMatch(phoneNum))
            {
                return true;
            }
            return false;
        }
    }
}
