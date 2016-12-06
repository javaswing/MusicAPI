using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace MusicAPI.Controllers
{
    public class JsonObjectController : ApiController
    {
        /// <summary>
        /// 序列化对象或字符串为JSON对象而不是JSON字符串(不使用WebApi的JSON序列化)
        /// </summary>
        /// <param name="o">要序列号的对象</param>
        /// <returns></returns>
        public HttpResponseMessage Json(object o)
        {
            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
            message.Content = new StringContent(o is string ? o.ToString() : new JavaScriptSerializer().Serialize(o), Encoding.UTF8, "application/json");
            return message;
        }
    }
}