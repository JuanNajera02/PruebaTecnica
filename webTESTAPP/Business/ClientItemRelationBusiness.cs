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

        public async Task<ClientItemRelation[]> AddList(AddItemsToClient addARequest)
        {
            // Obtener todos los ítems en la solicitud en una sola consulta.
            var itemIds = addARequest.Items.Distinct().ToList(); // Para evitar consultas redundantes

            // Recuperar todos los ítems necesarios de la base de datos.
            var items = await uow.ItemsRepository.Get(i => itemIds.Contains(i.ItemId)).ToListAsync();

            // Crear un diccionario para el stock de los ítems.
            var itemStock = items.ToDictionary(i => i.ItemId, i => i);

            // Lista para las relaciones de cliente e ítem.
            var clientItemRelations = new List<ClientItemRelation>();

            // Iterar sobre cada ID de ítem en la solicitud.
            foreach (var itemId in addARequest.Items)
            {
                if (!itemStock.TryGetValue(itemId, out var item) || item.Stock <= 0)
                {
                    throw new InvalidOperationException($"Item with ID {itemId} not found or out of stock.");
                }

                // Disminuir el stock en 1.
                item.Stock -= 1;

                // Crear la relación entre cliente y el ítem.
                var clientItemRelation = new ClientItemRelation
                {
                    ClientId = addARequest.ClientId,
                    ItemId = itemId,
                };

                clientItemRelations.Add(clientItemRelation);

                // Marcar el ítem para actualización.
                uow.ItemsRepository.Update(item);
            }

            // Insertar todas las relaciones de cliente e ítem.
            foreach (var relation in clientItemRelations)
            {
                uow.ClientItemRelationRepository.Insert(relation);
            }

            // Guardar todos los cambios en la base de datos.
            await uow.SaveAsync();

            // Devolver todas las relaciones de cliente e ítem para el cliente especificado.
            return await uow.ClientItemRelationRepository
                .Get(x => x.ClientId == addARequest.ClientId)
                .ToArrayAsync();
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
            return await uow.ClientItemRelationRepository.Get(x => x.ClientId == id).Include(x => x.Item).ToArrayAsync();
        }



    }

}
