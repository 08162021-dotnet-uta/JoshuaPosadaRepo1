using Xunit;
using Project0.StoreApplication.Storage.Repositories;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Testing
{
  public class Repositories
  {
    [Fact]
    public void Test_ProductCollection()
    {
      //arrange =instance of the entity to test
      ProductRepository sut = new ProductRepository();

      // act = execute sut for data
      var actual = sut.Select();

      // assert
      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_OrderCollection()
    {
      //arrange =instance of the entity to test
      OrderRepository sut = new OrderRepository();

      // act = execute sut for data
      var actual = sut.Select();

      // assert
      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_CustomerCollection()
    {
      //arrange =instance of the entity to test
      CustomerRepository sut = new CustomerRepository();

      // act = execute sut for data
      var actual = sut.Select();

      // assert
      Assert.NotNull(actual);
    }
    [Fact]
    public void Test_StoreCollection()
    {
      //arrange =instance of the entity to test
      StoreRepository sut = new StoreRepository();

      // act = execute sut for data
      var actual = sut.Select();

      // assert
      Assert.NotNull(actual);
    }

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