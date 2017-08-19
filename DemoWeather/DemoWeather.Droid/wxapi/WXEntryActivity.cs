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
using Xamarin.Forms;

namespace DemoWeather.Droid.wxapi
{
    [Activity(Label = "WXEntryActivity",Name = "com.weather.report.wxapi.WXEntryActivity", Exported = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop)]
    public class WXEntryActivity : Activity,IWXAPIEventHandler
    {
        public void OnReq(BaseReq p0)
        {
            
        }

        public void OnResp(BaseResp resp)
        {
            if (resp.Type==2)
            {
                switch (resp.errCode)
                {
                    case BaseResp.ErrCode.ErrOk:
                        Device.BeginInvokeOnMainThread(()=>Toast.MakeText(Forms.Context,"分享成功",ToastLength.Long).Show());
                        Finish();
                        break;
                    case BaseResp.ErrCode.ErrSentFailed:
                        Device.BeginInvokeOnMainThread(() => Toast.MakeText(Forms.Context, "分享失败", ToastLength.Long).Show());
                        Finish();
                        break;
                    case BaseResp.ErrCode.ErrAuthDenied:
                        Device.BeginInvokeOnMainThread(() => Toast.MakeText(Forms.Context, "取消分享", ToastLength.Long).Show());
                        Finish();
                        break;
                }
            }
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            Intent = intent;
            MainActivity.wxApi.HandleIntent(Intent, this);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            MainActivity.wxApi.HandleIntent(Intent,this);
            // Create your application here
        }
    }
}