using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;
using Project0.StoreApplication.Domain.Abstracts;
namespace Project0.StoreApplication.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class StoreSingleton
  {
    private static StoreSingleton _storeSingleton;
    private static readonly StoreRepository _storeRepository = new StoreRepository();
    public List<Store> Stores { get; private set; }


    public static StoreSingleton Instance
    {
      get
      {
        if (_storeSingleton == null)
        {
          _storeSingleton = new StoreSingleton();
        }
        return _storeSingleton;
      }
    }
    private StoreSingleton()
    {
      Stores = _storeRepository.Select();
    }
    public void Add(Store Store)
    {
      //Customers.Add(customer);
      //_customerRepository.Insert(customer);
      // _customerRepository.Insert(stores);
      // Stores = _customerRepository.Select();
      _storeRepository.Insert(Store);
      Stores = _storeRepository.Select();

    }


  }
}