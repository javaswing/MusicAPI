using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicAPI.Core;
using WebApi.OutputCache.V2;

namespace MusicAPI.Controllers
{

    [RoutePrefix("api/music")]
    [EnableCors("*", "*", "*")]
    public class MusicController : JsonObjectController
    {
        // GET: /api/music/search?s={0}&limit={1}&offset={2}&type={3}
        // Sample: http://y.dskui.com/api/music/search?s=%E6%89%A7%E8%BF%B7&limit=1

        [Route("search")]
        [HttpGet()]
        [CacheOutput(ClientTimeSpan = int.MaxValue, ServerTimeSpan = int.MaxValue)]
        public HttpResponseMessage Search(string s = null, int limit = 30, int offset = 0, int type = 1)
        {
            return Json(MusicApi.Search(s, limit, offset, type));
        }

        // GET: /api/music/detail?ids={0}
        // Sample: http://y.dskui.com/api/music/detail?ids=29775505,300587

        [Route("detail")]
        [HttpGet()]
        [CacheOutput(ClientTimeSpan = int.MaxValue, ServerTimeSpan = int.MaxValue)]
        public HttpResponseMessage Detail(string ids = null)
        {
            return Json(MusicApi.Detail(ids));
        }

        // GET: /api/music/lyric?id={0}
        // Sample: http://y.dskui.com/api/music/lyric?id=29775505

        [Route("lyric")]
        [HttpGet()]
        [CacheOutput(ClientTimeSpan = int.MaxValue, ServerTimeSpan = int.MaxValue)]
        public HttpResponseMessage Lyric(string id)
        {
            return Json(MusicApi.Lyric(id));
        }

        // GET: /api/music/playlist?id={0}
        // Sample: http://y.dskui.com/api/music/playlist?id=374755836

        [Route("playlist")]
        [HttpGet()]
        [CacheOutput(ClientTimeSpan = int.MaxValue, ServerTimeSpan = int.MaxValue)]
        public HttpResponseMessage PlayList(string id = null)
        {
            return Json(MusicApi.PlayList(id));
        }

        // GET: /api/music/mv?id={0}
        // Sample: http://y.dskui.com/api/music/mv?id=333042

        [Route("mv")]
        [HttpGet()]
        [CacheOutput(ClientTimeSpan = int.MaxValue, ServerTimeSpan = int.MaxValue)]
        public HttpResponseMessage MV(string id = null)
        {
            return Json(MusicApi.MV(id));
        }
    }


}
