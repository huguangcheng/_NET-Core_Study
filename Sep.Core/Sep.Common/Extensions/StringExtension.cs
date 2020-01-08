using System;

namespace Sep.Common
{
    public static  class StringExtension
    {
        /// <summary>
        /// 求oldstr字符串中出现newstr字符串的次数
        /// </summary>
        /// <param name="oldstr"></param>
        /// <param name="newstr"></param>
        /// <returns></returns>
        public static int StringAppearCount(this string oldstr,string newstr)
        {
            return oldstr.Split(newstr).Length - 1;
        }
    }
}
