using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController : ControllerBase
    {
        private ViaDbContext _dbContext;

        public FamilyController(ViaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        
        public async Task<ActionResult<IList<Family>>> GetFamiliesAsync()
        {
            try
            {
                IList<Family> families = _dbContext.Families.Include(family => family.Adults).ToList();
                Console.WriteLine("Reached GetFamiliesAsync");
                return Ok(families);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("/adults")]
        public async Task<ActionResult<IList<Adult>>> GetAdultsAsync()
        {
            try
            {
                IList<Adult> adults = _dbContext.Adults.ToList();
                Console.WriteLine("Reached GetFamiliesAsync");
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> AddAdultAsync([FromBody] Adult adult, [FromQuery] string streetName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Family family = await _dbContext.Families
                    .Include(f => f.Adults)
                    .FirstAsync(f => f.StreetName.Equals(streetName));
                family.Adults.Add(adult);
                _dbContext.Update(family);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}