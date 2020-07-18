using System;
using System.Collections.Generic;
using System.Text;

namespace WorkService.Core.Helpers
{
    /// <summary>
    /// 生成唯一序列的帮助类
    /// </summary>
    public class IDGenerateHelper
    {
        private static DateTime DateTime19700101 = new DateTime(1970, 1, 1);

        /// <summary>
        /// ID生成 规则：
        /// 当前时间减去new DateTime(1970, 01, 01)的秒值整数（ TotalSeconds）+ GUID （ToString("N")）
        /// 保证唯一 且 一定程度上有序
        /// </summary>
        /// <returns>唯一序列</returns>
        public static string GetTotalMillisecondsGuid32String()
        {
            var newId = GetTotalMilliseconds().ToString();
            newId += Guid.NewGuid().ToString("N");
            return newId;
        }

        /// <summary>
        /// 获取当前时间与19700101相隔总秒数
        /// </summary>
        /// <returns></returns>
        public static long GetTotalMilliseconds()
        {
            return Convert.ToInt64((DateTime.Now - DateTime19700101).TotalMilliseconds);
        }

        /// <summary>
        /// 生成时间戳+19位GUID
        /// 当前时间减去new DateTime(1970, 01, 01)的秒值整数
        /// GUID获取19位的唯一数字序列
        /// </summary>
        /// <returns></returns>
        public static string GetTotalMillisecondsGuid19String()
        {
            var newId = string.Format("{0}{1}", GetTotalMilliseconds(), GuidToLongId());
            return newId;
        }


        public static long GuidToLong(Guid guid)
        {
            return BitConverter.ToInt64(guid.ToByteArray(), 0);
        }


        /// <summary>
        /// 根据GUID获取19位的唯一数字序列
        /// </summary>
        /// <returns>唯一序列</returns>
        public static long GuidToLongId()
        {
            return GuidToLong(Guid.NewGuid());
        }
    }
}
