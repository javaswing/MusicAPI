using System.Web.Http.Filters;

namespace MusicAPI
{/// <summary>
    /// 允许WebApi跨域访问
    /// </summary>
    public class EnableCorsAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="origins">允许跨域访问的域名(协议/端口不一致都算不同域名,默认*)</param>
        /// <param name="headers">允许跨域的请求标头(默认*)</param>
        /// <param name="methods">允许跨域的请求方法(默认*)</param>
        public EnableCorsAttribute(string origins, string headers, string methods)
        {
            this.Origins = origins;
            this.Headers = headers;
            this.Methods = methods;
        }

        public string Origins { get; set; }
        public string Methods { get; set; }
        public string Headers { get; set; }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
            {
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", this.Origins);
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Method", this.Methods);
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Headers", this.Headers);
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}