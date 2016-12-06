using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace MusicAPI.Core
{
    public static class MusicApi
    {
        /// <summary>
        /// 搜索API
        /// </summary>
        /// <param name="s">要搜索的内容</param>
        /// <param name="limit">要返回的条数</param>
        /// <param name="offset">设置偏移量 用于分页</param>
        /// <param name="type">类型 [1 单曲] [10 专辑] [100 歌手] [1000 歌单] [1002 用户]</param>
        /// <returns>JSON</returns>
        public static string Search(string s = null, int limit = 30, int offset = 0, int type = 1)
        {
            return Request(new MusicApiConfig.Search { FormData = new { s = s, limit = limit, offset = offset, type = type } });
        }


        /// <summary>
        /// 获取歌曲详情API(包含mp3地址)
        /// </summary>
        /// <param name="ids">要获取的歌曲id列表</param>
        /// <returns>JSON</returns>
        public static string Detail(params string[] ids)
        {
            return Request(new MusicApiConfig.Detail { FormData = new { ids = string.Join(",", ids).AddBrackets() } });
        }

        /// <summary>
        /// 获取歌曲歌词API
        /// 根据JSON判断是否有歌词，nolyric表示无歌词，uncollected表示暂时无人提交歌词
        /// </summary>
        /// <param name="id">要获取的歌曲id</param>
        /// <returns>JSON</returns>
        public static string Lyric(string id)
        {
            return Request(new MusicApiConfig.Lyric { FormData = new { os = "pc", id = id, lv = -1, kv = -1, tv = -1 } });
        }

        /// <summary>
        /// 获取用户歌单信息
        /// 排行榜也归类为歌单
        /// </summary>
        /// <param name="id">要获取的歌单id</param>
        /// <returns>JSON</returns>
        public static string PlayList(string id)
        {
            return Request(new MusicApiConfig.PlayList { FormData = new { id = id } });
        }

        /// <summary>
        /// 歌曲MV API
        /// </summary>
        /// <param name="id">要获取的mvid</param>
        /// <returns>JSON</returns>
        public static string MV(string id)
        {
            return Request(new MusicApiConfig.Mv { FormData = new { id = id, type = "mp4" } });
        }

        /// <summary>
        /// 请求网易云音乐接口
        /// </summary>
        /// <typeparam name="T">要请求的接口类型</typeparam>
        /// <param name="config">要请求的接口类型的对象</param>
        /// <returns>请求结果(JSON)</returns>
        public static string Request<T>(T config) where T : RequestData, new()
        {
            // 请求URL
            string requestURL = config.Url;
            // 将数据包对象转换成QueryString形式的字符串
            string @params = config.FormData.ParseQueryString();
            bool isPost = config.Method.Equals("post", StringComparison.CurrentCultureIgnoreCase);

            if (!isPost)
            {
                // get方式 拼接请求url
                string sep = requestURL.Contains('?') ? "&" : "?";
                requestURL += sep + @params;
            }

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(requestURL);
            req.Method = config.Method;
            req.Referer = "http://music.163.com/";

            if (isPost)
            {
                // 写入post请求包
                byte[] formData = Encoding.UTF8.GetBytes(@params);
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = formData.LongLength;
                req.GetRequestStream().Write(formData, 0, formData.Length);
            }

            // 发送http请求 并读取响应内容返回
            return new StreamReader(req.GetResponse().GetResponseStream()).ReadToEnd();
        }

        /// <summary>
        /// 将对象转换成QueryString形式的字符串
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <returns></returns>
        private static string ParseQueryString(this object obj)
        {
            return string.Join("&", obj.GetType().GetProperties().Select(x => string.Format("{0}={1}", x.Name, x.GetValue(obj))));
        }

        /// <summary>
        /// 为字符串添加指定样式占位符
        /// </summary>
        /// <param name="s">要修改的字符串</param>
        /// <param name="placeholder">占位符规则</param>
        /// <returns></returns>
        private static string AddBrackets(this string s, string placeholder = "[{0}]")
        {
            return string.Format(placeholder, s ?? string.Empty);
        }
    }
}