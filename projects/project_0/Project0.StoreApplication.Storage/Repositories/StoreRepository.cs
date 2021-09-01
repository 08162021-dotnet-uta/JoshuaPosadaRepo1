using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;
//using Project0.StoreApplication


namespace Project0.StoreApplication.Storage.Repositories
{
  /// <summary>
  /// 
  /// </summary>
  public class StoreRepository : IRepository<Store>
  {
    public ProductRepository Product = new ProductRepository();
    //private const string _path = @"/home/joshua/revature/fred_repo/data/stores.xml";
    private const string _path=@"C:\Users\joshu\source\repos\08162021-dotnet-uta\JoshuaPosadaRepo1\data\stores.xml";

    private static readonly FileAdapter _fileAdapter = new FileAdapter();

    public StoreRepository()
    {
/*            if (_fileAdapter.ReadFromFile<Store>(_path) == null)
            {
                _fileAdapter.WriteToFile<Store>(_path, new List<Store>());
            }
            else
            {*/
       _fileAdapter.WriteToFile<Store>(_path, new List<Store>()
        {
       new GroceryStore(){ProductCollection= Product.Select(new GroceryStore())},
       new AthleticStore() { ProductCollection = Product.Select(new AthleticStore())},
       new OnlineStore() { ProductCollection = Product.Select(new OnlineStore())}
      });
/*      }*/
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// 
    // public List<Product> addProducttoCorrectStore(Store store)
    // {
    //   List<Product> productforStore = new List<Product>();
    //   foreach (Product x in Product.Select())
    //   {
    //     if (x.Store.Name.Equals(store.Name))
    //     {
    //       //System.Console.WriteLine(x.Store.Name);
    //       productforStore.Add(x);
    //     }
    //   }
    //   return productforStore;

    // }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Insert(Store entry)
    {

      List<Store> stores = new List<Store>(Select());
      stores.Add(entry);
      _fileAdapter.WriteToFile<Store>(_path, stores);
      return true;
    }



    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// 
    /// 
    public List<Store> Select()
    {
      return _fileAdapter.ReadFromFile<Store>(_path);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Store Update()
    {
      throw new System.NotImplementedException();
    }
  }
}