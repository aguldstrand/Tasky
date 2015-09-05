using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using Tasky.Services;

namespace Tasky.Controllers
{
    [Route("api/projects/{projectId}/issues")]
    public class IssuesController
    {
        private readonly IDataStore<Project, Issue> store;

        public IssuesController(IDataStore<Project, Issue> store)
        {
            this.store = store;
        }

        [HttpGet]
        public IdentityWrapper<Project, Issue>[] Get(int projectId)
        {
            return store.GetAll(projectId);
        }

        [HttpGet("{id}")]
        public IdentityWrapper<Project, Issue> Get(int projectId, int id)
        {
            return store.Get(projectId, id);
        }

        [HttpPost]
        public void Post(int projectId, [FromBody]Issue value)
        {
            store.Add(projectId, value);
        }

        [HttpPut("{id}")]
        public void Put(int projectId, int id, [FromBody]Issue value)
        {
            store.Update(projectId, id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int projectId, int id)
        {
            store.Remove(projectId, id);
        }
    }
}
