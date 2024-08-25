using webTESTAPP.Bussiness.Core;
using Data;
using System.Threading.Tasks;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
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

        //update
        public async Task<ItemStoreRelation> Update(UpdateItemStoreRelationDTO updateRequest)
        {
            ItemStoreRelation? itemStoreRelation = await uow.ItemStoreRelationRepository.Get(x => x.RelationId == updateRequest.ItemStoreRelationId).FirstOrDefaultAsync();
            if (itemStoreRelation == null)
            {
                throw new ArgumentException(message: "MSG_ItemStoreRelation invalido");
            }

            itemStoreRelation.ItemId = updateRequest.ItemId;
            itemStoreRelation.StoreId = updateRequest.StoreId;

            uow.ItemStoreRelationRepository.Update(itemStoreRelation);
            await uow.SaveAsync();

            return itemStoreRelation;
        }

        //delete
        public async Task Delete(int id)
        {
            ItemStoreRelation? itemStoreRelation = await uow.ItemStoreRelationRepository.Get(x => x.RelationId == id).FirstOrDefaultAsync();
            if (itemStoreRelation == null)
            {
                throw new ArgumentException(message: "MSG_id invalido");
            }

            uow.ItemStoreRelationRepository.Delete(itemStoreRelation);
            await uow.SaveAsync();
        }

        //get by id
        public async Task<ItemStoreRelation> GetById(int id)
        {
            ItemStoreRelation? itemStoreRelation = await uow.ItemStoreRelationRepository.Get(x => x.RelationId == id).FirstOrDefaultAsync();
            if (itemStoreRelation == null)
            {
                throw new ArgumentException(message: "MSG_id invalido");
            }

            return itemStoreRelation;
        }

        //get by store
        public async Task<ItemStoreRelation[]> GetByStore(int id)
        {
            return await uow.ItemStoreRelationRepository.Get(x => x.StoreId == id).ToArrayAsync();
        }



    }

}
