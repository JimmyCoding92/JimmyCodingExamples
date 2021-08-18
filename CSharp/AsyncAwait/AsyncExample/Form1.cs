using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncExample
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void SyncDownload_Click(object sender, EventArgs e)
        {
            Result.Text = "";

            var stopwatch = Stopwatch.StartNew();

            DownloadWebsitesSync();

            Result.Text += $"Elapsed time: {stopwatch.Elapsed}{Environment.NewLine}";
        }

        private void DownloadWebsitesSync()
        {
            foreach(var site in Contents.WebSites)
            {
                var result = DownloadWebSiteSync(site);
                ReportResult(result);
            }
        }

        private async Task DownloadWebsitesAsync()
        {
            List<Task<string>> downloadWebsiteTasks = new List<Task<string>>();

            foreach (var site in Contents.WebSites)
            {
                downloadWebsiteTasks.Add(DownloadWebSiteAsync(site));
            }

            var results = Task.WhenAll(downloadWebsiteTasks).Result;

            foreach(var result in results)
            {
                ReportResult(result);
            }
        }

        private string DownloadWebSiteSync(string url)
        {
            var response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            var responsePayloadBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();

            return $"Finish downloding data from {url}. Total bytes returned {responsePayloadBytes.Length}. {Environment.NewLine}";
        }

        private async Task<string> DownloadWebSiteAsync(string url)
        {
            var response = await httpClient.GetAsync(url).ConfigureAwait(false);
            var responsePayloadBytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

            return $"Finish downloding data from {url}. Total bytes returned {responsePayloadBytes.Length}. {Environment.NewLine}";
        }

        private void ReportResult(string result)
        {
            Result.Text += result;
        }

        private async void AsyncDownload_Click(object sender, EventArgs e)
        {
            Result.Text = "";

            var stopwatch = Stopwatch.StartNew();

            await DownloadWebsitesAsync();

            Result.Text += $"Elapsed time: {stopwatch.Elapsed}{Environment.NewLine}";
        }

        private void Result_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
