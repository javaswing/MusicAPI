using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicAPI.Core
{
    /// <summary>
    /// 请求网易云音乐的接口配置
    /// </summary>
    public static class MusicApiConfig
    {

        /// <summary>
        /// 歌单（网友精选）
        /// hot||new http://music.163.com/#/discover/playlist/
        /// </summary>
        public class TopPlayerLists: RequestData
        {
            public override string Url
            {
                get 
                {
                    return "http://music.163.com/api/playlist/list";
                }
            }

            public override string Method
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
        }

        /// <summary>
        /// 搜索接口
        /// </summary>
        public class Search : RequestData
        {

             public override string Url 
             { 
                 get
                 {
                     return "http://music.163.com/api/search/get";
                 }
             }

            public override string Method 
            {
                get
                {
                    return "POST";
                }

               set
               {
                  Method = value;
                } 
            }
             
        }

        /// <summary>
        /// 歌曲详情接口
        /// </summary>
        public class Detail : RequestData
        {

            public override string Url
            {
                get
                {
                    return "http://music.163.com/api/song/detail";
                }
            }

        }

        /// <summary>
        /// 获取歌词接口
        /// </summary>
        public class Lyric : RequestData
        {
            public override string Url
            {
                get
                {
                    return "http://music.163.com/api/song/lyric";
                }
            }
        }

        /// <summary>
        /// 专辑歌单
        /// </summary>
        public class PlayList : RequestData
        {
            public override string Url
            {
                get
                {
                    return "http://music.163.com/api/playlist/detail";
                }
            }
        }

        /// <summary>
        /// MV接口
        /// </summary>
        public class Mv: RequestData
        {
            public override string Url
            {
                get
                {
                    return "http://music.163.com/api/mv/detail";
                }
            }
        }
    }
}