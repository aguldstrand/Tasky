using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using Tasky.Services;

namespace Tasky.Controllers
{
    [Route("api/[controller]")]
    public class IssuesController
    {
        private readonly IDataStore<Issue> store;

        public IssuesController(IDataStore<Issue> store)
        {
            this.store = store;
        }

        [HttpGet]
        public IEnumerable<IdentityWrapper<Issue>> Get()
        {
            return store.Get();
        }

        [HttpGet("{id}")]
        public IdentityWrapper<Issue> Get(int id)
        {
            return store.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Issue value)
        {
            store.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Issue value)
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
