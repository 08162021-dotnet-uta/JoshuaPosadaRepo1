using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;
namespace Project0.StoreApplication.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class OrderSingleton
  {
    private static OrderSingleton _OrderSingleton;
    private static readonly OrderRepository _OrderRepository = new OrderRepository();
    public List<Order> Orders { get; private set; }


    public static OrderSingleton Instance
    {
      get
      {
        if (_OrderSingleton == null)
        {
          _OrderSingleton = new OrderSingleton();
        }
        return _OrderSingleton;
      }
    }
    private OrderSingleton()
    {
      Orders = _OrderRepository.Select();
    }
    public void Add(Order Order)
    {
      //Orders.Add(Order);
      //_OrderRepository.Insert(Order);
      _OrderRepository.Insert(Order);
      Orders = _OrderRepository.Select();

    }
    public void Delete()
    {
      //Orders.Add(Order);
      //_OrderRepository.Insert(Order);
      _OrderRepository.Delete();
      Orders = _OrderRepository.Select();

    }


  }
}