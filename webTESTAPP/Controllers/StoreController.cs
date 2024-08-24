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
    }
}
