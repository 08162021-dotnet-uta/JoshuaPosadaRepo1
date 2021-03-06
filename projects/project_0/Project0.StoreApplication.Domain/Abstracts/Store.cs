using System;
using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Models;
using System.Collections.Generic;
namespace Project0.StoreApplication.Domain.Abstracts
{
  [XmlInclude(typeof(AthleticStore))]
  [XmlInclude(typeof(GroceryStore))]
  [XmlInclude(typeof(OnlineStore))]
  public class Store
  {
        public int StoreId { get; set; }
    public string Name { get; set; }
    public List<Order> Orders { get; set; }

    public List<Product> ProductCollection { get; set; }

    public void AddOrder(Order Order)
    {
      if (Order != null)
        Orders.Add(Order);

    }


    public override string ToString()
    {
      return Name;// ?? DateTime.Now.ToLongDateString();
    }
  }
}