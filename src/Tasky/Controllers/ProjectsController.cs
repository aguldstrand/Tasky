using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Tasky.Services;
using System;

namespace Tasky.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly IDataStore<Project> store;

        public ProjectsController(IDataStore<Project> store)
        {
            this.store = store;
        }

        [HttpGet]
        public IEnumerable<IdentityWrapper<Project>> Get()
        {
            return store.Get();
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
        public void Put(int id, [FromBody]Services.Project value)
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
