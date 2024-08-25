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
                Address = addARequest.Address,
                Email = addARequest.Email,
                Password = addARequest.Password
            };

            uow.ClientRepository.Insert(client);
            await uow.SaveAsync();

            return client;

        }

        //update
        public async Task<Client> Update(UpdateClientDTO updateRequest)
        {
            Client? client = await uow.ClientRepository.Get(x => x.Id == updateRequest.Id).FirstOrDefaultAsync();
            if (client == null)
            {
                throw new ArgumentException(message: "MSG_Usuario invalido");
            }

            client.Name = updateRequest.Name;
            client.LastName = updateRequest.LastName;
            client.Address = updateRequest.Address;
            client.Email = updateRequest.Email;
            client.Password = updateRequest.Password;

            uow.ClientRepository.Update(client);
            await uow.SaveAsync();

            return client;
        }

        //delete
        public async Task Delete(int id)
        {
            Client? client = await uow.ClientRepository.Get(x => x.Id == id).FirstOrDefaultAsync();
            if (client == null)
            {
                throw new ArgumentException(message: "MSG_Usuario invalido");
            }

            uow.ClientRepository.Delete(client);
            await uow.SaveAsync();
        }

        //get all
        public async Task<Client[]> GetAll()
        {
            return await uow.ClientRepository.Get().ToArrayAsync();
        }

        //get by id
        public async Task<Client> GetById(int id)
        {
            Client? client = await uow.ClientRepository.Get(x => x.Id == id).FirstOrDefaultAsync();
            if (client == null)
            {
                throw new ArgumentException(message: "MSG_Usuario invalido");
            }
            return client;
        }

        //login
        public async Task<Client> Login(LoginRequest loginRequest)
        {
            Client? client = await uow.ClientRepository.Get(x => x.Email == loginRequest.Email && x.Password == loginRequest.Password).FirstOrDefaultAsync();
            if (client == null)
            {
                throw new ArgumentException(message: "MSG_Usuario invalido");
            }
            return client;


        }
    }
}
