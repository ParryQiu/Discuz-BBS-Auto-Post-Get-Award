using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace DiscuzBBSAutoLogin
{
    public partial class Main : Form
    {
        private readonly MyDataTable myDataTable = new MyDataTable();
        private CookieContainer cc;
        private Uri loginuri;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            TimerStartPost.Stop();
            TimerStartCatch.Stop();
            TimerOnlyCount.Stop();
            LoadInitFormData();
            LabelStatus.Text = string.Empty;
            LabelCurrentFloor.Text = string.Empty;
            //登录并存储cookie
            loginuri = new Uri("http://bbs.meizu.com/logging.php?action=login");
            var discuzTool = new DiscuzTool();
            cc = discuzTool.GetCookieContainer(loginuri);
        }

        private void LoadInitFormData()
        {
            ListBoxTopicIDs.Items.Clear();
            ListBoxInfo.Items.Clear();
            for (int i = 0; i < myDataTable.StoreDataTable.Rows.Count; i++)
            {
                ListBoxTopicIDs.Items.Add(myDataTable.StoreDataTable.Rows[i]["TopicID"]);
            }
            if (ListBoxTopicIDs.Items.Count <= 0) return;
            ListBoxTopicIDs.SetSelected(0, true);
            GetDetailsByTopicID();
        }

        private void ButtonAddTopicID_Click(object sender, EventArgs e)
        {
            int newNo;
            if (int.TryParse(TextBoxNewTopicNo.Text, out newNo))
            {
                myDataTable.Add(newNo, -1, "关注中...");
                LoadInitFormData();
                TextBoxNewTopicNo.Text = string.Empty;
            }
            else
            {
                MessageBox.Show(@"输入的帖子ID不正确", @"Error");
            }
        }

        private void ListBoxTopicIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDetailsByTopicID();
        }

        private void GetDetailsByTopicID(int TopicID)
        {
            DataRow dataRow = myDataTable.StoreDataTable.Select("TopicID=" + TopicID)[0];
            TextBoxFitNumbers.Text = (string)dataRow["HitFloorIDs"];
            LabelStatus.Text = (string)dataRow["Status"];
        }

        private void GetDetailsByTopicID()
        {
            DataRow dataRow = myDataTable.StoreDataTable.Select("TopicID=" + ListBoxTopicIDs.SelectedItem)[0];
            TextBoxFitNumbers.Text = dataRow["HitFloorIDs"].ToString();
            LabelStatus.Text = dataRow["Status"].ToString();
            TextBoxPrizeDetails.Text = dataRow["Content"].ToString();
            LabelCurrentFloor.Text = dataRow["CurrentFloor"].ToString();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            DataRow dataRow = myDataTable.StoreDataTable.Rows.Find(ListBoxTopicIDs.SelectedItem);
            dataRow["HitFloorIDs"] = TextBoxFitNumbers.Text;
            dataRow["Content"] = TextBoxPrizeDetails.Text;
            myDataTable.Save();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            TimerStartPost.Start();
            TimerStartCatch.Start();
        }

        private void ButtonEnd_Click(object sender, EventArgs e)
        {
            TimerStartPost.Stop();
            TimerStartCatch.Stop();
        }

        private void TimerStartPost_Tick(object sender, EventArgs e)
        {
            //公共方法
            DataTable dataTable = myDataTable.StoreDataTable;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                //取得ID
                int topicID = int.Parse(dataRow["TopicID"].ToString());
                ////查找最大楼层数
                LogInfo("正在处理文章ID：" + topicID);

                string postUrl = string.Format(
                    "http://bbs.meizu.com/post.php?action=reply&fid=22&tid={0}&extra=page=1", topicID);
                string pageSource = GetPageSource(cc, postUrl);

                ////查找最大楼层数 已修改存至datatable中
                //var regexMaxFloor =
                //    new Regex("&rsaquo;&rsaquo;</a></div> -->\\s*<div class=\"pages\"><em>&nbsp;(?<maxfloor>\\d+)&nbsp;");
                //string pageIndexSource = GetPageSource(cc,
                //                                       string.Format("http://bbs.meizu.com/thread-{0}-1-1.html", topicID));
                //Match matchMaxPage = regexMaxFloor.Match(pageIndexSource);
                //int currentFloor = 0;
                //if (matchMaxPage.Success)
                //{
                //    currentFloor = int.Parse(matchMaxPage.Groups["maxfloor"].Value);
                //}

                //直接从datatable中获取
                int currentFloor = int.Parse(dataRow["CurrentFloor"].ToString());
                LogInfo("文章当前到了：" + currentFloor + "楼");
                //获取中奖楼层的数组
                foreach (string floor in dataRow["HitFloorIDs"].ToString().Split(','))
                {
                    //在之前3个贴子时开始猛发
                    if (currentFloor < int.Parse(floor) + 1 && currentFloor > int.Parse(floor) - 3)
                    {
                        for (int i = 0; i < int.Parse(floor) - currentFloor; i++)
                        {
                            try
                            {
                                //获取FormHash
                                //fromHash,cookieTime,loginField
                                //正则查找页面参数
                                //查找<input type="hidden" name="formhash" value="2f0a3b07" />
                                //Regex regex = new Regex("<input\\s+type=\"hidden\"\\s+name=\"formhash\"\\s+value=\"(?<formhash>.*?)\"\\s*/>.*?<input\\s+type=\"hidden\"\\s+name=\"cookietime\"\\s+value=\"(?<cookietime>.*?)\"\\s*/>.*?<input\\s+type=\"hidden\"\\s+value=\"(?<loginfield>.*?)\"\\s+name=\"loginfield\"\\s*/>", RegexOptions.Singleline);
                                var regex =
                                    new Regex(
                                        "<input\\s+type=\"hidden\"\\s+name=\"formhash\"\\s+id=\"formhash\"\\s+value=\"(?<formhash>.*?)\"\\s*/>",
                                        RegexOptions.Singleline);
                                Match match = regex.Match(pageSource);
                                string formhash = string.Empty;
                                if (match.Success)
                                {
                                    GroupCollection group = match.Groups;
                                    formhash = group["formhash"].Value;
                                }
                                LogInfo("查找到了formhash为：" + formhash);
                                var uri2 =
                                    new Uri(
                                        string.Format(
                                            "http://bbs.meizu.com/post.php?action=reply&fid=22&tid={0}&extra=page=1&replysubmit=yes",
                                            topicID));
                                byte[] byteRequest =
                                    Encoding.Default.GetBytes("subject=&formhash=" + formhash + "&message=" +
                                                              GetRandomMessage()); //编码     
                                var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri2);
                                httpWebRequest.ContentType = "application/x-www-form-urlencoded"; //这一个参数似乎是必需的。
                                httpWebRequest.Method = "Post"; //这个是请求方法，必须是POST，这个可以通过分析实际登录的情况得到采用的方法
                                httpWebRequest.ContentLength = byteRequest.Length; //POST数据的长度，这个参数是必需的。
                                httpWebRequest.CookieContainer = cc;
                                //下面是发送数据到服务器
                                Stream stream = httpWebRequest.GetRequestStream();
                                stream.Write(byteRequest, 0, byteRequest.Length);
                                stream.Close();
                                var webResponse = (HttpWebResponse)httpWebRequest.GetResponse(); //取服务器的响应
                                //Stream sr = webResponse.GetResponseStream();
                                LogInfo("向文章成功发送了一个回复,我觉得应该在：" + (currentFloor + i + 1) + "楼");
                                if ((currentFloor + i + 1) == int.Parse(floor))
                                {
                                    LogInfo("中奖了...........................................");
                                }
                                //Thread.Sleep(20000);
                            }
                            catch
                            {
                                throw;
                            }

                        }
                    }
                }
            }
        }

        private void LogInfo(string info)
        {
            ListBoxInfo.Items.Add(info);
        }

        private static string GetPageSource(CookieContainer cc, string stringUri)
        {
            var uri = new Uri(stringUri);
            var ht = (HttpWebRequest)WebRequest.Create(uri);
            ht.CookieContainer = cc; // 给HttpWebRequest指定CookieContainer
            Stream strm = ht.GetResponse().GetResponseStream();
            var reader = new StreamReader(strm, Encoding.Default);
            return reader.ReadToEnd();
        }

        private static string GetRandomMessage()
        {
            var messages = new[]
                               {
                                   "我想要啊！恭喜发财！！", "恭喜发财恭喜发财", "中奖吧中奖吧...", "抢了，老板发大财", "gongxifacai", "老板祝你发大财",
                                   "喜欢M8M8M8M8", "M8M8M8M8M8M8M8M8M8M8M8", "哎中奖吧吧吧吧吧", "老板送我一个吧很想要啊", "老板你最好 给我一个吧",
                                   "我的我的我的我的我的我的奖品"
                               };
            int iRnd = DateTime.Now.Millisecond;
            var randomCoor = new Random(iRnd);
            int idran = randomCoor.Next(0, 11);
            return messages[idran];
        }

        private void ButtonShowNow_Click(object sender, EventArgs e)
        {
            //查找最大楼层数
            //Regex regexMaxPage = new Regex("class=\"last\">.*?(?<maxpage>\\d+)</a>");
            var regexMaxFloor =
                new Regex("&rsaquo;&rsaquo;</a></div> -->\\s*<div class=\"pages\"><em>&nbsp;(?<maxfloor>\\d+)&nbsp;");
            string pageIndexSource = GetPageSource(cc,
                                                   string.Format("http://bbs.meizu.com/thread-{0}-1-1.html",
                                                                 ListBoxTopicIDs.SelectedItem));
            Match matchMaxPage = regexMaxFloor.Match(pageIndexSource);
            int currentFloor = 0;
            if (matchMaxPage.Success)
            {
                currentFloor = int.Parse(matchMaxPage.Groups["maxfloor"].Value);
            }
            LabelCurrentFloor.Text = currentFloor.ToString();
            //保存至datatable
            DataRow dataRow = myDataTable.StoreDataTable.Rows.Find(ListBoxTopicIDs.SelectedItem);
            dataRow["CurrentFloor"] = currentFloor.ToString();
            myDataTable.Save();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            DataRow dataRow = myDataTable.StoreDataTable.Rows.Find(ListBoxTopicIDs.SelectedItem);
            dataRow.Delete();
            myDataTable.Save();
            Main_Load(this, null);
        }

        private void ButtonViewInBrowse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"iexplore.exe", string.Format("http://bbs.meizu.com/thread-{0}-1-1.html", ListBoxTopicIDs.SelectedItem));
        }

        private void ButtonSetStatus_Click(object sender, EventArgs e)
        {
            DataRow dataRow = myDataTable.StoreDataTable.Rows.Find(ListBoxTopicIDs.SelectedItem);
            dataRow["Status"] = "已中奖";
            LabelStatus.Text = @"已中奖";
            myDataTable.Save();
        }

        private void TimerStartCatch_Tick(object sender, EventArgs e)
        {
            try
            {
                foreach (object t in ListBoxTopicIDs.Items)
                {
                    //查找最大楼层数
                    //Regex regexMaxPage = new Regex("class=\"last\">.*?(?<maxpage>\\d+)</a>");
                    LogInfo("当前抓取到了文章ID：" + t);
                    var regexMaxFloor =
                        new Regex("&rsaquo;&rsaquo;</a></div> -->\\s*<div class=\"pages\"><em>&nbsp;(?<maxfloor>\\d+)&nbsp;");
                    string pageIndexSource = GetPageSource(cc,
                                                           string.Format("http://bbs.meizu.com/thread-{0}-1-1.html",
                                                                         t));
                    Match matchMaxPage = regexMaxFloor.Match(pageIndexSource);
                    int currentFloor = 0;
                    if (matchMaxPage.Success)
                    {
                        currentFloor = int.Parse(matchMaxPage.Groups["maxfloor"].Value);
                    }
                    //保存至datatable
                    DataRow dataRow = myDataTable.StoreDataTable.Rows.Find(t);
                    dataRow["CurrentFloor"] = currentFloor.ToString();
                    LogInfo("当前抓取到了文章已经到了" + currentFloor + "层");
                }
                myDataTable.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ButtonCatchNow_Click(object sender, EventArgs e)
        {

        }

        private void TimerOnlyCount_Tick(object sender, EventArgs e)
        {
            //查找最大楼层数
            //Regex regexMaxPage = new Regex("class=\"last\">.*?(?<maxpage>\\d+)</a>");
            LogInfo("当前抓取到了文章ID：" + ListBoxTopicIDs.SelectedItem);
            var regexMaxFloor =
                new Regex("&rsaquo;&rsaquo;</a></div> -->\\s*<div class=\"pages\"><em>&nbsp;(?<maxfloor>\\d+)&nbsp;");
            string pageIndexSource = GetPageSource(cc,
                                                   string.Format("http://bbs.meizu.com/thread-{0}-1-1.html",
                                                                 ListBoxTopicIDs.SelectedItem));
            Match matchMaxPage = regexMaxFloor.Match(pageIndexSource);
            int currentFloor = 0;
            if (matchMaxPage.Success)
            {
                currentFloor = int.Parse(matchMaxPage.Groups["maxfloor"].Value);
            }
            //保存至datatable
            DataRow dataRow = myDataTable.StoreDataTable.Rows.Find(ListBoxTopicIDs.SelectedItem);
            dataRow["CurrentFloor"] = currentFloor.ToString();
            LogInfo("当前抓取到了文章已经到了" + currentFloor + "层");
            myDataTable.Save();
            LabelCurrentFloor.Text = dataRow["CurrentFloor"].ToString();
        }

        private void ButtonAutoGetFloor_Click(object sender, EventArgs e)
        {
            TimerOnlyCount.Start();
        }

        private void ButtonStopAutoGetFloor_Click(object sender, EventArgs e)
        {
            TimerOnlyCount.Stop();
        }
    }
}