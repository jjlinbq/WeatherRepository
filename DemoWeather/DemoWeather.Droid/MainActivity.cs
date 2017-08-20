using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Tencent.MM.Sdk.Openapi;
using DemoWeather.ScreenShot;
using Console = System.Console;
using File = Java.IO.File;


namespace DemoWeather.Droid
{
    [Activity(Label = "DemoWeather", Icon = "@drawable/icon", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        public static View dView;
        public static Context AppContext;
        public static IWXAPI wxApi;
        public static readonly string APP_ID = "wx44b2e6e0fb26fee3";
        
        protected override void OnCreate(Bundle bundle)
        {
            AppContext = ApplicationContext;
            base.OnCreate(bundle);
            
            global::Xamarin.Forms.Forms.Init(this, bundle);
            wxApi = WXAPIFactory.CreateWXAPI(this, APP_ID,true);
            wxApi.RegisterApp(APP_ID);

            LoadApplication(new App());
            dView = Window.DecorView.RootView;
        }
        public void Screenshot()
        {
            View v1 = Window.DecorView.RootView;
            v1.DrawingCacheEnabled = true;
            Bitmap bmp = Bitmap.CreateBitmap(v1.DrawingCache);
           
            if (bmp != null)
            {
                try
                {
                    string SdPath = Android.OS.Environment.ExternalStorageDirectory.ToString();
                    string filepath = SdPath + File.Separator + "screenshot.png";
                    File file = new File(filepath);
                    var uri = Android.Net.Uri.FromFile(file);

                    Stream os = Android.App.Application.Context.ContentResolver.OpenOutputStream(uri);

                    bmp.Compress(Bitmap.CompressFormat.Png, 100, os);
                    os.Flush();
                    os.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}

