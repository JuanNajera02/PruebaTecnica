﻿namespace webTESTAPP.DTOs.Item
{
    public class AddItemDTO
    {

        public string? Code { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public byte[]? Image { get; set; }
        public int Stock { get; set; }
    }
}
