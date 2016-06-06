using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace DiscuzBBSAutoLogin
{
    /// <summary>
    /// PostData
    /// </summary>
    public class PostData
    {
        /// <summary>
        /// 页面的LoginPageUri
        /// </summary>
        public Uri LoginPageUri { get; set; }
        /// <summary>
        /// 页面编码
        /// </summary>
        public Encoding PageEncoding { get; set; }
        /// <summary>
        /// FormHash,从页面获取
        /// </summary>
        public string Formhash { get; set; }
        /// <summary>
        /// CookieTime,从页面获取
        /// </summary>
        public string CookieTime { get; set; }
        /// <summary>
        /// LoginField,从页面获取
        /// </summary>
        public string LoginField { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        public PostData(Uri LoginPageUri, Encoding pageEncoding, string userName, string password)
        {
            this.LoginPageUri = LoginPageUri;
            PageEncoding = pageEncoding;
            //fromHash,cookieTime,loginField
            WebRequest webRequest = WebRequest.Create(this.LoginPageUri);
            Stream requestStream = webRequest.GetResponse().GetResponseStream();
            StreamReader streamReader = new StreamReader(requestStream, PageEncoding);
            string pageSource = streamReader.ReadToEnd();
            //正则查找页面参数
            //查找<input type="hidden" name="formhash" value="2f0a3b07" />
            //查找<input type="hidden" name="cookietime" value="2592000" />
            //查找<input type="hidden" value="username" name="loginfield"/>
            //Regex regex = new Regex("<input\\s+type=\"hidden\"\\s+name=\"formhash\"\\s+value=\"(?<formhash>.*?)\"\\s*/>.*?<input\\s+type=\"hidden\"\\s+name=\"cookietime\"\\s+value=\"(?<cookietime>.*?)\"\\s*/>.*?<input\\s+type=\"hidden\"\\s+value=\"(?<loginfield>.*?)\"\\s+name=\"loginfield\"\\s*/>", RegexOptions.Singleline);
            Regex regex = new Regex("<input\\s+type=\"hidden\"\\s+name=\"formhash\"\\s+value=\"(?<formhash>.*?)\"\\s*/>", RegexOptions.Singleline);
            Match match = regex.Match(pageSource);
            if (match.Success)
            {
                GroupCollection group = match.Groups;
                Formhash = group["formhash"].Value;
                CookieTime = "315360000";
                //LoginField = group["loginfield"].Value;
            }
            UserName = userName;
            Password = password;
        }

        /// <summary>
        /// 返回构造格式后的PostData
        /// </summary>
        /// <returns></returns>
        public string GetPostData()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("formhash=");
            stringBuilder.Append(Formhash);
            stringBuilder.Append("&cookietime=");
            stringBuilder.Append(CookieTime);
            stringBuilder.Append("&loginfield=");
            stringBuilder.Append(LoginField);
            stringBuilder.Append("&username=");
            stringBuilder.Append(UserName);
            stringBuilder.Append("&password=");
            stringBuilder.Append(Password);
            stringBuilder.Append("&loginsubmit=true&questionid=0&referer=index.php");
            return stringBuilder.ToString();
        }
    }
}