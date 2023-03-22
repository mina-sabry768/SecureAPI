using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecureAPI.Data;
using SecureAPI.DTO;
using SecureAPI.Models;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EntryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public EntryController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "UserManager,Admin")]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {

                return Ok(_context.Entries.OrderBy(x => x.Id).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetByUser")]
        public IActionResult GetByUser()
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                var user = _userManager.GetUserAsync(User).Result;

                var result = _context.Entries.FirstOrDefault(x => x.UserId == Guid.Parse(userId));
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("Save")]
        public IActionResult Save([FromBody] Entry model)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                var user = _userManager.GetUserAsync(User).Result;
                
                if (model != null)
                {
                    var result = new Entry
                    {
                        Id = model.Id,
                        Date = DateTime.Now,
                        Distance = model.Distance,
                        Time = model.Time,
                        UserId = Guid.Parse(userId)
                    };
                    _context.Entries.Add(result);
                    _context.SaveChanges();
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Entry model)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                var user = _userManager.GetUserAsync(User).Result;
                var result = _context.Entries.FirstOrDefault(x => x.Id == id  && x.UserId == Guid.Parse(userId));

                
                if (result != null)
                {
                    result.Date = model.Date;
                    result.Distance = model.Distance;
                    result.Time = model.Time;
                    _context.Entries.Update(result);
                    _context.SaveChanges();
                    return Ok(result);

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                var user = _userManager.GetUserAsync(User).Result;
                var result = _context.Entries.FirstOrDefault(x => x.Id == id && x.UserId == Guid.Parse(userId));
                if (result != null)
                {
                    _context.Entries.Remove(result);
                    _context.SaveChanges();
                    return Ok();

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
