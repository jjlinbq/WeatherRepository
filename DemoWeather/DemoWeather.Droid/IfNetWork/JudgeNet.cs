using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DemoWeather.JudgeNet;
using Xamarin.Forms;

[assembly:Dependency(typeof(DemoWeather.Droid.IfNetWork.JudgeNet))]
namespace DemoWeather.Droid.IfNetWork
{
    public class JudgeNet:IJudgeNetWorks
    {
       
        public bool IsNetWorkConnected()
        {
            ConnectivityManager manager = ConnectivityManager.FromContext(MainActivity.AppContext);
            NetworkInfo info = manager.ActiveNetworkInfo;
            if (info!=null)
            {
                return info.IsAvailable;
            }
            return false;
        }

        public bool IsWifiConnected()
        {
            ConnectivityManager manager = ConnectivityManager.FromContext(MainActivity.AppContext);
            NetworkInfo info = manager.GetNetworkInfo(ConnectivityType.Wifi);
            if (info!=null)
            {
                return info.IsAvailable;
            }
            return false;
        }

        public bool IsMobileConnected()
        {
            ConnectivityManager manager = ConnectivityManager.FromContext(MainActivity.AppContext);
            NetworkInfo info = manager.GetNetworkInfo(ConnectivityType.Mobile);
            if (info!=null)
            {
                return info.IsAvailable;
            }
            return false;
        }
    }
}