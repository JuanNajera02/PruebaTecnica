using webTESTAPP.Bussiness.Core;
using Data;
using System.Threading.Tasks;
using Entity.Entities;
using webTESTAPP.DTOs.ItemStoreRelation;


namespace webTESTAPP.Business

{
    public class ItemStoreRelationBusiness: BaseBusiness
    {
        public ItemStoreRelationBusiness(UnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public async Task<ItemStoreRelation> Add(AddItemStoreRelationDTO addARequest)
        {
            var itemStoreRelation = new ItemStoreRelation
            {
                ItemId = addARequest.ItemId,
                StoreId = addARequest.StoreId,
            };

            uow.ItemStoreRelationRepository.Insert(itemStoreRelation);
            await uow.SaveAsync();

            return itemStoreRelation;

        }
    }

}
