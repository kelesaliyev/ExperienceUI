using System;
using Rocket.API;

namespace BerryUI
{
    public class BerryConfig : IRocketPluginConfiguration, IDefaultable
    {
        public void LoadDefaults()
        {
            this.ServerLogo = "URL";
        }

        public string ServerLogo;
    }
}
