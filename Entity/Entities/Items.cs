using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Items
    {
        public int ItemId { get; set; }        
        public string? Code { get; set; }      
        public string? Description { get; set; } 
        public decimal Price { get; set; }       
        public byte[]? Image { get; set; }    
        public int Stock { get; set; }

        public ICollection<ItemStoreRelation>? ItemStoreRelations { get; set; }
        public ICollection<ClientItemRelation>? ClientItemRelations { get; set; }

    }
}
