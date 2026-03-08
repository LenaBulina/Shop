using Microsoft.EntityFrameworkCore;
using MyShop.Backend;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public static class DbContextFactory
{
    public static ApplicationContext Create()
    {
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new ApplicationContext(options);
    }
}

[TestFixture]
public class ApplicationContextTests
{
    [Test]
    public void AddProduct_ShouldSaveToDatabase()
    {
        using var context = DbContextFactory.Create();

        var product = new Product
        {
            Title = "Phone",
            Type = "Electronics",
            Price = 500
        };

        context.Products.Add(product);
        context.SaveChanges();

        var result = context.Products.First();

        Assert.AreEqual("Phone", result.Title);
        Assert.AreEqual(500, result.Price);
    }

    [Test]
    public void Order_ShouldHaveCustomerRelation()
    {
        using var context = DbContextFactory.Create();

        var customer = new Customer
        {
            Name = "John",
            Email = "john@test.com"
        };

        context.Customers.Add(customer);
        context.SaveChanges();

        var order = new Order
        {
            Price = 1000,
            CustomerId = customer.Id
        };

        context.Orders.Add(order);
        context.SaveChanges();

        var result = context.Orders
            .Include(o => o.Customer)
            .First();

        Assert.AreEqual("John", result.Customer.Name);
    }

    [Test]
    public void Product_ShouldHaveOrdersRelation()
    {
        using var context = DbContextFactory.Create();

        var product = new Product
        {
            Title = "Laptop",
            Price = 2000,
            Orders = new List<Order>()
        };

        var order = new Order
        {
            Price = 2000,
            Products = new List<Product>()
        };

        product.Orders.Add(order);

        context.Products.Add(product);
        context.SaveChanges();

        var result = context.Products
            .Include(p => p.Orders)
            .First();

        Assert.AreEqual(1, result.Orders.Count);
    }
}