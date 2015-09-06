using Microsoft.AspNet.Mvc;
using Tasky.Services;
using Tasky.Filters;
using Tasky.Models;

namespace Tasky.Controllers
{
    [Route("api/users")]
    [ValidateModel]
    public class UsersController : Controller
    {
        private readonly IDataStore<User> store;

        public UsersController(IDataStore<User> store)
        {
            this.store = store;
        }

        [HttpGet]
        public IdentityWrapper<User>[] Get()
        {
            return store.GetAll();
        }

        [HttpGet("{id}")]
        public IdentityWrapper<User> Get(int id)
        {
            return store.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]User value)
        {
            store.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User value)
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
