using DairElAnbaBeshoy.AppLogic.Manager;
using DairElAnbaBeshoy.AppLogic.ViewModel;
using DairElAnbaBeshoy.Core.Defaults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DairElAnbaBeshoy.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles =nameof(Roles.Admin))]
    public class DeleteRetreaveController : ControllerBase
    {
        private readonly RegisterRetreaveManager registerRetreaveManager;

        public DeleteRetreaveController(RegisterRetreaveManager registerRetreaveManager)
        {
            this.registerRetreaveManager = registerRetreaveManager;
        }
        [HttpDelete]
        public IActionResult DeleteRetreave(int ReservationID)
        {
            if (ReservationID == 0)
                return BadRequest();
            RetreaveVM retreave = registerRetreaveManager.GetRetreave(ReservationID);
            if (retreave == null)
                return NotFound();
            registerRetreaveManager.DeleteRetreave(retreave);
            return Ok();
        }
    }
}
