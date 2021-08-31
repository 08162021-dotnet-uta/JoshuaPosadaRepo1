using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
// using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Interfaces;
namespace Project0.StoreApplication.Storage.Repositories
{

  public class OrderRepository : IRepository<Order>
  {
    public Order Orders;
    //public List<Order> Orders2 { get; set; }
    public List<Product> Products { get; set; }


    private const string _path = @"/home/joshua/revature/fred_repo/data/orders.xml";
    private static readonly FileAdapter _fileAdapter = new FileAdapter();

    public OrderRepository()
    {
      if (_fileAdapter.ReadFromFile<Order>(_path) == null)
      {
        _fileAdapter.WriteToFile<Order>(_path, new List<Order>());
      }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// 
    public bool RemoveFrom(List<Order> order, int i)
    {
      order.Remove(order[i]);
      _fileAdapter.WriteToFile<Order>(_path, order);
      return true;
    }
    public bool Delete()
    {
      _fileAdapter.WriteToFile<Order>(_path, new List<Order>());
      return true;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Insert(Order entry)
    {
      List<Order> orders = new List<Order>(Select());
      orders.Add(entry);
      _fileAdapter.WriteToFile<Order>(_path, orders);
      return true;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    // public List<Order> Select()
    // {
    //   return _fileAdapter.ReadFromFile<List<Order>>(_path);
    //   //throw new System.NotImplementedException();
    // }
    public List<Order> Select()
    {
      return _fileAdapter.ReadFromFile<Order>(_path);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Order Update()
    {
      throw new System.NotImplementedException();
    }
  }
}