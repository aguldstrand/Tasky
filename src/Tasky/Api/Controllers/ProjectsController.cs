using Microsoft.AspNet.Mvc;
using Tasky.Services;
using Tasky.Filters;
using Tasky.Models;
using System.Collections.Immutable;

namespace Tasky.Controllers
{
    [Route("api/projects")]
    [ValidateModel]
    public class ProjectsController : Controller
    {
        private readonly IDataStore<Project> store;

        public ProjectsController(IDataStore<Project> store)
        {
            this.store = store;
        }

        [HttpGet]
        public ImmutableArray<IdentityWrapper<Project>> Get()
        {
            return store.GetAll();
        }

        [HttpGet("{id}")]
        public IdentityWrapper<Project> Get(int id)
        {
            return store.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Project value)
        {
            store.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Project value)
        {
            store.Update(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            store.Remove(id);
        }
    }
}
