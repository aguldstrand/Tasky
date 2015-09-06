using Microsoft.AspNet.Mvc;
using System;
using Tasky.Filters;
using Tasky.Models;
using Tasky.Services;

namespace Tasky.Controllers
{
    [Route("api/attachments")]
    [ValidateModel]
    public class AttachmentsController : Controller
    {
        private readonly IDataStore<Attachment> store;

        public AttachmentsController(IDataStore<Attachment> store)
        {
            this.store = store;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var attachment = store.Get(id);

            return File(
                fileContents: Convert.FromBase64String(attachment.Value.Base64Data),
                contentType: attachment.Value.ContentType,
                fileDownloadName: attachment.Value.Filename);
        }

        [HttpPost]
        public void Post([FromBody]Attachment value)
        {
            store.Add(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            store.Remove(id);
        }
    }
}
