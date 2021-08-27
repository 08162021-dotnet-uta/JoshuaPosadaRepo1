using Project0.StoreApplication.Domain.Abstracts;
using System.Collections.Generic;
namespace Project0.StoreApplication.Domain.Models

{
  public class Order
  {
    //public List<Order> order;
    public Customer Customer { get; set; }
    public Product Product { get; set; }
    public Store Store { get; set; }

    // public Order(Customer customer, Product product, Store store)
    // {
    //   Customer
    //   Product
    // }


    public override string ToString()
    {
      return $"{Store}- {Product.Name}";
      //return $"{Customer} Ord {Product.Name} Product so far";
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