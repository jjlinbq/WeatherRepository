using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Tencent.MM.Sdk.Openapi;

namespace DemoWeather.Droid
{
    [Activity(Label = "DemoWeather", Icon = "@drawable/icon", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        public static Context AppContext;
        public static IWXAPI wxApi;
        public static readonly string APP_ID = "wxd930ea5d5a258f4f";
        protected override void OnCreate(Bundle bundle)
        {
            AppContext = ApplicationContext;
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            wxApi = WXAPIFactory.CreateWXAPI(this, APP_ID,true);
            wxApi.RegisterApp(APP_ID);
            LoadApplication(new App());
        }
    }
}

