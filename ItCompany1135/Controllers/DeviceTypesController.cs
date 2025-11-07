using ItCompany1135.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Interfaces;
using System.Security.Claims;

namespace ItCompany1135.Controllers
{
    [Route("api/device-types")]
    [ApiController]
    public class DeviceTypesController : ControllerBase
    {
        IMediator mediator;
        public DeviceTypesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        //[HttpPost]
        //public Task<ActionResult> CreateDeviceType()
        //{
        //    return Ok();
        //}
        Client? GetClient()
        {
            var claim = User.Claims.First();
            if (claim.Type != ClaimValueTypes.Sid)
                return null;

            var client = db.Clients.Find(claim.Value);
            if (client == null)
                return null;

            return client;
        }

}
}
