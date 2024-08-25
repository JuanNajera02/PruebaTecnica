using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using webTESTAPP.Business;
using webTESTAPP.DTOs.ItemStoreRelation;


namespace webTESTAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemStoreRelationController : ControllerBase
    {
        private readonly ItemStoreRelationBusiness _itemStoreRelationBusiness;

        public ItemStoreRelationController(ItemStoreRelationBusiness itemStoreRelationBusiness)
        {
            _itemStoreRelationBusiness = itemStoreRelationBusiness;
        }

        [HttpPost, Route("AddItemStoreRelation")]
        public async Task<IActionResult> AddRoute(AddItemStoreRelationDTO addItemStoreRelationDTO)
        {
            var response = await _itemStoreRelationBusiness.Add(addItemStoreRelationDTO);

            return Ok(response);
        }

        //update
        [HttpPost, Route("UpdateItemStoreRelation")]
        public async Task<IActionResult> UpdateRoute(UpdateItemStoreRelationDTO updateItemStoreRelationDTO)
        {
            var response = await _itemStoreRelationBusiness.Update(updateItemStoreRelationDTO);

            return Ok(response);
        }

        //delete
        [HttpPost, Route("DeleteItemStoreRelation")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            await _itemStoreRelationBusiness.Delete(id);

            return Ok();
        }

        //get by id
        [HttpGet, Route("GetItemStoreRelationById")]
        public async Task<IActionResult> GetByIdRoute(int id)
        {
            var response = await _itemStoreRelationBusiness.GetById(id);

            return Ok(response);
        }

        //get by store id
        [HttpGet, Route("GetItemStoreRelationByStoreId")]
        public async Task<IActionResult> GetByStoreIdRoute(int id)
        {
            var response = await _itemStoreRelationBusiness.GetByStore(id);

            return Ok(response);
        }



    }
}
