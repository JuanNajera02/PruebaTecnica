using Data;
using webTESTAPP.Bussiness.Core;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Threading.Tasks;
using Entity.Entities;
using webTESTAPP.DTOs.Client;


namespace webTESTAPP.Business
{
    public class ClientBusiness : BaseBusiness
    {
        public ClientBusiness(UnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public async Task<Client> Add(AddClientDTO addARequest)
        {
            var client = new Client
            {
                Name = addARequest.Name,
                LastName = addARequest.LastName,
                Address = addARequest.Address
            };

            uow.ClientRepository.Insert(client);
            await uow.SaveAsync();

            return client;

        }
    }
}
