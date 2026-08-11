using Graftcode.Demo.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Graftcode.Demo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentHttpClient _documentHttpClient;

        public DocumentsController(IDocumentHttpClient documentHttpClient)
        {
            _documentHttpClient = documentHttpClient;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] CreateDocumentRequest request)
        {
            await _documentHttpClient.CreateDocumentAsync(request);
            return Ok();
        }

        [HttpGet("count")]
        public async Task<IActionResult> CountDocuments()
        {
            var result = await _documentHttpClient.CountDocumentsAsync();
            return Ok(result);
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetDocumentData(string fileName)
        {
            var result = await _documentHttpClient.GetDocumentDataAsync(fileName);
            return Ok(result);
        }
    }
}

