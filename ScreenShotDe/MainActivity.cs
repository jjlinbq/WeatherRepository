using System;
using System.IO;
using Android.App;
using Android.Graphics;
using Android.Widget;
using Android.OS;
using Android.Views;
using Console = Java.IO.Console;
using File = Java.IO.File;
namespace ScreenShotDe
{
    [Activity(Label = "ScreenShotDe", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button btn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            btn = FindViewById<Button>(Resource.Id.shotBtn);
            btn.Click += Btn_Click;
        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            Screenshot();
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
                    string filepath = SdPath + File.Separator + "12341.png";
                    File file = new File(filepath);
                    if (!file.Exists())
                        file.CreateNewFile();
                    var uri = Android.Net.Uri.FromFile(file);

                    Stream os = Android.App.Application.Context.ContentResolver.OpenOutputStream(uri);

                    bmp.Compress(Bitmap.CompressFormat.Png, 100, os);
                    os.Flush();
                    os.Close();
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                    throw;
                }
            }
        }
    }
}

