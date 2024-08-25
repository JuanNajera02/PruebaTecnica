using webTESTAPP.Bussiness.Core;
using Data;
using System.Threading.Tasks;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using webTESTAPP.DTOs.ClientItemRelation;



namespace webTESTAPP.Business
{ 
    public class ClientItemRelationBusiness : BaseBusiness
    {
        public ClientItemRelationBusiness(UnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public async Task<ClientItemRelation> Add(AddClientItemRelationDTO addARequest)
        {
            var clientItemRelation = new ClientItemRelation
            {
                ClientId = addARequest.ClientId,
                ItemId = addARequest.ItemId,
            };

            uow.ClientItemRelationRepository.Insert(clientItemRelation);
            await uow.SaveAsync();

            return clientItemRelation;

        }

        //update
        public async Task<ClientItemRelation> Update(UpdateClientItemRelationDTO updateRequest)
        {
            ClientItemRelation? clientItemRelation = await uow.ClientItemRelationRepository.Get(x => x.ClientId == updateRequest.ClientId && x.ItemId == updateRequest.ItemId).FirstOrDefaultAsync();
            if (clientItemRelation == null)
            {
                throw new ArgumentException(message: "MSG_ClientItemRelation invalido");
            }

            clientItemRelation.ClientId = updateRequest.ClientId;
            clientItemRelation.ItemId = updateRequest.ItemId;

            uow.ClientItemRelationRepository.Update(clientItemRelation);
            await uow.SaveAsync();

            return clientItemRelation;
        }


        //delete by id
        public async Task Delete(int id) 
        { 
            ClientItemRelation? clientItemRelation = await uow.ClientItemRelationRepository.Get(x => x.ClientId == id).FirstOrDefaultAsync();
            if (clientItemRelation == null)
            {
                throw new ArgumentException(message: "MSG_ClientItemRelation invalido");
            }

            uow.ClientItemRelationRepository.Delete(clientItemRelation);
            await uow.SaveAsync();
        }

        //get by id
        public async Task<ClientItemRelation> GetById(int id)
        {
            ClientItemRelation? clientItemRelation = await uow.ClientItemRelationRepository.Get(x => x.ClientId == id).FirstOrDefaultAsync();
            if (clientItemRelation == null)
            {
                throw new ArgumentException(message: "MSG_ClientItemRelation invalido");
            }

            return clientItemRelation;
        }

        //get by client id
        public async Task<ClientItemRelation[]> GetByClientId(int id)
        {
            return await uow.ClientItemRelationRepository.Get(x => x.ClientId == id).ToArrayAsync();
        }



    }

}
