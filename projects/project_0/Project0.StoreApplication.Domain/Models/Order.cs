using Project0.StoreApplication.Domain.Abstracts;
using System.Collections.Generic;
using System;
namespace Project0.StoreApplication.Domain.Models

{
  public class Order
  {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
    public Product Product { get; set; }
    public Store Store { get; set; }

    public override string ToString()
    {
      return $"{Store}- {Product.Name}";
    }

    public string pastOrders(List<Order> orders)
    {
      double cost = 0;
      string pastorder = "";
      foreach (var x in orders)
      {
        pastorder += x.Product + "- " + x.Product.Price + "\n";
        cost += x.Product.Price;
      }
      pastorder += "-------------------\n " + "$" + Math.Round(cost, 2);
      return pastorder;
    }

    // public void SetOrder(List<string> pro, Store sto)
    // {
    //   order = new List<Order>() { pro, sto };
    //   //return order;
    // }
    // public List<object> GetOrder()
    // {
    //   //order= new List<object> (){pro,sto};
    //   return order;
    // }
  }
}