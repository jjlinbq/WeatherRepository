using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Tencent.MM.Sdk.Openapi;
using DemoWeather.iWX;
using Xamarin.Forms;

[assembly:Xamarin.Forms.Dependency(typeof(DemoWeather.Droid.WxShareAn.AnWxShare))]
namespace DemoWeather.Droid.WxShareAn
{
    public class AnWxShare : IWxShared
    {
        public static MainActivity Mains = null;
        public static string App_Id = MainActivity.APP_ID;
        public static IWXAPI Wxapi;
        void IWxShared.ShareToWX(string weatherInfo,string target)
        {
            Wxapi = MainActivity.wxApi;
            if (Wxapi==null)
            {
                Wxapi = WXAPIFactory.CreateWXAPI(Forms.Context, App_Id, true);
            }
            if (!Wxapi.IsWXAppInstalled)
            {
                Toast.MakeText(Forms.Context,"请先安装微信应用！",ToastLength.Short).Show();
                return;
            }
            if (!Wxapi.IsWXAppSupportAPI)
            {
                Toast.MakeText(Forms.Context, "请先更新微信应用！", ToastLength.Short).Show();
                return;
            }
            Wxapi.RegisterApp(App_Id);
            WXTextObject text = new WXTextObject();
            text.Text = weatherInfo;
            WXMediaMessage message = new WXMediaMessage(text);
            SendMessageToWX.Req req = new SendMessageToWX.Req();
            req.Transaction = buildTransaction("WeatherMessage");
            req.Message = message;
            if (target =="Friends")
            {
                req.Scene = SendMessageToWX.Req.WXSceneTimeline;
            }
           if (target =="Zone")
           {
               req.Scene = SendMessageToWX.Req.WXSceneSession;
           }
            Wxapi.SendReq(req);
        }

        private static string buildTransaction(string str)
        {
            return (str == null) ? DateTime.Now.ToLongTimeString()
                : str + DateTime.Now.ToLongTimeString();
        }
    }
}