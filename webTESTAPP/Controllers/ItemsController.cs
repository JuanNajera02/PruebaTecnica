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

        //update
        [HttpPost, Route("UpdateItem")]
        public async Task<IActionResult> UpdateRoute(UpdateItemDTO updateItemDTO)
        {
            var response = await _itemsBusiness.Update(updateItemDTO);

            return Ok(response);
        }

        //delete
        [HttpPost, Route("DeleteItem")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            await _itemsBusiness.Delete(id);

            return Ok();
        }

        //get all
        [HttpGet, Route("GetAllItems")]
        public async Task<IActionResult> GetAllRoute()
        {
            var response = await _itemsBusiness.GetAll();

            return Ok(response);
        }

        //get by id
        [HttpGet, Route("GetItemById")]
        public async Task<IActionResult> GetByIdRoute(int id)
        {
            var response = await _itemsBusiness.GetById(id);

            return Ok(response);
        }




    }
}
