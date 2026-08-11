namespace Graftcode.Demo.Infrastructure
{
    public interface IDocumentHttpClient
    {
        Task CreateDocumentAsync(CreateDocumentRequest request);
        Task<CountDocumentsResponse> CountDocumentsAsync();
        Task<DocumentData> GetDocumentDataAsync(string fileName);
    }
}
