using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webTESTAPP.Business;
using webTESTAPP.DTOs.Store;

namespace webTESTAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly StoreBusiness _storeBusiness;

        public StoreController(StoreBusiness storeBusiness)
        {
            _storeBusiness = storeBusiness;
        }

        [HttpPost, Route("AddStore")]
        public async Task<IActionResult> AddRoute(AddStoreDTO addStoreDTO)
        {
            var response = await _storeBusiness.Add(addStoreDTO);

            return Ok(response);
        }

        //update
        [HttpPut, Route("UpdateStore")]
        public async Task<IActionResult> UpdateRoute([FromBody] UpdateStoreDTO updateStoreDTO)
        {
            var response = await _storeBusiness.Update(updateStoreDTO);

            return Ok(response);
        }

        //delete
        [HttpDelete("DeleteStore/{id}")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            await _storeBusiness.Delete(id);

            return Ok();
        }

        //get all
        [HttpGet, Route("GetAllStores")]
        public async Task<IActionResult> GetAllRoute()
        {
            var response = await _storeBusiness.GetAll();

            return Ok(response);
        }

        //get by id
        [HttpGet, Route("GetStoreById")]
        public async Task<IActionResult> GetByIdRoute(int id)
        {
            var response = await _storeBusiness.GetById(id);

            return Ok(response);
        }

    }
}
