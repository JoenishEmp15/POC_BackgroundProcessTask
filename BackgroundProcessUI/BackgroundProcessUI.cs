using POC_BackGroundProcess.Database.Data;
using POC_BackGroundProcess.Database.Model;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using Microsoft.Extensions.Logging;
using POC_BackgroundProcess;
using Microsoft.EntityFrameworkCore;

namespace BackgroundProcessUI
{
    public partial class BackgroundProcessUI : Form
    {
        #region properties
        private readonly BackgroundProcessDbContext _backgroundProcessDbContext;
        private BackGroundProcess _backgroundProcess;
        private CancellationTokenSource _cancellationTokenSource;
        #endregion
        public BackgroundProcessUI()
        {
            InitializeComponent();
            Browsers.Items.AddRange(["Chrome", "Edge", "Safari", "Firefox"]);
            Browsers.SelectedIndex = 0;

            // db context instantiation
            _backgroundProcessDbContext = new BackgroundProcessDbContext();
            _backgroundProcessDbContext.InitializeDatabase();

            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<BackGroundProcess>();

            _backgroundProcess = new BackGroundProcess(logger);
            _cancellationTokenSource = new CancellationTokenSource();
        }

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
            MessageBox.Show("Background process started...!\nTo Stop the service go to the task manager and find for POC_BackGroundProcess and Click on end process. Thanks!!");
            Close();
        }

        private bool IsValidUrl(string url)
        {
            // Use Uri.TryCreate to check if the provided string is a valid URL
            return Uri.TryCreate(url, UriKind.Absolute, out Uri result) && (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
        }

    }
}
