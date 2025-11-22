using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Shapes;

namespace Wild_Atlas.Services
{
    public class GBIFAPIService
    {
        private readonly string _baseUrl = "https://api.gbif.org/v1/";

        private async Task<int?> GetTaxonKeyAsync(string commonName)
        {
            HttpClient client = new HttpClient();

            string encoded = Uri.EscapeDataString(commonName);

            string url =
                $"https://api.gbif.org/v1/species/search?q={encoded}" +
                "&qField=VERNACULAR" +
                "&rank=SPECIES" +
                "&status=ACCEPTED" +
                "&datasetKey=d7dddbf4-2cf0-4f39-9b2a-bb099caae36c";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            JsonElement results = root.GetProperty("results");

            if (results.GetArrayLength() == 0)
                return null;

            JsonElement first = results[0];

            int key = first.GetProperty("key").GetInt32();

            return key;
        }

        public async Task<int> GetObservationCountAsync(string name, string polygon, int startYear, int endYear)
        {
            int? taxonKey = await GetTaxonKeyAsync(name);

            if (!taxonKey.HasValue)
                return 0;

            string encodedPolygon = Uri.EscapeDataString(polygon);

            string url =
                "https://api.gbif.org/v1/occurrence/search?" +
                $"taxon_key={taxonKey.Value}" +
                $"&year={startYear},{endYear}" +
                "&has_coordinate=true" +
                $"&geometry={encodedPolygon}" +
                "&limit=0";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            int count = root.GetProperty("count").GetInt32();

            return count;
        }
    }
}
