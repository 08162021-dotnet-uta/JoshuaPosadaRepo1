using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;
namespace Project0.StoreApplication.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class CustomerSingleton
  {
    private static CustomerSingleton _customerSingleton;
    private static readonly CustomerRepository _customerRepository = new CustomerRepository();
    public List<Customer> Customers { get; private set; }

    /// <summary>
    ///  The Singleton's instance is stored in a static field. 
    /// Instance Static Constructor that creates a new Instance
    /// </summary>
    /// <value></value>
    public static CustomerSingleton Instance
    {
      get
      {
        if (_customerSingleton == null)
        {
          _customerSingleton = new CustomerSingleton();
        }
        return _customerSingleton;
      }
    }
    /// <summary>
    /// Stores list of customers into List<Customer> Customers
    /// </summary>
    private CustomerSingleton()
    {
      Customers = _customerRepository.Select();
    }
    /// <summary>
    /// Inserts customer into repository
    /// reads the list into List<Customer> Customers
    /// </summary>
    /// <param name="customer"></param>
    public void Add(Customer customer)
    {
      _customerRepository.Insert(customer);
      Customers = _customerRepository.Select();

    }


  }
}