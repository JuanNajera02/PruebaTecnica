using webTESTAPP.Bussiness.Core;
using Data;
using System.Threading.Tasks;
using Entity.Entities;
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
    }

}
