using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pharmaease.Services.OpenFDA
{
    public class MediServices : IMediServices
    {
        private readonly HttpClient _client;

        public MediServices()
        {
            _client = new HttpClient { BaseAddress = new Uri("https://api.fda.gov/drug/") };
        }

        public async Task<MediResponse> GetMediByBrandName(string brandName)
        {
            string apiKey = "cbwiCJKu6tU3voegiRmHzV3DXuKjzwda6809Z7Jp";

            try
            {
                string formattedBrandName = Uri.EscapeDataString(brandName);

                Console.WriteLine($"Request URL: {_client.BaseAddress}label.json?api_key={apiKey}&search={formattedBrandName}&limit=1");
                HttpResponseMessage response = await _client.GetAsync($"label.json?api_key={apiKey}&search={formattedBrandName}&limit=1");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<RootResponse>(json);

                    if (results?.Results != null && results.Results.Count > 0)
                    {
                        return results.Results[0];
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }
    }

    public class RootResponse
    {
        [JsonProperty("results")]
        public List<MediResponse> Results { get; set; }
    }
}
