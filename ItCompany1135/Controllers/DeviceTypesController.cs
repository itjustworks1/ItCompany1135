using ItCompany1135.CQRS.Commands;
using ItCompany1135.CQRS.DTO;
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
        [HttpPost]
        public async Task<ActionResult> CreateDeviceType(DeviceTypeDTO deviceType)
        {
            var command = new CreateDeviceTypeCommand(){ DeviceType = deviceType };
            await mediator.SendAsync(command);
            return Ok();
        }
        [HttpGet("with-warranty-expiry")]
        public async Task<ActionResult<List<DeviceTypeDTO>>> GetTypesWarrantyMonths(int n)
        {
            var command = new GetTypesWarrantyMonthsCommand(){ NMonths = n };
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }

        //Client? GetClient()
        //{
        //    if (claim.Type != ClaimValueTypes.Sid)
        //        return null;

        //    var client = db.Clients.Find(claim.Value);
        //    if (client == null)
        //        return null;

        //    return client;
        //}

}
}
