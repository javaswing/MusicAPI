# musicAPI

> 这是一个用.net做的获取网易云音乐后台API的项目，采用VS2013开发


目前提供的API有：

1. 搜索功能
    - 请求地址： /api/music/search?s={0}&limit={1}&offset={2}&type={3}
    - 请求参数：
        * `s`: 搜索词
        * `limit`: 分页所用， 返回的条数(默认30)
        * `offset`: 偏移量,用于分页(默认0)
        * `type`: 搜索的种类，(默认1) [1 单曲] [10 专辑] [100 歌手] [1000 歌单] [1002 用户]

2.  歌单（网友精选碟） hot
    - 请求地址：api/music/topPlaylist?cat=全部&order=hot&offset=0&total=true&limit=3
    - 请求参数：
        * `cat`: 种类(默认hot)，其它参数，参考：http://music.163.com/#/discover/playlist中的分类名称
        * `order`: 排序规则（默认为hot）
        * `offset`: 偏移量,用于分页(默认0)
        * `total`: 该分类下总数目
        * `limit`: 分页所用， 返回的条数(默认50)
3. 歌曲详情
    - 请求地址： api/music/detail?ids=29775505,300587
    - 请求参数：
        * `ids`: 歌曲对应的ID也可以是多个
4. 获取歌词
    - 请求地址：api/music/lyric?id=29775505
    - 请求参数：
        * `id`: 获取歌词对应的歌曲ID
5. 获取歌单详情
    - 请求地址：api/music/playlist?id=374755836
    - 请求参数：
        * `id`: 歌单对应的ID
6. 获取MV详情
    - 请求地址： api/music/mv?id=333042
    - 请求参数：
        * `id`: 对应的MVID

## 鸣谢

[https://github.com/u3u/NeteaseCloudMusicApi](https://github.com/u3u/NeteaseCloudMusicApi)

[https://github.com/darknessomi/musicbox](https://github.com/darknessomi/musicbox)