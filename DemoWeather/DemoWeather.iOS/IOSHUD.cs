using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BigTed;
[assembly:Xamarin.Forms.Dependency(typeof(DemoWeather.iOS.IOSHUD))]
namespace DemoWeather.iOS
{
    public class IOSHUD:IHUD
    {
        public void Show_Dismiss()
        {
            BTProgressHUD.Dismiss();
        }

        public void Show_Error(string Message)
        {
            BTProgressHUD.ForceiOS6LookAndFeel = true;
            BTProgressHUD.ShowErrorWithStatus(Message, 2000);
        }

        public void Show_Status_Message(string StatusMessage)
        {
            BTProgressHUD.ForceiOS6LookAndFeel = true;
            BTProgressHUD.ShowSuccessWithStatus(StatusMessage);
        }

        public void Show_success(string Message)
        {
            BTProgressHUD.ForceiOS6LookAndFeel = true;
            BTProgressHUD.ShowSuccessWithStatus(Message, 2000);
        }

        public void Show_Toast(string Message)
        {
            BTProgressHUD.ForceiOS6LookAndFeel = true;
            BTProgressHUD.ShowErrorWithStatus(Message, 2000);
        }

    }
}