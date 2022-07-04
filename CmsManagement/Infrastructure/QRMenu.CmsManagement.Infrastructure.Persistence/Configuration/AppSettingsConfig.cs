using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace QRMenu.CmsManagement.Infrastructure.Persistence.Configuration
{
    public static class AppSettingsConfig
    {
        private readonly static ConfigurationManager _configurationManager;

        static AppSettingsConfig()
        {
            AppSettingsConfig._configurationManager = new ConfigurationManager();  
        }
        public static string ConnectionMsSql {
            get
            {
                AppSettingsConfig._configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../../Presentation/QRMenu.CmsManagement.Presentation.CmsUI"));
                AppSettingsConfig._configurationManager.AddJsonFile("appsettings.json");
                return _configurationManager.GetConnectionString("MsSql");
            }
        }


    }
}
