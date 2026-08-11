namespace Graftcode.Demo.Document.Application
{
    public interface IDocumentService
    {
        Task CreateDocumentAsync(CreateDocumentRequest request);
        Task<CountDocumentsResponse> CountDocumentsAsync();
        Task<DocumentData> GetDocumentDataAsync(string fileName);
    }
}
