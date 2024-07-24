using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    internal class Api
    {
        public static async Task<Root> Get(int limit)
        {
            using HttpClient client = new HttpClient();
            try
            {
                string url = "https://dummyjson.com/product?limit=100";
                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Root>(jsonResponse);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
    }
}
