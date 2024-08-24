using webTESTAPP.Bussiness.Core;
using Entity.Entities;
using Data;
using System.Threading.Tasks;
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
        
    }
}
