namespace webTESTAPP.DTOs.ItemStoreRelation
{
    public class AddItemsToStoreDTO
    {
        public int StoreId { get; set; }

        public List<int>? Items { get; set; }
    }
}
