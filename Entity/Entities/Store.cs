using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Store
    {
        public int StoreId { get; set; } 
        public string? Branch { get; set; } 
        public string? Address { get; set; }

        public ICollection<ItemStoreRelation>? ItemStoreRelations { get; set; }
    }
}
