// using Xunit;
// using Project0.StoreApplication.Storage.Repositories;

// namespace Project0.StoreApplication.Testing
// {
//   public class StoreRepositoryTests
//   {
//     [Fact]
//     public void Test_StoreCollection()
//     {
//       //arrange =instance of the entity to test
//       var sut = new StoreRepository();

//       // act = execute sut for data
//       var actual = sut.Stores;

//       // assert
//       Assert.NotNull(actual);
//     }
//     [Theory]
//     [InlineData(0)]
//     [InlineData(1)]
//     [InlineData(2)]
//     public void Test_OneStore(int i)
//     {
//       var sut = new StoreRepository();
//       var store = sut.GetStore(i);
//       Assert.NotNull(store);
//     }

//     [Theory]
//     [InlineData(10)]
//     public void Test_OneStoreNegative(int i)
//     {
//       var sut = new StoreRepository();
//       var store = sut.GetStore(i);
//       Assert.Null(store);
//     }
//   }
// }