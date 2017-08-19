using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DemoWeather.iWX;
using DemoWeather.JudgeNet;
using Xamarin.Forms;

namespace DemoWeather
{
    public partial class Page1 : ContentPage
    {
        private DateTime? date;
        private IGetToast toast = DependencyService.Get<IGetToast>();
        private IExit exit = DependencyService.Get<IExit>();
        private IHUD hud = DependencyService.Get<IHUD>();
        private IWxShared wxShared = DependencyService.Get<IWxShared>();
        private IJudgeNetWorks judge = DependencyService.Get<IJudgeNetWorks>();
        private string SuggestStr;
        private string StrUrl = "";
        private string ShareStr;
        public Page1()
        {
            InitializeComponent();
            ListCity.ItemSelected += (o, e) => { ListCity.SelectedItem = null; };
        }
        /// <summary>
        /// 按键查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sure_Btn_OnClicked(object sender, EventArgs e)
        {
           
            List<WeatherInfo> weatherInfos;
           XmlReader xmlReaders;
            if (!judge.IsMobileConnected())
            {
                toast.GetToast("网络未连接，请检查网络！");
                return;
            }
            if (string.IsNullOrWhiteSpace(CityName.Text))
            {
                toast.GetToast("请输入城市地址！");
                return;
            }

           // string SCity = "福州";
            string SCity = CityName.Text;
            weatherInfos = new List<WeatherInfo>() { new WeatherInfo(), new WeatherInfo(), new WeatherInfo() };
            string UrlCity = GetUrlEncoder.UrlEncode(SCity, "GB2312");//
            StrUrl = "http://php.weather.sina.com.cn/xml.php?city=" + UrlCity + "&password=DJOYnieT8234jlsK&day=";
            XmlReaderSettings settings;
            settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            List<string> strs = new List<string>();
            strs.Clear();
            string str3 = "", str4 = "";
            
            for (int i = 0; i < 3; i++)
            {
                string str = StrUrl + i;
                strs.Add(str);
                xmlReaders = XmlReader.Create(strs[i],settings);
                while (xmlReaders.Read())
                {
                    if (xmlReaders.NodeType == XmlNodeType.Element)
                    {
                        
                        if (xmlReaders.Name == "city")
                        {
                            if (i==0)
                            {
                                weatherInfos[i].Days = "今天";
                            }
                            if (i == 1)
                            {
                                weatherInfos[i].Days = "明天";
                            }
                            if (i==2)
                            {
                                weatherInfos[i].Days = "后天";
                            }
                            weatherInfos[i].CityName = xmlReaders.ReadElementContentAsString();
                            
                        }
                        if (xmlReaders.Name == "status1")
                        {
                            str3 = xmlReaders.ReadElementContentAsString();
                        }
                        if (xmlReaders.Name == "status2")
                        {
                            string str1 = xmlReaders.ReadElementContentAsString();
                            if (!string.IsNullOrEmpty(str1)&& !string.IsNullOrWhiteSpace(str3)&&str3!=str1)
                            {
                                weatherInfos[i].Weather = str3 + "转" + str1;
                                weatherInfos[i].WeatherImage = ImageTemplate.DicImage[str3];
                            }
                            else if ((!string.IsNullOrEmpty(str1) && string.IsNullOrWhiteSpace(str3))||str3==str1)
                            {
                                weatherInfos[i].Weather = str1;
                                weatherInfos[i].WeatherImage = ImageTemplate.DicImage[str1];
                            }
                            else if (string.IsNullOrEmpty(str1) && !string.IsNullOrWhiteSpace(str3))
                            {
                                weatherInfos[i].Weather = str3;
                                weatherInfos[i].WeatherImage = ImageTemplate.DicImage[str3];
                            }
                        }
                        if (xmlReaders.Name == "temperature1")
                        {
                            str4 = xmlReaders.ReadElementContentAsString();
                        }
                        if (xmlReaders.Name == "temperature2")
                        {
                            string str2 = xmlReaders.ReadElementContentAsString();
                            if (!string.IsNullOrEmpty(str2)&&!string.IsNullOrWhiteSpace(str4)&&str4!=str2)
                            {
                                weatherInfos[i].TemperatureL = str4 + "-" + str2+"℃";
                            }
                            else if(!string.IsNullOrEmpty(str2) && string.IsNullOrWhiteSpace(str4))
                            {
                                weatherInfos[i].TemperatureL = str2 + "℃";
                            }
                            else if (string.IsNullOrEmpty(str2) && !string.IsNullOrWhiteSpace(str4))
                            {
                                weatherInfos[i].TemperatureL = str4 + "℃";
                            }
                        }
                        if (i==1)
                        {
                            if (xmlReaders.Name == "chy_shuoming")
                            {
                                SuggestStr = xmlReaders.ReadElementContentAsString() + "\n";
                            }
                            if (xmlReaders.Name=="ssd_s")
                            {
                                SuggestStr += xmlReaders.ReadElementContentAsString()+"\n";
                            }
                            if (xmlReaders.Name=="yd_s")
                            {
                                SuggestStr += xmlReaders.ReadElementContentAsString() + "\n";
                            }
                        }
                          
                    }
                }
            }
            lab.IsVisible = true;
            Suggest_Btn.IsVisible = true;
            ListCity.ItemsSource = weatherInfos;
            ShareStr = weatherInfos[0].CityName + " " + weatherInfos[0].Days+" " +"天气："+weatherInfos[0].Weather+"温度：" + weatherInfos[0].TemperatureL;
            hud.Show_success("加载成功！");
        }
        /// <summary>
        /// 双击退出
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            if (!date.HasValue || DateTime.Now - date.Value > new TimeSpan(0, 0, 2))
            {
                toast.GetToast("再按一次退出程序");//选用Android底下的吐司，不会在这里卡住
                date = DateTime.Now;
            }
            else if (DateTime.Now - date.Value <= new TimeSpan(0, 0, 2))
            {
                exit.Exit();
            }
            return true;
        }
        /// <summary>
        /// 出行建议
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Suggest_Btn_OnClicked(object sender, EventArgs e)
        {
            SuggestFrame.IsVisible = true;
            ExitBtn.IsVisible = true;
            SuggestLabel.Text = SuggestStr;
        }

        private void ExitBtn_OnClicked(object sender, EventArgs e)
        {
            SuggestFrame.IsVisible = false;
            ExitBtn.IsVisible = false;
            ShareFrame.IsVisible = false;
        }

        private void Share_Btn_OnClicked(object sender, EventArgs e)
        {
            ExitBtn.IsVisible = true;
           
            ShareFrame.IsVisible = true;
            ShareStack.IsVisible = true;

        }
        private void FrameClose(object sender, EventArgs e)
        {
            ShareFrame.IsVisible = false;
            ExitBtn.IsVisible = false;
        }

        private void ZoneShareBrn_OnClicked(object sender, EventArgs e)//分享至朋友圈
        {
            wxShared.ShareToWX(ShareStr, "Zone");
        }

        private void FriendShareBtn_OnClicked(object sender, EventArgs e)//分享给好友
        {
            wxShared.ShareToWX(ShareStr,"Friends");
        }
    }
}
