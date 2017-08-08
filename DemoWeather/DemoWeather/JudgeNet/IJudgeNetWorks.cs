using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoWeather.JudgeNet
{
    public interface IJudgeNetWorks
    {
        bool IsNetWorkConnected();
        bool IsWifiConnected();
        bool IsMobileConnected();
    }
}
