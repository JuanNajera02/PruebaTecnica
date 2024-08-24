using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class ClientItemRelation
    {
        public int RelationId { get; set; } 
        public int ClientId { get; set; }
        public int ItemId { get; set; }
        public DateTime DateAdded { get; set; }


        public Items? Item { get; set; }
        public Client? Client { get; set; }

    }
}
