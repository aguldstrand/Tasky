using Microsoft.AspNet.Mvc;
using System.Collections.Immutable;
using Tasky.Api.Models;
using Tasky.Filters;
using Tasky.Services;

namespace Tasky.Api.Controllers
{
    [Route("api/projects/{projectId}/sprints/{sprintId}/issues/{issueId}/comments")]
    [ValidateModel]
    public class CommentsController : Controller
    {
        private readonly IDataStore<Project, Sprint, Issue, Comment> store;

        public CommentsController(IDataStore<Project, Sprint, Issue, Comment> store)
        {
            this.store = store;
        }

        [HttpGet]
        public ImmutableArray<IdentityWrapper<Project, Sprint, Issue, Comment>> Get(int projectId, int sprintId, int issueId)
        {
            return store.GetAll(projectId, sprintId, issueId);
        }

        [HttpGet("{id}")]
        public IdentityWrapper<Project, Sprint, Issue, Comment> Get(int projectId, int sprintId, int issueId, int id)
        {
            return store.Get(projectId, sprintId, issueId, id);
        }

        [HttpPost]
        public void Post(int projectId, int sprintId, int issueId, [FromBody]Comment value)
        {
            store.Add(projectId, sprintId, issueId, value);
        }

        [HttpPut("{id}")]
        public void Put(int projectId, int sprintId, int issueId, int id, [FromBody]Comment value)
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
