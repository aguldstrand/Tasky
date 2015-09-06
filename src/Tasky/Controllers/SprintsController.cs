using Microsoft.AspNet.Mvc;
using Tasky.Filters;
using Tasky.Models;
using Tasky.Services;

namespace Tasky.Controllers
{
    [Route("api/projects/{projectId}/sprints")]
    [ValidateModel]
    public class SprintsController : Controller
    {
        private readonly IDataStore<Project, Sprint> store;

        public SprintsController(IDataStore<Project, Sprint> store)
        {
            this.store = store;
        }

        [HttpGet]
        public IdentityWrapper<Project, Sprint>[] Get(int projectId)
        {
            return store.GetAll(projectId);
        }

        [HttpGet("{id}")]
        public IdentityWrapper<Project, Sprint> Get(int projectId, int id)
        {
            return store.Get(projectId, id);
        }

        [HttpPost]
        public void Post(int projectId, [FromBody]Sprint value)
        {
            store.Add(projectId, value);
        }

        [HttpPut("{id}")]
        public void Put(int projectId, int id, [FromBody]Sprint value)
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
