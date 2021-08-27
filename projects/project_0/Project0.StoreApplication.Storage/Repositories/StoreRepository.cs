// using System.Collections.Generic;
// using Project0.StoreApplication.Domain.Abstracts;
// using Project0.StoreApplication.Domain.Models;
// using Project0.StoreApplication.Domain.Interfaces;

// namespace Project0.StoreApplication.Storage.Repositories
// {

//   public class StoreRepository : IRepository<Store>
//   {
//     private const string _path = @"/home/joshua/revature/fred_repo/data/stores.xml";
//     public List<Store> Stores
//     { get; set; }
//     public ProductRepository Product = new ProductRepository();

//     public StoreRepository()
//     {
//       var fileAdapter = new FileAdapter();

//       // if (fileAdapter.ReadFromFile() == null)
//       // {
//       //List<string> Product = new List<string> { "Milk", "Tomato Juice", "Coke" };
//       //List<string> Product2 = new List<string> { "Milk", "Tomato Juice", "Coke" };
//       //List<string> Product3 = new List<string> { "Milk", "Tomato Juice", "Coke" };
//       //var stores = (new StoreRepository().Stores);
//       // var Product2 = new ProductRepository();

//       // new GroceryStore(){Name= "Store001"},
//       // new GroceryStore(){Name= "Store002"},
//       // new GroceryStore(){Name= "Store003"}

//       //Write to file***********************************************
//       fileAdapter.WriteToFile<List<Store>>(_path, new List<Store>()
//         {
//       new GroceryStore(){ProductName= Product.GroceryProduct},
//       new AthleticStore(){ProductName= Product.AthleticProduct},
//       new OnlineStore(){ProductName= Product.OnlineProduct}
//         });

//       Stores = fileAdapter.ReadFromFile<List<Store>>(_path);
//     }

//     public Store GetStore(int index)
//     {
//       try
//       {
//         return Stores[index];
//       }
//       catch
//       {
//         return null;
//       }
//     }

//     public bool Delete()
//     {
//       throw new System.NotImplementedException();
//     }

//     public bool Insert(Store entry)
//     {
//       throw new System.NotImplementedException();
//     }

//     public List<Store> Select()
//     {
//       throw new System.NotImplementedException();
//     }

//     public Store Update()
//     {
//       throw new System.NotImplementedException();
//     }

//     private static StoreRepository _storeRepository;
//     // public static StoreRepository GetInstance()
//     // {
//     //   if (_storeRepository == null)
//     //   {
//     //     _storeRepository = new StoreRepository();
//     //   }
//     //   return _storeRepository;
//     // }
//     public static StoreRepository Instance
//     {
//       get
//       {
//         if (_storeRepository == null)
//         {
//           _storeRepository = new StoreRepository();
//         }
//         return _storeRepository;
//       }
//     }

//   }
// }

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
    private const string _path = @"/home/joshua/revature/fred_repo/data/stores.xml";

    private static readonly FileAdapter _fileAdapter = new FileAdapter();

    public StoreRepository()
    {
      if (_fileAdapter.ReadFromFile<Store>(_path) == null)
      {
        _fileAdapter.WriteToFile<Store>(_path, new List<Store>());
      }
      else
      {
        _fileAdapter.WriteToFile<Store>(_path, new List<Store>()
        {
       new GroceryStore(){ProductCollection= Product.Select(new GroceryStore())},
       new AthleticStore() { ProductCollection = Product.Select(new AthleticStore())},
       new OnlineStore() { ProductCollection = Product.Select(new OnlineStore())}
      });
      }
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
      _fileAdapter.WriteToFile<Store>(_path, new List<Store> { entry });

      return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
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