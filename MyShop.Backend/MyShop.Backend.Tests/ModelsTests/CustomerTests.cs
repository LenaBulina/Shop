using MyShop.Backend;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ShopApp.Tests.Models
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void Customer_SetProperties_ShouldStoreValues()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                Name = "John Doe",
                Phone = "+380501234567",
                Email = "john@example.com"
            };

            // Assert
            Assert.AreEqual(1, customer.Id);
            Assert.AreEqual("John Doe", customer.Name);
            Assert.AreEqual("+380501234567", customer.Phone);
            Assert.AreEqual("john@example.com", customer.Email);
        }

        [Test]
        public void Customer_OrdersCollection_ShouldBeEmptyInitially()
        {
            // Arrange
            var customer = new Customer
            {
                Orders = new List<Order>()
            };

            // Assert
            Assert.IsNotNull(customer.Orders);
            Assert.AreEqual(0, customer.Orders.Count);
        }

        [Test]
        public void Customer_CanAddOrders_ToOrdersCollection()
        {
            // Arrange
            var customer = new Customer
            {
                Orders = new List<Order>()
            };

            var order1 = new Order { Id = 1, Price = 500 };
            var order2 = new Order { Id = 2, Price = 1000 };

            // Act
            customer.Orders.Add(order1);
            customer.Orders.Add(order2);

            // Assert
            Assert.AreEqual(2, customer.Orders.Count);
            Assert.Contains(order1, (System.Collections.ICollection)customer.Orders);
            Assert.Contains(order2, (System.Collections.ICollection)customer.Orders);
        }
    }
}