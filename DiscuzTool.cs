using System.IO;
using System.Net;

namespace DiscuzBBSAutoLogin
{
    using System;
    using System.Text;

    /// <summary>
    /// 在此描述DiscuzTool的说明
    /// </summary>
    public class DiscuzTool
    {
        public CookieContainer GetCookieContainer(Uri uri)//针对discuz 论坛
        {
            PostData postDataClass = new PostData(uri, Encoding.GetEncoding("GB2312"), "你的用户名", "你的密码");
            string postData = postDataClass.GetPostData();
            byte[] byteRequest = Encoding.Default.GetBytes(postData);//编码            
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";//这一个参数似乎是必需的。
            httpWebRequest.Method = "Post";//这个是请求方法，必须是POST，这个可以通过分析实际登录的情况得到采用的方法
            httpWebRequest.ContentLength = byteRequest.Length;//POST数据的长度，这个参数是必需的。
            //下面是发送数据到服务器
            Stream stream = httpWebRequest.GetRequestStream();
            stream.Write(byteRequest, 0, byteRequest.Length);
            stream.Close();
            HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse();//取服务器的响应
            CookieContainer co = new CookieContainer();
            co.SetCookies(new Uri("http://" + uri.Host), webResponse.Headers.Get("Set-Cookie"));
            return co;
        }

    }
}
