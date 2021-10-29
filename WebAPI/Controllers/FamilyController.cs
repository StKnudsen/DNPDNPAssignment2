using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController : ControllerBase
    {
        private FileContext _fileContext;

        public FamilyController(FileContext fileContext)
        {
            _fileContext = fileContext;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamiliesAsync()
        {
            try
            {
                IList<Family> families = await _fileContext.GetFamiliesAsync();
                Console.WriteLine("Reached GetFamiliesAsync");
                return Ok(families);
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
                await _fileContext.SaveChangesAsync(adult, streetName);
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