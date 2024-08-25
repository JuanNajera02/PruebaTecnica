using webTESTAPP.Bussiness.Core;
using Entity.Entities;
using Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webTESTAPP.DTOs.Store;

namespace webTESTAPP.Business
{
    public class StoreBusiness : BaseBusiness
    {
        public StoreBusiness(UnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public async Task<Store> Add(AddStoreDTO addARequest)
        {
            var store = new Store
            {
                Branch = addARequest.Branch,
                Address = addARequest.Address
            };

            uow.StoreRepository.Insert(store);
            await uow.SaveAsync();

            return store;

        }

        //update
        public async Task<Store> Update(UpdateStoreDTO updateRequest)
        {
            Store? store = await uow.StoreRepository.Get(x => x.StoreId == updateRequest.StoreId).FirstOrDefaultAsync();
            if (store == null)
            {
                throw new ArgumentException(message: "MSG_id invalido");
            }

            store.Branch = updateRequest.Branch;
            store.Address = updateRequest.Address;

            uow.StoreRepository.Update(store);
            await uow.SaveAsync();

            return store;
        }

        //delete
        public async Task Delete(int id)
        {
            Store? store = await uow.StoreRepository.Get(x => x.StoreId == id).FirstOrDefaultAsync();
            if (store == null)
            {
                throw new ArgumentException(message: "MSG_id invalido");
            }

            uow.StoreRepository.Delete(store);
            await uow.SaveAsync();
        }

        //get
        public async Task<Store> GetById(int id)
        {
            Store? store = await uow.StoreRepository.Get(x => x.StoreId == id).FirstOrDefaultAsync();
            if (store == null)
            {
                throw new ArgumentException(message: "MSG_id invalido");
            }

            return store;
        }

        //get all
        public async Task<Store[]> GetAll()
        {
            return await uow.StoreRepository.Get().ToArrayAsync();
        }




        
    }
}
