using Microsoft.Extensions.Configuration;

namespace Graftcode.Demo.Document.Application
{
    public class DocumentService : IDocumentService
    {
        private readonly string _basePath;

        public DocumentService(IConfiguration configuration)
            : this(configuration["DocumentStorage:BasePath"]
                ?? throw new InvalidOperationException("DocumentStorage:BasePath is not configured."))
        {
        }

        public DocumentService(string basePath)
        {
            _basePath = NormalizePath(basePath);
        }

        public async Task CreateDocumentAsync(CreateDocumentRequest request)
        {
            Directory.CreateDirectory(_basePath);
            var filePath = Path.Combine(_basePath, request.FileName.EndsWith(".txt") ? request.FileName : request.FileName + ".txt");
            await File.WriteAllTextAsync(filePath, request.Content);
        }

        public Task<CountDocumentsResponse> CountDocumentsAsync()
        {
            Directory.CreateDirectory(_basePath);
            var count = Directory.GetFiles(_basePath, "*.txt").Length;
            return Task.FromResult(new CountDocumentsResponse { Count = count });
        }

        public async Task<DocumentData> GetDocumentDataAsync(string fileName)
        {
            var filePath = Path.Combine(_basePath, fileName.EndsWith(".txt") ? fileName : fileName + ".txt");
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Document '{fileName}' was not found.");

            var content = await File.ReadAllTextAsync(filePath);
            var createdOn = File.GetCreationTimeUtc(filePath).ToString("O");

            return new DocumentData
            {
                FileName = Path.GetFileName(filePath),
                CreatedOn = createdOn,
                Content = content
            };
        }

        private static string NormalizePath(string path)
        {
            return Path.GetFullPath(path.Replace('\\', Path.DirectorySeparatorChar)
                                       .Replace('/', Path.DirectorySeparatorChar));
        }
    }
}
