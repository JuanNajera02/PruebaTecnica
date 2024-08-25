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

        //update
        [HttpPost, Route("UpdateClientItemRelation")]
        public async Task<IActionResult> UpdateRoute(UpdateClientItemRelationDTO updateClientItemRelationDTO)
        {
            var response = await _clientItemRelationBusiness.Update(updateClientItemRelationDTO);

            return Ok(response);
        }

        //delete
        [HttpPost, Route("DeleteClientItemRelation")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            await _clientItemRelationBusiness.Delete(id);

            return Ok();
        }

        //get by id
        [HttpGet, Route("GetClientItemRelationById")]
        public async Task<IActionResult> GetByIdRoute(int id)
        {
            var response = await _clientItemRelationBusiness.GetById(id);

            return Ok(response);
        }

        //get by client id
        [HttpGet, Route("GetClientItemRelationByClientId")]
        public async Task<IActionResult> GetByClientIdRoute(int clientId)
        {
            var response = await _clientItemRelationBusiness.GetByClientId(clientId);

            return Ok(response);
        }

    }
}
