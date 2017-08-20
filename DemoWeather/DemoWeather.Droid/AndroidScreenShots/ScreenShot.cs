using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Hardware.Display;
using Android.Media;
using Android.Media.Projection;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DemoWeather.ScreenShot;
using Java.IO;
using Java.Lang.Ref;
using Xamarin.Forms;
using Console = System.Console;
using File = Java.IO.File;
using Stream = System.IO.Stream;
[assembly:Xamarin.Forms.Dependency(typeof(DemoWeather.Droid.AndroidScreenShots.ScreenShot))]
namespace DemoWeather.Droid.AndroidScreenShots
{
    public class ScreenShot :Activity, IScreenShots
    {
        
        public void Screenshot()
        {
            MainActivity.dView.DrawingCacheEnabled = true;
            Bitmap bmp = Bitmap.CreateBitmap(MainActivity.dView.DrawingCache);

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
                    Device.BeginInvokeOnMainThread(()=>Toast.MakeText(Forms.Context,"截图成功!",ToastLength.Short).Show());
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