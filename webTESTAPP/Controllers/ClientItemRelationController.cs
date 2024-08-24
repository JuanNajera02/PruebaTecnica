using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webTESTAPP.Business;
using webTESTAPP.DTOs.ClientItemRelation;

namespace webTESTAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientItemRelationController : ControllerBase
    {
        private readonly ClientItemRelationBusiness _clientItemRelationBusiness;

        public ClientItemRelationController(ClientItemRelationBusiness clientItemRelationBusiness)
        {
            _clientItemRelationBusiness = clientItemRelationBusiness;
        }

        [HttpPost, Route("AddClientItemRelation")]
        public async Task<IActionResult> AddRoute(AddClientItemRelationDTO addClientItemRelationDTO)
        {
            var response = await _clientItemRelationBusiness.Add(addClientItemRelationDTO);

            return Ok(response);
        }
    }
}
