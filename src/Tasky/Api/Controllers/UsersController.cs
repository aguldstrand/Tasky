using Microsoft.AspNet.Cryptography.KeyDerivation;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tasky.Api.Models;
using Tasky.Filters;
using Tasky.Services;

namespace Tasky.Api.Controllers
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
        public ImmutableArray<IdentityWrapper<User>> Get()
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

        [HttpPost("sign-in")]
        public async Task SignIn([FromForm] string email, [FromForm] string password)
        {
            byte[] salt = Convert.FromBase64String("X9kFrDdJO1IKOe7rND0YBbszp6vZneYLdbqqtX7YAO46e+4VkKjxQp71/Ioxtmhj+krGb3gLOAKSpAHGKI5XzmV2inM7jP3l+4acSqsyQ7AlJpnhJC8tvsjfsKT1AiWwgKA3JDy6KhQGDcSAoH3/CSyOYNQuNg2cZeGWnKYx/ixljN/XlpfRsYQKfsmv9LlHft0mcOPd+9E4j+cu450s0OiiiCJ8onMVdsgNrU05zbUecNbVyongGBvRYmXUEuNMy+MUwQMsUAwY+amQAqR3CoAW0mRaFGth1jXGHNWN7AeRCXQelF1NUh0fFh7Uxwu55Hs8HzShC6VND/9yoccEsw==");
            var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA1, 10000, 256 / 8));

            var user = Get()
                .Where(u => u.Value.Email == email && u.Value.Password == hash)
                .FirstOrDefault();

            if (user == null)
            {
                return;
            }

            var claims = new List<Claim>
            {
                new Claim("sub", user.Value.Email),
                new Claim("name", user.Value.Name),
                new Claim("email", user.Value.Email),
            };

            var id = new ClaimsIdentity(claims, "local", "name", "role");
            await Context.Authentication.SignInAsync("Cookies", new ClaimsPrincipal(id));
        }

        [HttpPost("sign-out")]
        public async Task SignOut()
        {
            await Context.Authentication.SignOutAsync("Cookies");
        }
    }
}
