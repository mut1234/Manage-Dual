
using manage_dual.Models;
using manage_dual.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return NoContent();

        }
        [HttpPut("{id:int}", Name = "UpdateClient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] client client)
        {
            if (client == null || id != client.clientId)
            {
                return BadRequest();
            }
            var result = await _db.client.FirstOrDefaultAsync(u => u.clientId == id);
            result.Name = client.Name;
            result.clientId = client.clientId;
            result.Payment = client.Payment;
            result.City = client.City;
            result.Item = client.Item;
            result.Email = client.Email;
            result.Address = client.Address;
            result.PostalCode = client.PostalCode;
            result.ClientDateAddedToSystem = client.ClientDateAddedToSystem;
            result.PhoneNumber = client.PhoneNumber;

            return NoContent();
        }

    }








}
