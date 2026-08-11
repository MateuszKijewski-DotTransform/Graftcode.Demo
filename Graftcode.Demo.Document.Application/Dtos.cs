namespace Graftcode.Demo.Document.Application
{
    public class CreateDocumentRequest
    {
        public string FileName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }

    public class DocumentData
    {
        public string FileName { get; set; } = string.Empty;
        public string CreatedOn { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }

    public class CountDocumentsResponse
    {
        public int Count { get; set; }
    }
}
