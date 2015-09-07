using Microsoft.AspNet.Mvc;
using System.Collections.Immutable;
using Tasky.Api.Models;
using Tasky.Filters;
using Tasky.Services;

namespace Tasky.Api.Controllers
{
    [Route("api/user-groups")]
    [ValidateModel]
    public class UserGroupsController : Controller
    {
        private readonly IDataStore<UserGroup> store;

        public UserGroupsController(IDataStore<UserGroup> store)
        {
            this.store = store;
        }

        [HttpGet]
        public ImmutableArray<IdentityWrapper<UserGroup>> Get()
        {
            return store.GetAll();
        }

        [HttpGet("{id}")]
        public IdentityWrapper<UserGroup> Get(int id)
        {
            return store.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]UserGroup value)
        {
            store.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]UserGroup value)
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
