using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Interfaces;
namespace Project0.StoreApplication.Storage.Repositories
{

  public class ProductRepository : IRepository<Product>
  {
    //private const string _path = @"/home/joshua/revature/fred_repo/data/products.xml";
    private const string _path=@"C:\Users\joshu\source\repos\08162021-dotnet-uta\JoshuaPosadaRepo1\data\products.xml";
    private static readonly FileAdapter _fileAdapter = new FileAdapter();

    public ProductRepository()
    {
      if (_fileAdapter.ReadFromFile<Product>(_path) == null)
      {
        _fileAdapter.WriteToFile<Product>(_path, new List<Product>(){
           new Product(){Name="Milk", Price=2.33},// Product.GroceryProduct}
      });
      }
      else
      {
        _fileAdapter.WriteToFile<Product>(_path, new List<Product>(){
          new Product() { Name = "Milk", Price = 2.33, Store=new GroceryStore() },
          new Product() { Name = "Coke", Price = 1.00, Store=new GroceryStore() },
          new Product() { Name = "Sugar", Price = .45, Store=new GroceryStore() },
         new Product() { Name = "Tennis Ball", Price = 5.00, Store=new AthleticStore() },
          new Product() { Name = "Racket", Price = 25.00, Store=new AthleticStore() },
          new Product() { Name = "Shoes", Price = 55.00, Store=new AthleticStore() },
           new Product() { Name = "Computer", Price = 1000.00, Store=new OnlineStore() },
            new Product() { Name = "Laptop", Price = 500.00, Store=new OnlineStore() },
            new Product() { Name = "Keyboard", Price = 110.00, Store=new OnlineStore() }
      });
      }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Insert(Product entry)
    {
      _fileAdapter.WriteToFile<Product>(_path, new List<Product> { entry });
      //throw new System.NotImplementedException();
      return true;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    // public List<Customer> Select()
    // {
    //   return _fileAdapter.ReadFromFile<List<Customer>>(_path);
    //   //throw new System.NotImplementedException();
    // }
    public List<Product> Select()
    {
      return _fileAdapter.ReadFromFile<Product>(_path);
    }
    public List<Product> Select(Store store)
    {
      List<Product> productforStore = new List<Product>();
      foreach (Product x in Select())
      {
        if (x.Store.Name.Equals(store.Name))
        {
          productforStore.Add(x);
        }
      }
      return productforStore;

    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Product Update()
    {
      throw new System.NotImplementedException();
    }
  }
}