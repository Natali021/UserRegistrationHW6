using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UserRegistration_HW6.Models;
using UserRegistration_HW6.Models.UnitOfWorks.UserRights;

namespace UserRegistration_HW6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        UserWork work;
        public UserController()
        {
            work = new UserWork();
        }

        [HttpGet("GetAll")]
        public IEnumerable<object> GetAll() => work.UserRepo.GetAll();

        [HttpGet("GetAllLogin")]
        public IEnumerable<string> GetAllLogin() => work.UserRepo.GetAllLogin();


        [HttpPost("AddUser")]
        public HttpStatusCode Add(User User)
        {
            if (!TryValidateModel(User, nameof(User)))
                return HttpStatusCode.BadRequest;
            ModelState.ClearValidationState(nameof(User));
            work.UserRepo.Add(User);

            return HttpStatusCode.OK;
        }

        [HttpPost("UpdatePassword")]
        public HttpStatusCode UpdatePassword(User User)
        {
            if (!TryValidateModel(User, nameof(User)))
                return HttpStatusCode.BadRequest;
            ModelState.ClearValidationState(nameof(User));
            //work.UserRepo.Add(User);
            work.UserRepo.UpdatePassword(User);

            return HttpStatusCode.OK;
        }

    }
}
