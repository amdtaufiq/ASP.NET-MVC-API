using Logique_api.Models;
using Logique_api.Repository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Logique_api.Controllers
{
    public class UserController : ApiController
    {

        private UserRepository userRepository;

        public UserController()
        {
            userRepository = new UserRepository(new LogiqueDbContext());
        }

        // GET: api/user
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetAllUser()
        {
            IEnumerable<User> list = await userRepository.GetAll();
            return Ok(list);
        }

        // POST: api/user
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> Post(User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await userRepository.Add(model);
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        // POST: api/user/login
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await userRepository.Login(request);
            return CreatedAtRoute("DefaultApi", new {  }, response);
        }

        // POST: api/user/logout
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> Logout(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await userRepository.Logout(id);
            return CreatedAtRoute("DefaultApi", new { }, response);
        }
    }
}
