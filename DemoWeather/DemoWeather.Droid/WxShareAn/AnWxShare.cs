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
        void IWxShared.ShareToWX(string weatherInfo,string target)
        {
           
            if (!MainActivity.wxApi.IsWXAppInstalled)
            {
                Toast.MakeText(Forms.Context,"请先安装微信应用！",ToastLength.Short).Show();
                return;
            }
            if (!MainActivity.wxApi.IsWXAppSupportAPI)
            {
                Toast.MakeText(Forms.Context, "请先更新微信应用！", ToastLength.Short).Show();
                return;
            }
            WXImageObject imageObject = new WXImageObject();
            imageObject.ImagePath = "/storage/emulated/0/screenshot.png";
            WXMediaMessage message = new WXMediaMessage();
            message.mediaObject = imageObject;
            message.Title = "天气预报";
            SendMessageToWX.Req req = new SendMessageToWX.Req();
            req.Transaction = buildTransaction("WeatherMessage");
            req.Message = message;
            if (target =="Friends")
            {
                req.Scene = SendMessageToWX.Req.WXSceneSession;
            }
           if (target =="Zone")
           {
               req.Scene = SendMessageToWX.Req.WXSceneTimeline;
           }
            MainActivity.wxApi.SendReq(req);
        }

        private static string buildTransaction(string str)
        {
            return (str == null) ? DateTime.Now.ToLongTimeString()
                : str + DateTime.Now.ToLongTimeString();
        }
    }
}