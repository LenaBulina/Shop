namespace MyShop.Backend
{ 
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }        
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
