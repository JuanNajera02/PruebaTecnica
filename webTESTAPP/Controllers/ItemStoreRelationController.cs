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
    }
}
