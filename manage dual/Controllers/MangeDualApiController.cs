
using manage_dual.Models;
using manage_dual.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace manage_dual.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MangeDualApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public MangeDualApiController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<client>>> Getclients()
        {
            var result = await _db.client.ToListAsync();

            return Ok(result);

        }


        [HttpGet("{id:int}", Name = "GetClientById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<client>> GetClientId(int id)
        {
    
            if (id == 0)
            {
                return BadRequest();
            }

            var Client = await _db.client.FirstOrDefaultAsync(u => u.clientId == id);
            if (Client == null)
            {
                return NotFound();
            }
            return Ok(Client);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> CreateClient([FromBody] client client)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(client);
            }
            if (client == null)
            {
                return BadRequest(client);
            }
            if (client.clientId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            await _db.client.AddAsync(client);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetClientById", new { id = client.clientId }, client);

        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteClient")]
        public async Task<IActionResult> DeleteClient(int id)//IActionResult you can not return with it
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = await _db.client.FirstOrDefaultAsync(u => u.clientId == id);
            if (result != null)
            {
                _db.client.Remove(result);
                await _db.SaveChangesAsync();
            }
            return Ok();
        }
        [HttpPut("{id:int}", Name = "UpdateClient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> UpdateClient(int id, [FromBody] client client)
        {
            try
            {
            var result = await _db.client.FirstOrDefaultAsync(u => u.clientId == id);
            if (result == null)
            {
                return BadRequest();
            }
            result.Name = client.Name;
            result.clientId = id;
            result.Payment = client.Payment;
            result.City = client.City;
            result.Item = client.Item;
            result.Email = client.Email;
            result.Address = client.Address;
            result.PostalCode = client.PostalCode;
            result.ClientDateAddedToSystem = client.ClientDateAddedToSystem;
            result.PhoneNumber = client.PhoneNumber;
            await _db.SaveChangesAsync();
            return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("Search/{name}")]
        public async Task<ActionResult<client>> Search(string name)
        {
            try
            {
                var result = await _db.client.FirstOrDefaultAsync(u => u.Name == name);

                if (result != null)
                {
                    return Ok(result);
                }
                if (result == null)
                    throw new Exception("The Search result not found.");

                return NotFound();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost("Sort")]
        public async Task<ActionResult<IEnumerable<client>>> Sort()
        {
            try
            {
                var result = await _db.client.ToListAsync();

                if (result != null)
                {
                    return Ok(result.OrderByDescending(u => u.Name));
                }
                if (result == null)
                    throw new Exception("The Search result not found.");

                return NotFound();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        [HttpGet("Pagination/{pageSize}")]
        public async Task<ActionResult<IEnumerable<client>>> Pagination(int pageSize)
            {
            try
            {
                var result = await _db.client.ToListAsync();
                int totalRecords = result.Count();
                //int pageSize = 3;
                int currentPage = 1;
                if (totalRecords > 0 && result != null)
                {
                    int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

                    result = result.Skip(currentPage).Take(totalPages).ToList();
                    return Ok(result);

                }

                if (result == null)
                    throw new Exception("The Search result not found.");

                return NotFound();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }








}
