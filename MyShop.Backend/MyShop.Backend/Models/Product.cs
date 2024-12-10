using System.Collections.Generic;

namespace MyShop.Backend
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public System.DateTime Date { get; set; }
        public string Info { get; set; }
        public long Price { get; set; }
        public string Photo { get; set; }

        public ICollection<Order> Orders { get; set; }
        
    }
}

