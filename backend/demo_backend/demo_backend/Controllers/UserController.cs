using acima_mbl_bknd.Helpers;
using demo_backend.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace demo_backend.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private IUserService _UserService;
        public UserController(IServiceProvider ServiceProvider)
        {
            _config = ServiceProvider.GetService<IConfiguration>();
            _UserService = ServiceProvider.GetService<IUserService>();
        }
        

        [HttpGet]
        [Route("api/getUser")]
        public async Task<IActionResult> get_user()
        {
            try
            {
                #region Service Invocation
                var response = _UserService.get_user();
                #endregion

                #region Response Handling
                if (response.Status == ServiceStatus.Success)
                {
                    return Ok(response.Content);
                }
                else if (response.Status == ServiceStatus.Invalid)
                {
                    return BadRequest(new { message = response.Message });
                }
                else
                {
                    return StatusCode(500, new { message = response.Message });
                }
                #endregion
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/insertUser")]
        public async Task<IActionResult> insert_user([FromQuery] int id, string name)
        {
            try
            {
                #region Service Invocation
                var response = _UserService.insert_user(id, name);
                #endregion

                #region Response Handling
                if (response.Status == ServiceStatus.Success)
                {
                    return Ok(response.Content);
                }
                else if (response.Status == ServiceStatus.Invalid)
                {
                    return BadRequest(new { message = response.Message });
                }
                else
                {
                    return StatusCode(500, new { message = response.Message });
                }
                #endregion
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/deleteUser")]
        public async Task<IActionResult> delete_user([FromQuery] int id)
        {
            try
            {
                #region Service Invocation
                var response = _UserService.delete_user(id);
                #endregion

                #region Response Handling
                if (response.Status == ServiceStatus.Success)
                {
                    return Ok(response.Content);
                }
                else if (response.Status == ServiceStatus.Invalid)
                {
                    return BadRequest(new { message = response.Message });
                }
                else
                {
                    return StatusCode(500, new { message = response.Message });
                }
                #endregion
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/updateUser")]
        public async Task<IActionResult> update_user([FromQuery] string name, int id)
        {
            try
            {
                #region Service Invocation
                var response = _UserService.update_user(name, id);
                #endregion

                #region Response Handling
                if (response.Status == ServiceStatus.Success)
                {
                    return Ok(response.Content);
                }
                else if (response.Status == ServiceStatus.Invalid)
                {
                    return BadRequest(new { message = response.Message });
                }
                else
                {
                    return StatusCode(500, new { message = response.Message });
                }
                #endregion
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
