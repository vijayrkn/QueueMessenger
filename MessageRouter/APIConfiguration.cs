using System.Net.Http;
using System.Text.Json;

namespace FunctionApp156
{
    public static class APIConfiguration
    {
        public static HttpClient HttpClient = new();
        public static string BaseAPI => "https://localhost:7272/api";
        public static JsonSerializerOptions JsonOptions => new(JsonSerializerDefaults.Web);
    }
}
