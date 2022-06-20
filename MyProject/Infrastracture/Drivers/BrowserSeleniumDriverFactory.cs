using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestCtCoProject.Infrastracture.Drivers
{

    public class BrowserSeleniumDriverFactory
    {
        private const string DOWNLOAD_FOLDER_PREFIX = "Temp_RegTest_";

        private ChromeDriver _chrome;

        private readonly ConfigurationFileDriver _configurationDriver;

        public BrowserSeleniumDriverFactory(ConfigurationFileDriver configurationDriver)
        {
            _configurationDriver = configurationDriver;
        }

        public ChromeDriver GetChrome()
        {
            if (_chrome != null)
                return _chrome;

            //set up download folder
            var downloadFolder = InitializeDownloadFolder();

            //creating driver service
            var service = GetDriverService();

            var options = new ChromeOptions
            {
                UseSpecCompliantProtocol = true
            };

            options.AddArgument("incognito");
            options.AddArgument("no-sandbox");
            options.AddArgument("--dns-prefetch-disable");

            //using headless mode to make screen size full HD
#if !DEBUG
                        options.AddArgument("headless");
#endif
            if (!string.IsNullOrEmpty(downloadFolder))
            {
                options.AddUserProfilePreference("download.default_directory", downloadFolder);
            }

            //force default timeout for everything.
            ChromeDriver driver = new ChromeDriver(service as ChromeDriverService, options, _configurationDriver.DefaultTimeOut);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);

            this._chrome = driver;

            return driver;
        }

        public void ResetBrowser(ChromeDriver chromeDriver)
        {
            //We are reusing browser across feature, so need to delete cookies, this is the only way how to clear cookies for all domains
            chromeDriver.ExecuteChromeCommand("Network.clearBrowserCookies", new Dictionary<string, object>());
        }

        /// <summary>
        ///     Creates driver service and assigns it, so we can access it and kill, if needed.
        /// </summary>
        /// <returns>Driver service</returns>
        private DriverService GetDriverService()
        {
            var chromeDriverFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            return ChromeDriverService.CreateDefaultService(chromeDriverFolder);
        }

        private string InitializeDownloadFolder()
        {
            Console.WriteLine(); //just put empty row after previous messages
            var downloadFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\" + DOWNLOAD_FOLDER_PREFIX + Guid.NewGuid();
            Directory.CreateDirectory(downloadFolder);

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("Not cleaning up, path not provided.");
                return downloadFolder;
            }

            Console.WriteLine($"Cleanup folder path: {path}");
            //cleanup older than 12 hours
            var allDownloadFolders = Directory.GetDirectories(path)
                .Where(x => x.Contains(DOWNLOAD_FOLDER_PREFIX));

            foreach (var dir in allDownloadFolders)
            {
                if ((DateTime.Now - Directory.GetCreationTime(dir)).Hours > 12)
                {
                    //double check
                    if (new DirectoryInfo(dir).Name.StartsWith(DOWNLOAD_FOLDER_PREFIX))
                    {
                        Directory.Delete(dir, true);
                    }
                }
            }

            return downloadFolder;
        }
    }
}
