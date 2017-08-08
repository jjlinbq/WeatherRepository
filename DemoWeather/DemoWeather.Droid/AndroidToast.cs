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
using Xamarin.Forms;
[assembly:Xamarin.Forms.Dependency(typeof(DemoWeather.Droid.AndroidToast))]
namespace DemoWeather.Droid
{
    class AndroidToast : IGetToast
    {
        public void GetToast(string str)
        {
            Toast.MakeText(Forms.Context, str, ToastLength.Short).Show();
        }
    }
}