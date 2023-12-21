using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using POC_BackGroundProcess.Database.Data;
using POC_BackGroundProcess.Database.Model;
using System.Threading;

namespace POC_BackgroundProcess
{
    public class BackGroundProcess : BackgroundService
    {
        #region properties
        private readonly ILogger<BackGroundProcess> _logger;
        private IWebDriver? _driver;
        private BrowserInfo? _browserInfo;
        #endregion

        #region constructor
        public BackGroundProcess(ILogger<BackGroundProcess> logger)
        {
            _logger = logger;
            _driver = null;
            _browserInfo = null;
            FetchBrowserInfo().Wait();
        }
        #endregion

        private async Task FetchBrowserInfo()
        {
            try
            {
                using (var dbContext = new BackgroundProcessDbContext())
                {
                    // Fetch a single BrowserInfo record from the database
                    _browserInfo = await dbContext.BrowserInfo.FirstOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching browser info from the database: {ex.Message}");
            }
        }
        public async Task Start()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            await ExecuteAsync(cancellationTokenSource.Token);
        }
        private void OpenBrowser()
        {
            try
            {
                if (_browserInfo.BrowserName != null)
                {
                    switch (_browserInfo.BrowserName.ToLower())
                    {
                        case "chrome":
                            ChromeDriverService serviceC = ChromeDriverService.CreateDefaultService();
                            serviceC.HideCommandPromptWindow = true;
                            _driver = new ChromeDriver(serviceC);
                            break;
                        case "firefox":
                            FirefoxDriverService serviceF = FirefoxDriverService.CreateDefaultService();
                            serviceF.HideCommandPromptWindow = true;
                            _driver = new FirefoxDriver(serviceF);
                            break;
                        case "safari":
                            SafariDriverService serviceS = SafariDriverService.CreateDefaultService();
                            serviceS.HideCommandPromptWindow = true;
                            _driver = new SafariDriver(serviceS);
                            break;
                        case "edge":
                            EdgeDriverService serviceE = EdgeDriverService.CreateDefaultService();
                            serviceE.HideCommandPromptWindow = true;
                            _driver = new EdgeDriver(serviceE);
                            break;
                        default: throw new InvalidOperationException();
                    }
                    _driver.Navigate().GoToUrl($"{_browserInfo.Url}");
                    _logger.LogInformation($"Logging in text file and opening URL in {_browserInfo.BrowserName} Browser.");
                }
                else
                {
                    _logger.LogError("No browser info available.");
                }
            }
            catch (Exception)
            {
                _logger.LogError($"Error Opening Browser: Please install the {_browserInfo.BrowserName} Browser");
            }
        }
        public void Stop()
        {
            _driver?.Quit();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                OpenBrowser();
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
