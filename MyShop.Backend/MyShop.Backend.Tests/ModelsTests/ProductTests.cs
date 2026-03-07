using MyShop.Backend;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ShopApp.Tests.Models
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Product_SetProperties_ShouldStoreValues()
        {
            // Arrange
            var date = new DateTime(2026, 3, 7);

            var product = new Product
            {
                Id = 1,
                Title = "Laptop",
                Type = "Electronics",
                Date = date,
                Info = "High-end laptop",
                Price = 1500,
                Photo = "laptop.jpg"
            };

            // Assert
            Assert.AreEqual(1, product.Id);
            Assert.AreEqual("Laptop", product.Title);
            Assert.AreEqual("Electronics", product.Type);
            Assert.AreEqual(date, product.Date);
            Assert.AreEqual("High-end laptop", product.Info);
            Assert.AreEqual(1500, product.Price);
            Assert.AreEqual("laptop.jpg", product.Photo);
        }

        [Test]
        public void Product_OrdersCollection_ShouldBeEmptyInitially()
        {
            // Arrange
            var product = new Product
            {
                Orders = new List<Order>()
            };

            // Assert
            Assert.IsNotNull(product.Orders);
            Assert.AreEqual(0, product.Orders.Count);
        }

        [Test]
        public void Product_CanAddOrders_ToOrdersCollection()
        {
            // Arrange
            var product = new Product
            {
                Orders = new List<Order>()
            };

            var order1 = new Order { Id = 1, Price = 500 };
            var order2 = new Order { Id = 2, Price = 1000 };

            // Act
            product.Orders.Add(order1);
            product.Orders.Add(order2);

            // Assert
            Assert.AreEqual(2, product.Orders.Count);
            Assert.Contains(order1, (System.Collections.ICollection)product.Orders);
            Assert.Contains(order2, (System.Collections.ICollection)product.Orders);
        }
    }
}