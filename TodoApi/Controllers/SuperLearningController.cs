using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TodoApi.DataAccess;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperLearningController : ControllerBase
    {
        private ISuperLearningRepository _superLearningRepository;

        public SuperLearningController(ISuperLearningRepository superLearningRepository)
        {
            _superLearningRepository = superLearningRepository;
        }

        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<SuperLearningUser> Get()
        {
            return _superLearningRepository.GetSuperLearningUsers();
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public IActionResult Get(int id)
        {
            var superUser = _superLearningRepository.GetUser(id);

            if (superUser == null)
            {
                return NotFound();
            }

            return new ObjectResult(superUser);
        }

        [HttpPost(Name = "Add User")]
        public IActionResult AddUser(SuperLearningUser user)
        {
            _superLearningRepository.AddUser(user);
            return Ok();
        }

        [HttpDelete("{id}",Name = "Delete User")]
        public IActionResult DeleteUser(SuperLearningUser user)
        {
            var userToDelete = _superLearningRepository.GetUser(user.Id);

            if (userToDelete == null)
            {
                return NotFound();
            }
            
            _superLearningRepository.DeleteUser(userToDelete);
            return Ok();
        }

        [HttpPut(Name = "Update User")]
        public IActionResult UpdateUser(int id, SuperLearningUser user)
        {
            var userToUpdate = _superLearningRepository.GetUser(id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            userToUpdate.Name = user.Name;
            userToUpdate.Role = user.Role;
            
            _superLearningRepository.UpdateUser(userToUpdate);
            return Ok();
        }



        private SuperLearningUser UserToDTO(SuperLearningUser user) =>
            new SuperLearningUser
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role
            };


    }

}
