using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureAPI.Data;
using SecureAPI.DTO;
using SecureAPI.Models;
using System.Linq;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public FilterController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        [HttpGet("FilterDate")]
        public IActionResult FilterDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                var result = _context.Entries.Where(x => x.Date >= startDate && x.Date <= endDate && x.UserId == Guid.Parse(userId)).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //test1@tes1.com

        [HttpGet("Average")]
        public IActionResult Average()
        {
            try
            {
                var userId = _userManager.GetUserId(User);

                var result = _context.SPReportes.FromSqlRaw("SPReportes").ToList();

                #region MyRegion
                //string numstr = string.Empty;
                //var ls = new List<int>();
                //for (int i = 0; i < result.Distance.Length; i++)
                //{
                //    char c = result.Distance[i];

                //    if (c >= '0' && c <= '9')
                //    {
                //        numstr+= c;
                //        if (i == result.Distance.Length -1)
                //        {
                //            ls.Add(int.Parse(numstr));
                //        }
                //    }
                //    else if (!string.IsNullOrEmpty(numstr))
                //    {
                //        ls.Add(int.Parse(numstr));
                //        numstr= string.Empty;
                //    }
                //} 
                #endregion

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
