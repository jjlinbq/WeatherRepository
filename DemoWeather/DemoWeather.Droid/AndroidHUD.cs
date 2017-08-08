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
using AndroidHUD;
using Xamarin.Forms;
[assembly:Xamarin.Forms.Dependency(typeof(DemoWeather.Droid.AndroidHUD))]
namespace DemoWeather.Droid
{
    public class AndroidHUD:IHUD
    {
        /// <summary>
        /// �ر�
        /// </summary>
        public void Show_Dismiss()
        {
            AndHUD.Shared.Dismiss();
        }
        /// <summary>
        /// ��ʾһ������ͼ����һ��ģ���ı�������Ϣ�����Զ��ų���2��
        /// </summary>
        /// <param name="Message"></param>
        public void Show_Error(string Message)
        {
            AndHUD.Shared.ShowError(Forms.Context, Message, MaskType.Clear, TimeSpan.FromSeconds(2));
        }
        /// <summary>
        /// ��ʾ��ת + �ı�
        /// </summary>
        /// <param name="StatusMessage"></param>

        public void Show_Status_Message(string StatusMessage)
        {
            AndHUD.Shared.Show(Forms.Context, StatusMessage, -1, MaskType.Clear);
        }
        /// <summary>
        /// һ���ɹ���ͼ����ʾһ����Ϣ����һ����ȷ�ı��������Զ��ų���2��
        /// </summary>
        /// <param name="Message"></param>

        public void Show_success(string Message)
        {
            AndHUD.Shared.ShowSuccess(Forms.Context, Message, MaskType.Clear, TimeSpan.FromSeconds(2));
        }
        /// <summary>
        /// ��ʾһ����׿������˾
        /// </summary>
        /// <param name="Message"></param>

        public void Show_Toast(string Message)
        {
            AndHUD.Shared.ShowToast(Forms.Context, Message, MaskType.Clear, TimeSpan.FromSeconds(2));
        }

    }
}