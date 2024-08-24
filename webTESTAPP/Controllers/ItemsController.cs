using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webTESTAPP.Business;
using webTESTAPP.DTOs.Item;

namespace webTESTAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsBusiness _itemsBusiness;

        public ItemsController(ItemsBusiness itemsBusiness)
        {
            _itemsBusiness = itemsBusiness;
        }


        [HttpPost, Route("AddItem")]
        public async Task<IActionResult> AddRoute(AddItemDTO addItemDTO)
        {
            var response = await _itemsBusiness.Add(addItemDTO);

            return Ok(response);
        }



    }
}
