using POC_BackGroundProcess.Database.Data;
using POC_BackGroundProcess.Database.Model;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using Microsoft.Extensions.Logging;
using POC_BackgroundProcess;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BackgroundProcessUI
{
    public partial class BackgroundProcessUI : Form
    {
        #region properties
        private readonly BackgroundProcessDbContext _backgroundProcessDbContext;
        private BackGroundProcess _backgroundProcess;
        #endregion

        #region constructor
        public BackgroundProcessUI()
        {
            InitializeComponent();
            Browsers.Items.AddRange(["Chrome", "Edge", "Safari", "Firefox"]);
            Browsers.SelectedIndex = 0;

            // db context instantiation
            _backgroundProcessDbContext = new BackgroundProcessDbContext();
            _backgroundProcessDbContext.InitializeDatabase();
        }
        #endregion

        #region save browser info to database
        private async Task SaveToDatabase(string? browserName, string? url)
        {
            try
            {
                 var existingRecords = await _backgroundProcessDbContext.BrowserInfo.ToListAsync();

                if (existingRecords != null)
                {
                    foreach (var existingRecord in existingRecords)
                    {
                        _backgroundProcessDbContext.BrowserInfo.Remove(existingRecord);
                    }
                }
                BrowserInfo browserInfo = new BrowserInfo { BrowserName = browserName, Url = url };
                await _backgroundProcessDbContext.BrowserInfo.AddAsync(browserInfo);
                await _backgroundProcessDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data to database: {ex.Message}");
            }
        }
        #endregion

        #region startProcessClick
        private async void StartProcess_Click(object sender, EventArgs e)
        {
            string browserName = Browsers.Text;
            string url = Url.Text;

            if (string.IsNullOrEmpty(url) || !IsValidUrl(url))
            {
                MessageBox.Show("Please provide a valid URL");
                return;
            }
            await SaveToDatabase(browserName, url);

            // Start the background process
            this.Hide();
            MessageBox.Show("Background process started...!\nTo stop the service go to the task manager and find for POC_BackGroundProcess and Click on end process. Thanks!!");
            await StartBackgroundProcess();
        }
        #endregion

        #region URL check
        private bool IsValidUrl(string url)
        {
            // Use Uri.TryCreate to check if the provided string is a valid URL
            return Uri.TryCreate(url, UriKind.Absolute, out Uri result) && (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
        }
        #endregion

        #region start background process
        private async Task StartBackgroundProcess()
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddSerilog());
            var logger = loggerFactory.CreateLogger<BackGroundProcess>();

            _backgroundProcess = new BackGroundProcess(logger);
            await _backgroundProcess.Start();
        }
        #endregion
    }
}
