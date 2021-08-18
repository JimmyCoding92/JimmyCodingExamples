using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncExample
{
    public class Helper
    {
        public static async Task<int> ProcessUrlAsync(string url, HttpClient client)
        {
            byte[] content = await client.GetByteArrayAsync(url);
            Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

            return content.Length;
        }
    }
}
