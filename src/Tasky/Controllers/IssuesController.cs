using Microsoft.AspNet.Mvc;
using System.Collections.Immutable;
using Tasky.Filters;
using Tasky.Models;
using Tasky.Services;

namespace Tasky.Controllers
{
    [Route("api/projects/{projectId}/sprints/{sprintId}/issues")]
    [ValidateModel]
    public class IssuesController : Controller
    {
        private readonly IDataStore<Project, Sprint, Issue> store;

        public IssuesController(IDataStore<Project, Sprint, Issue> store)
        {
            this.store = store;
        }

        [HttpGet]
        public ImmutableArray<IdentityWrapper<Project, Sprint, Issue>> Get(int projectId, int sprintId)
        {
            return store.GetAll(projectId, sprintId);
        }

        [HttpGet("{id}")]
        public IdentityWrapper<Project, Sprint, Issue> Get(int projectId, int sprintId, int id)
        {
            return store.Get(projectId, sprintId, id);
        }

        [HttpPost]
        public void Post(int projectId, int sprintId, [FromBody]Issue value)
        {
            store.Add(projectId, sprintId, value);
        }

        [HttpPut("{id}")]
        public void Put(int projectId, int sprintId, int id, [FromBody]Issue value)
        {
            store.Update(projectId, sprintId, id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int projectId, int sprintId, int id)
        {
            store.Remove(projectId, sprintId, id);
        }
    }
}
