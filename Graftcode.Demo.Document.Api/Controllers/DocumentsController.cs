using Graftcode.Demo.Document.Application;
using Microsoft.AspNetCore.Mvc;

namespace Graftcode.Demo.Document.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] CreateDocumentRequest request)
        {
            await _documentService.CreateDocumentAsync(request);
            return Ok();
        }

        [HttpGet("count")]
        public async Task<IActionResult> CountDocuments()
        {
            var result = await _documentService.CountDocumentsAsync();
            return Ok(result);
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetDocumentData(string fileName)
        {
            try
            {
                var result = await _documentService.GetDocumentDataAsync(fileName);
                return Ok(result);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
