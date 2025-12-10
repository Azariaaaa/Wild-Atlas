using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Wild_Atlas.Models;

namespace Wild_Atlas.Services
{
    public class GBIFAPIService
    {
        private readonly string _baseUrl = "https://api.gbif.org/v1/";
        private readonly HttpClient _httpClient = new();

        public async Task<SpeciesCheckResultModel> GetSpeciesTrendAsync(
            string commonName,
            string gadmId,
            int startYear,
            int endYear)
        {
            int? taxonKey = await GetTaxonKeyAsync(commonName);

            if (!taxonKey.HasValue || string.IsNullOrWhiteSpace(gadmId))
            {
                return new SpeciesCheckResultModel
                {
                    YearObservations = new Dictionary<int, int>(),
                    Trend = "Inconnue"
                };
            }

            string url =
                $"{_baseUrl}occurrence/search?" +
                $"taxon_key={taxonKey.Value}" +
                $"&year={startYear},{endYear}" +
                "&has_coordinate=true" +
                $"&gadmGid={Uri.EscapeDataString(gadmId)}" +
                "&limit=300";

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            using JsonDocument doc = JsonDocument.Parse(json);

            Dictionary<int, int> yearCounts = GetCountsByYear(doc);
            double slope = CalculateSlope(yearCounts);
            string trend = InterpretTrend(slope);

            return new SpeciesCheckResultModel
            {
                YearObservations = yearCounts,
                Trend = trend
            };
        }

        private async Task<int?> GetTaxonKeyAsync(string commonName)
        {
            string encoded = Uri.EscapeDataString(commonName);

            string url =
                $"{_baseUrl}species/search?q={encoded}" +
                "&qField=VERNACULAR" +
                "&rank=SPECIES" +
                "&status=ACCEPTED" +
                "&datasetKey=d7dddbf4-2cf0-4f39-9b2a-bb099caae36c";

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            using JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            JsonElement results = root.GetProperty("results");

            if (results.GetArrayLength() == 0)
                return null;

            JsonElement first = results[0];

            int key = first.GetProperty("key").GetInt32();

            return key;
        }

        private Dictionary<int, int> GetCountsByYear(JsonDocument doc)
        {
            Dictionary<int, int> yearObservations = new Dictionary<int, int>();

            JsonElement results = doc.RootElement.GetProperty("results");

            foreach (JsonElement item in results.EnumerateArray())
            {
                try
                {
                    string dateString = item.GetProperty("eventDate").GetString();
                    DateTime parsedDate = DateTime.Parse(dateString);
                    int year = parsedDate.Year;

                    if (yearObservations.ContainsKey(year))
                        yearObservations[year]++;
                    else
                        yearObservations.Add(year, 1);
                }
                catch
                {
                }
            }

            return yearObservations;
        }

        private double CalculateSlope(Dictionary<int, int> yearlyCounts)
        {
            int n = yearlyCounts.Count;
            if (n < 2)
                return 0;

            double sumX = 0;
            double sumY = 0;
            double sumXY = 0;
            double sumXX = 0;

            foreach (var kvp in yearlyCounts.OrderBy(x => x.Key))
            {
                double x = kvp.Key;
                double y = kvp.Value;

                sumX += x;
                sumY += y;
                sumXY += x * y;
                sumXX += x * x;
            }

            double numerator = (n * sumXY) - (sumX * sumY);
            double denominator = (n * sumXX) - (sumX * sumX);

            if (denominator == 0)
                return 0;

            return numerator / denominator;
        }

        private string InterpretTrend(double slope)
        {
            const double threshold = 0.1;

            if (slope > threshold)
                return "en augmentation";
            if (slope < -threshold)
                return "en régression";

            return "Stable";
        }
    }
}