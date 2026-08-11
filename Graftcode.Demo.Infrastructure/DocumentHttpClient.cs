using System.Net.Http.Json;

namespace Graftcode.Demo.Infrastructure
{
    public class DocumentHttpClient : IDocumentHttpClient
    {
        private readonly HttpClient _httpClient;

        public DocumentHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateDocumentAsync(CreateDocumentRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("documents", request);
            response.EnsureSuccessStatusCode();
        }

        public async Task<CountDocumentsResponse> CountDocumentsAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<CountDocumentsResponse>("documents/count");
            return result!;
        }

        public async Task<DocumentData> GetDocumentDataAsync(string fileName)
        {
            var result = await _httpClient.GetFromJsonAsync<DocumentData>($"documents/{fileName}");
            return result!;
        }
    }
}
