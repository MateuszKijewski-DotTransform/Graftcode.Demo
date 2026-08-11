using System.Text.Json;

namespace Graftcode.Demo.Document.Application
{
    public static class DocumentServiceSurface
    {
        private const string DefaultBasePath = "DocumentStorage";

        public static void CreateDocument(string fileName, string content)
        {
            var service = CreateDocumentService();
            var request = new CreateDocumentRequest
            {
                FileName = fileName,
                Content = content
            };

            service.CreateDocumentAsync(request).GetAwaiter().GetResult();
        }

        public static int CountDocuments()
        {
            var service = CreateDocumentService();
            return service.CountDocumentsAsync().GetAwaiter().GetResult().Count;
        }

        public static string GetDocumentDataAsync(string fileName)
        {
            var service = CreateDocumentService();
            var result = service.GetDocumentDataAsync(fileName).GetAwaiter().GetResult();
            return JsonSerializer.Serialize(result);
        }

        private static string GetPath(string baseDocumentPath)
        {
            return Path.GetFullPath(baseDocumentPath.Replace('\\', Path.DirectorySeparatorChar)
                                                    .Replace('/', Path.DirectorySeparatorChar));
        }

        private static DocumentService CreateDocumentService()
        {
            return new DocumentService(GetPath(DefaultBasePath));
        }
    }
}
