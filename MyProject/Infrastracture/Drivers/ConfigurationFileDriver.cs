using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace TestCtCoProject.Infrastracture.Drivers
{
    public class ConfigurationFileDriver
    {
        private readonly Lazy<IConfiguration> _configurationLazy;

        public ConfigurationFileDriver()
        {
            _configurationLazy = new Lazy<IConfiguration>(GetConfiguration);
        }

        public IConfiguration Configuration => _configurationLazy.Value;

        /// <summary>
        ///     Frontend website Url. 
        /// </summary>
        public string HomePage => Configuration["CTCOHomePage"];

        /// <summary>
        ///     Supportcentre website Url. 
        /// </summary>
        public string SupportCentreUrl => Configuration["SupportCentreUrl"];

        /// <summary>
        ///     Portal website Url. 
        /// </summary>
        public string PortalUrl => Configuration["PortalUrl"];

        /// <summary>
        ///     Portal website Url. 
        /// </summary>
        public string SupplierUrl => Configuration["SupplierSupportCentreUrl"];

        /// <summary>
        ///     Gets default culture from config.
        ///     Example: "en-GB"
        /// </summary>
        public string DefaultUiCulture => Configuration["DefaultUICulture"];

        /// <summary>
        ///     Default timeout in seconds from CommonApp.config
        /// </summary>
        public TimeSpan DefaultTimeOut => TimeSpan.FromSeconds(double.Parse(Configuration["DefaultTimeOut"]));

        /// <summary>
        ///     Dealer database connection string
        ///     Example: @"Data Source=vm-tstdb-uks-01;Initial Catalog=test1_eo_eo0;User Id=AutomationTesting;Password=AutomationTesting01;";
        /// </summary>
        public string DealerDbConnectionString => Configuration["DealerDbConnectionString"];

        /// <summary>
        ///     Supportcentre database connection string
        ///     Example: @"Data Source=vm-tstdb-uks-01;Initial Catalog=test1_eo_supportcentre;User Id=AutomationTesting;Password=AutomationTesting01;";
        /// </summary>
        public string SupportCentreDbConnectionString => Configuration["SupportCentreDbConnectionString"];

        /// <summary>
        ///     Gets configuration api url.
        /// </summary>
        public string ConfigurationApiUrl => Configuration["ConfigurationApiUrl"];

        private IConfiguration GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();

            string directoryName = Path.GetDirectoryName(typeof(ConfigurationFileDriver).Assembly.Location);
            configurationBuilder.AddJsonFile(Path.Combine(directoryName, "config.json"));

            return configurationBuilder.Build();
        }
    }
}
