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

        //update
        [HttpPost, Route("UpdateClient")]
        public async Task<IActionResult> UpdateRoute(UpdateClientDTO updateClientDTO)
        {
            var response = await _clientBusiness.Update(updateClientDTO);

            return Ok(response);
        }

        //delete
        [HttpPost, Route("DeleteClient")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            await _clientBusiness.Delete(id);

            return Ok();
        }

        //get all
        [HttpGet, Route("GetAllClients")]
        public async Task<IActionResult> GetAllRoute()
        {
            var response = await _clientBusiness.GetAll();

            return Ok(response);
        }

        //get by id
        [HttpGet, Route("GetClientById")]
        public async Task<IActionResult> GetByIdRoute(int id)
        {
            var response = await _clientBusiness.GetById(id);

            return Ok(response);
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var response = await _clientBusiness.Login(email, password);

            return Ok(response);
        }
    }
}
