
namespace MyShop.Backend
{
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public long Price { get; set; }        
        public string Payment { get; set; }
        public string DeliveryAddress { get; set; }
        public int CustomerId { get; set; }

        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }
    
       
    }
}
