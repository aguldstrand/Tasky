using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Immutable;
using Tasky.Api.Models;
using Tasky.Filters;
using Tasky.Services;

namespace Tasky.Api.Controllers
{
    [Route("api/projects/{projectId}/sprints/{sprintId}/issues/{issueId}/attachments")]
    [ValidateModel]
    public class AttachmentsController : Controller
    {
        private readonly IDataStore<Project, Sprint, Issue, Attachment> store;

        public AttachmentsController(IDataStore<Project, Sprint, Issue, Attachment> store)
        {
            this.store = store;
        }

        [HttpGet]
        public ImmutableArray<IdentityWrapper<Project, Sprint, Issue, Attachment>> Get(int projectId, int sprintId, int issueId)
        {
            return store.GetAll(projectId, sprintId, issueId);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int projectId, int sprintId, int issueId, int id)
        {
            var attachment = store.Get(projectId, sprintId, issueId, id);

            return File(
                fileContents: Convert.FromBase64String(attachment.Value.Base64Data),
                contentType: attachment.Value.ContentType,
                fileDownloadName: attachment.Value.Filename);
        }

        [HttpPost]
        public void Post(int projectId, int sprintId, int issueId, [FromBody]Attachment value)
        {
            store.Add(projectId, sprintId, issueId, value);
        }

        [HttpPut("{id}")]
        public void Put(int projectId, int sprintId, int issueId, int id, [FromBody]Attachment value)
        {
            store.Update(projectId, sprintId, issueId, id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int projectId, int sprintId, int issueId, int id)
        {
            store.Remove(projectId, sprintId, issueId, id);
        }
    }
}
