using Xunit;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Abstracts;
using System.Collections.Generic;
namespace Project0.StoreApplication.Testing
{
  public class ModelsTest
  {
    [Fact]
    public void Test_OrdertoString()
    {
      List<Order> orders = new List<Order>();
      //arrange =instance of the entity to test
      var sut = new Order();

      // act = execute sut for data
      var actual = sut.pastOrders(orders);

      // assert
      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_ProductToString()
    {
      //arrange =instance of the entity to test
      var sut = new Product();

      // act = execute sut for data
      var actual = sut.ToString();

      // assert
      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_PastOrders()
    {
      //arrange =instance of the entity to test
      var sut = new Order();
      List<Order> mocklist = new List<Order>() { };
      // act = execute sut for data
      Order order = new Order();
      order.Customer = new Customer();
      order.Store = new OnlineStore();
      order.Product = new Product();
      order.Product.Name = "Test";
      mocklist.Add(order);
      var actual = sut.pastOrders(mocklist);

      // assert
      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_CustomerToString()
    {
      //arrange =instance of the entity to test
      List<Order> newOrder = new List<Order>();
      var sut = new Customer() { Orders = newOrder };

      // act = execute sut for data
      var actual = sut.ToString();

      // assert
      Assert.NotNull(actual);
    }
    [Fact]
    public void Test_StoreToString()
    {
      //arrange =instance of the entity to test
      AthleticStore ath = new AthleticStore();

      Order order = new Order() { Customer = new Customer() };

      var sut = new AthleticStore();

      // act = execute sut for data
      var actual = sut.ToString();

      // assert
      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_OnlineStoreAddOrder()
    {
      //arrange =instance of the entity to test
      Order order = new Order();
      order.Customer = new Customer();
      order.Store = new OnlineStore();
      order.Product = new Product();
      order.Product.Name = "Test";

      List<Order> mocklist = new List<Order>() { };


      Store sut = new OnlineStore();
      sut.Orders = mocklist;
      sut.AddOrder(order);
      //var actual = sut.Orders;

      // assert
      Assert.NotNull(order.ToString());
    }

    [Fact]
    public void Test_OrderToString()
    {
      //arrange =instance of the entity to test
      Product product = new Product();
      GroceryStore store = new GroceryStore();

      List<Order> newOrder = new List<Order>();
      var sut = new Order() { Product = product, Store = store };

      // act = execute sut for data
      var actual = sut.ToString();

      // assert
      Assert.NotNull(actual);
    }
    // [Theory]
    // [InlineData(0)]
    // [InlineData(1)]
    // [InlineData(2)]
    // public void Test_OneStore(int i)
    // {
    //   var sut = new StoreRepository();
    //   var store = sut.GetStore(i);
    //   Assert.NotNull(store);
    // }

    // [Theory]
    // [InlineData(10)]
    // public void Test_OneStoreNegative(int i)
    // {
    //   var sut = new StoreRepository();
    //   var store = sut.GetStore(i);
    //   Assert.Null(store);
    // }
  }
}