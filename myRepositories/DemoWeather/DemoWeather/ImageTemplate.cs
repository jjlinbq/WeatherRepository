using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoWeather
{
    class ImageTemplate
    {
        public static Dictionary<string,string> DicImage = new Dictionary<string, string>() ;

        static ImageTemplate()
        {
            DicImage.Add("暴雪", "weather_baoxueb.png" );
            DicImage.Add("暴雨", "weather_baoyub.png");
            DicImage.Add("大暴雨", "weather_dabaoyub.png");
            DicImage.Add("大雪", "weather_daxueb.png");
            DicImage.Add("大雨", "weather_dayub.png");
            DicImage.Add("多云", "weather_duoyunb.png");
            DicImage.Add("拂尘", "weather_fuchenb.png");
            DicImage.Add("雷阵雨","weather_leizhenyub.png");
            DicImage.Add("雷阵雨伴有冰雹", "weather_leizhenyubanyoubingbaob.png");
            DicImage.Add("雾霾", "weather_maib.png");
            DicImage.Add("晴", "weather_qingb.png");
            DicImage.Add("沙尘暴","weather_shachenbaob.png");
            DicImage.Add("特大暴雨", "weather_tedabaoyub.png");
            DicImage.Add("雾", "weather_wub.png");
            DicImage.Add("小雨", "weather_xiaoyub.png");
            DicImage.Add("小雪", "weather_xiaoxueb.png");
            DicImage.Add("扬沙", "weather_yangshab.png");
            DicImage.Add("阴", "weather_yinb.png");
            DicImage.Add("雨夹雪", "weather_yujiaxueb.png");
            DicImage.Add("阵雪", "weather_zhenxueb.png");
            DicImage.Add("阵雨", "weather_zhenyub.png");
            DicImage.Add("中雪","weather_zhongxueb.png");
            DicImage.Add("中雨", "weather_zhongyub.png");
            DicImage.Add("冻雨", "weather_dongyub.png");
            DicImage.Add("中到大雨","zhongdaodayu.png");
        }
        
    }
}
