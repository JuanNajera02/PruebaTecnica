using webTESTAPP.Bussiness.Core;
using Data;
using System.Threading.Tasks;
using Entity.Entities;
using webTESTAPP.DTOs.Item;


namespace webTESTAPP.Business
{
    public class ItemsBusiness : BaseBusiness
    {
        public ItemsBusiness(UnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public async Task<Items> Add(AddItemDTO addARequest)
        {
            var item = new Items
            {
                Code = addARequest.Code,
                Description = addARequest.Description,
                Price = addARequest.Price,
                Image = addARequest.Image,
                Stock = addARequest.Stock
           
            };

            uow.ItemsRepository.Insert(item);
            await uow.SaveAsync();

            return item;

        }

    }
}
