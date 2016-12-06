using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicAPI.Core
{
    /// <summary>
    /// 抽象请求参数模版
    /// </summary>
    public abstract class RequestData
    {
        /// <summary>
        /// 请求的URL
        /// </summary>
        public abstract string Url { get; }

        /// <summary>
        /// 请求方法
        /// </summary>
        public virtual string Method
        {
            get
            {
                return "GET";
            }

            set
            {
                 Method = value;
            }
        }



        /// <summary>
        /// 匿名参数
        /// </summary>
        public object FormData { get; set; }
    }
}