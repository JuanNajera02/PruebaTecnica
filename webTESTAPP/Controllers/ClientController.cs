using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webTESTAPP.Business;
using webTESTAPP.DTOs.Client;

namespace webTESTAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientBusiness _clientBusiness;

        public ClientController(ClientBusiness clientBusiness)
        {
            _clientBusiness = clientBusiness;
        }


        [HttpPost, Route("AddClient")]
        public async Task<IActionResult> AddRoute(AddClientDTO addClientDTO)
        {
            var response = await _clientBusiness.Add(addClientDTO);

            return Ok(response);
        }
    }
}
