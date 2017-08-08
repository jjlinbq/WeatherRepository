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

namespace DemoWeather.Droid
{
    [Activity(Label = "Weather", Icon = "@drawable/WeatherIcon", Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
           
            base.OnCreate(savedInstanceState);
            DelayedNavigation();
        }

        private void DelayedNavigation()
        {
            System.Threading.Tasks.Task.Delay(2000);
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }

    }
}