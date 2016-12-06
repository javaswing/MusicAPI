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
        /// 接口地址
        /// </summary>
        public virtual string Url { get; set; }

        /// <summary>
        /// 请示方式
        /// </summary>
        public virtual string Method { get; set; }


        /// <summary>
        /// 请求参数[匿名对象]
        /// </summary>
        public virtual object FormData { get; set; }


    }
}