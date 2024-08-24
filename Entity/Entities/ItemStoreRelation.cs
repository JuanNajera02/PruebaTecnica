using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class ItemStoreRelation
    {
        public int RelationId { get; set; }
        public int ItemId { get; set; }
        public int StoreId { get; set; }
        public DateTime DateAdded { get; set; }       
        public virtual Items? Item { get; set; }
        public virtual Store? Store { get; set; }
    }
}
