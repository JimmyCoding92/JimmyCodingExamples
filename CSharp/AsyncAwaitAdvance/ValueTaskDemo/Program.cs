using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace ValueTaskDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchMarkService>();
        }
    }

    [MemoryDiagnoser]
    public class BenchMarkService
    {
        private readonly IEnumerable<string> webSites = new string[] {
            "https://www.zhihu.com",
            "https://www.baidu.com",
            "https://www.weibo.com"
        };

        [Benchmark]
        public async Task LoadDataTask()
        {
            DownloadService downloadService = new DownloadService();

            for (int i = 0; i < 100000; i++)
            {
                foreach(var webSite in webSites)
                {
                    await downloadService.DownloadDataTask(webSite);
                }
            }
        }

        [Benchmark]
        public async ValueTask LoadDataValueTask()
        {
            DownloadService downloadService = new DownloadService();

            for (int i = 0; i < 100000; i++)
            {
                foreach (var webSite in webSites)
                {
                    await downloadService.DownloadDataValueTask(webSite);
                }
            }
        }
    }

    public class DownloadService
    {
        private readonly MemoryCache cache;
        private readonly HttpClient httpClient;
        private readonly CacheItemPolicy cacheItemPolicy;

        public DownloadService()
        {
            this.cache = MemoryCache.Default;
            this.httpClient = new HttpClient();
            this.cacheItemPolicy = new CacheItemPolicy()
            {
                SlidingExpiration = System.TimeSpan.FromDays(1)
            };
        }

        public async Task<object> DownloadDataTask(string website)
        {
            if (cache.Contains(website))
            {
                return cache.Get(website);
            }

            var response = await httpClient.GetAsync(website);
            cache.Set(website, response, cacheItemPolicy);

            return response;
        }

        public async ValueTask<object> DownloadDataValueTask(string website)
        {
            if (cache.Contains(website))
            {
                return cache.Get(website);
            }

            var response = await httpClient.GetAsync(website);
            cache.Set(website, response, cacheItemPolicy);

            return response;
        }
    }
}
