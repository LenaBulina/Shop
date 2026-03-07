using NUnit.Framework;
using System;
using MyShop.Backend;
using System.Collections.Generic;

namespace ShopApp.Tests.Models
{
    public class OrderTests
    {
        [Test]
        public void Order_ShouldStoreValuesCorrectly()
        {
            var order = new Order
            {
                Id = 1,
                Date = new DateTime(2024, 1, 1),
                Price = 1000,
                Payment = "Card",
                DeliveryAddress = "Test street"
            };

            Assert.AreEqual(1, order.Id);
            Assert.AreEqual(1000, order.Price);
            Assert.AreEqual("Card", order.Payment);
        }

        [Test]
        public void Order_AddProducts_ProductStoredInCollection()
        {
            // Arrange
            var product = new Product { Id = 1, Title = "Laptop" };

            var order = new Order
            {
                Products = new List<Product>()
            };

            // Act
            order.Products.Add(product);

            // Assert
            Assert.AreEqual(1, order.Products.Count);
        }

        [Test]
        public void Order_SetCustomer_CustomerAssignedCorrectly()
        {
            // Arrange
            var customer = new Customer { Id = 10, Name = "John" };

            var order = new Order
            {
                Customer = customer
            };

            // Assert
            Assert.AreEqual(customer, order.Customer);
        }
    }
}