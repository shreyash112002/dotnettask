using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DotnetTask.DAO;

using DotnetTask.Model;
using DotnetTask.DAO;

namespace DotnetTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly  IUserDaoImp _userDao;
        public UsersController(IUserDaoImp userDao)
        {
            _userDao = userDao;
        }


        [HttpGet("GetUsers", Name = "GetUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var request = HttpContext.Request;
            string host = $"{request.Scheme}://{request.Host}/";
            List<User> users = await _userDao.GetUsers(host);
            if (users == null || users.Count == 0)
            {
                return NotFound();
            }

            return Ok(users);
        }


        //[HttpPost("AddUser", Name = "AddUser")]
        //public async Task<ActionResult<User>> AddUser(User user)
        //{
        //    var request = HttpContext.Request;
        //    string host = $"{request.Scheme}://{request.Host}";
        //    if (user != null)
        //    {
        //        User insertedUser = await _userDao.AddUser(user, host);
        //        return Ok(insertedUser);

        //    }
        //    else
        //    {
        //        return BadRequest("User Not Inserted");
        //    }
        //}

        [HttpDelete("DeleteUserById", Name = "DeleteUser")]
        public async Task<ActionResult<int>> DeleteUser(int id)
        {
            int rowDeleted = 0;
            if (id > 0)
            {
                rowDeleted = await _userDao.DeleteUserById(id);
                return Ok(rowDeleted);
            }
            return BadRequest("User Id Not Found!");

        }

        [HttpPut("UpdatePhoneNumber", Name = "UpdatePhoneNumber")]
        public async Task<ActionResult<int>> UpdatePhoneNumber(int id, string phonenumber)
        {
            int rowUpdated = 0;
            if (id > 0)
            {
                rowUpdated = await _userDao.UpdateUserPhoneNumberById(id, phonenumber);
                return Ok(rowUpdated);
            }
            return BadRequest("ID Not Found! Please Re-Check Inserted ID ");
        }



        [HttpPost("AddUser", Name = "AddUser")]
        public async Task<ActionResult<User>> AddUser([FromForm] User userDto)
        {
            var request = HttpContext.Request;
            string host = $"{request.Scheme}://{request.Host}/";

            if (userDto != null && userDto.ImageFile != null)
            {
                // Save the uploaded image
                var imagePath = await _userDao.SaveImage(userDto.ImageFile);

                // Map the DTO to the User object
                var user = new User
                {
                    Name = userDto.Name,
                    DateOfBirth = userDto.DateOfBirth,
                    ResidentialAddress = userDto.ResidentialAddress,
                    PermanentAddress = userDto.PermanentAddress,
                    PhoneNumber = userDto.PhoneNumber,
                    EmailAddress = userDto.EmailAddress,
                    MaritalStatus = userDto.MaritalStatus,
                    Gender = userDto.Gender,
                    Occupation = userDto.Occupation,
                    AadharCardNumber = userDto.AadharCardNumber,
                    PanNumber = userDto.PanNumber,
                    Image = imagePath // Assign the saved image path
                };

                // Add user to the database
                User insertedUser = await _userDao.AddUser(user, host);
                return Ok(insertedUser);
            }
            else
            {
                return BadRequest("User or Image Not Provided");
            }
        }


    }
}
