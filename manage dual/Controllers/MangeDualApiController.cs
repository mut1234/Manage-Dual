using manage_dual.Data;
using manage_dual.Models;
using manage_dual.NewFolder;
using Microsoft.AspNetCore.Mvc;

namespace manage_dual.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MangeDualApiController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<client>> Getclients()
        {
            return Ok(ManageStore.clientsList);

        }

    }
}
