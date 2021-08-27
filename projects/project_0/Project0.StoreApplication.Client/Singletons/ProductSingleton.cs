using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;
using Project0.StoreApplication.Domain.Abstracts;
namespace Project0.StoreApplication.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class ProductSingleton
  {
    private static ProductSingleton _productSingleton;
    private static readonly ProductRepository _productRepository = new ProductRepository();
    public List<Product> Products { get; private set; }
    public List<Product> allProducts { get; private set; }


    public static ProductSingleton Instance
    {
      get
      {
        if (_productSingleton == null)
        {
          _productSingleton = new ProductSingleton();
        }
        return _productSingleton;
      }
    }
    private ProductSingleton()
    {
      allProducts = _productRepository.Select();
    }
    public void setStore(Store store)
    {
      Products = _productRepository.Select(store);
    }
    public void Add(Product products)
    {
      //Customers.Add(customer);
      //_customerRepository.Insert(customer);
      _productRepository.Insert(products);
      Products = _productRepository.Select();

    }


  }
}