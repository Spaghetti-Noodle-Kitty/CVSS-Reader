using System.Text.Json;

namespace JSON_Test
{
    public static partial class JsonExtensions
    {
        public static JsonElement? Get(this JsonElement element, string name) =>
            element.ValueKind != JsonValueKind.Null && element.ValueKind != JsonValueKind.Undefined && element.TryGetProperty(name, out var value)
                ? value : (JsonElement?)null;

        public static JsonElement? Get(this JsonElement element, int index)
        {
            if (element.ValueKind == JsonValueKind.Null || element.ValueKind == JsonValueKind.Undefined)
                return null;
            // Throw if index < 0
            return index < element.GetArrayLength() ? element[index] : null;
        }
    }

    public class WebRequest
    {
        public static double SEVERITY_ = 0.0;
        private static double? Sev;

        private async static Task GetCVE(string CVE)
        {
            using (var client = new HttpClient())
            {
                // Gets JSON representation of CVE-Attributes
                var json = await client.GetStringAsync("https://services.nvd.nist.gov/rest/json/cve/1.0/" + CVE);
                var doc = JsonSerializer.Deserialize<JsonElement>(json);

                var node = doc.Get("result")?.Get("CVE_Items")?.Get(0)?.Get("impact")?.Get("baseMetricV2")?.Get("cvssV2");

                Sev = (node?.Get("baseScore")?.GetDouble());

                if (Sev != null)
                    SEVERITY_ = Sev.Value;
            }
        }

        public static void GetCVESeverity()
        {
            Task t = GetCVE("CVE-2008-4114");
            t.GetAwaiter().GetResult();

            Console.WriteLine(SEVERITY_);
            Console.ReadLine();
        }
    }
}
