using webTESTAPP.Bussiness.Core;
using Data;
using System.Threading.Tasks;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
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

        //update
        public async Task<Items> Update(UpdateItemDTO updateRequest)
        {
            Items? item = await uow.ItemsRepository.Get(x => x.ItemId == updateRequest.ItemId).FirstOrDefaultAsync();
            if (item == null)
            {
                throw new ArgumentException(message: "MSG_Item invalido");
            }

            item.Code = updateRequest.Code;
            item.Description = updateRequest.Description;
            item.Price = updateRequest.Price;
            item.Image = updateRequest.Image;
            item.Stock = updateRequest.Stock;

            uow.ItemsRepository.Update(item);
            await uow.SaveAsync();

            return item;
        }

        //delete
        public async Task Delete(int id)
        {
            Items? item = await uow.ItemsRepository.Get(x => x.ItemId == id).FirstOrDefaultAsync();
            if (item == null)
            {
                throw new ArgumentException(message: "MSG_Item invalido");
            }

            uow.ItemsRepository.Delete(item);
            await uow.SaveAsync();
        }

        //get all
        public async Task<Items[]> GetAll()
        {
            return await uow.ItemsRepository.Get().ToArrayAsync();
        }

        //get by id
        public async Task<Items> GetById(int id)
        {
            Items? item = await uow.ItemsRepository.Get(x => x.ItemId == id).FirstOrDefaultAsync();
            if (item == null)
            {
                throw new ArgumentException(message: "MSG_Item invalido");
            }

            return item;
        }

    }
}
