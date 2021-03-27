using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class XmlHelper
    {
        /// <summary>  
        /// 清除xml中的不合法字符  
        /// </summary>  
        /// <remarks>  
        /// 无效字符：  
        /// 0x00 - 0x08  
        /// 0x0b - 0x0c  
        /// 0x0e - 0x1f  
        /// </remarks>  
        public static string CleanInvalidCharsForXML(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            else
            {
                StringBuilder checkedStringBuilder = new StringBuilder();
                char[] chars = input.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    int charValue = Convert.ToInt32(chars[i]);

                    if ((charValue >= 0x00 && charValue <= 0x08) || (charValue >= 0x0b && charValue <= 0x0c) || (charValue >= 0x0e && charValue <= 0x1f))
                        continue;
                    else
                        checkedStringBuilder.Append(chars[i]);
                }
                return checkedStringBuilder.ToString();
            }
        }
    }
}
