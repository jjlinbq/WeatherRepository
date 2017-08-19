using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWeather.iWX
{
    public interface IWxShared
    {
        /// <summary>
        /// 分享给朋友
        /// </summary>
        /// <param name="weatherInfo">天气json信息</param>
        /// /// <param name="target">分享目标：朋友圈或者朋友</param>
        void ShareToWX(string weatherInfo,string target);
        
    }
}
