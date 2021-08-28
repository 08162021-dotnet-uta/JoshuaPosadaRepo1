using Project0.StoreApplication.Domain.Models;
using System.Collections.Generic;
namespace Project0.StoreApplication.Domain.Models
{
  public class Customer
  {
    public string Name { get; set; }

    public List<Order> Orders { get; set; }

    public Customer()
    {
      Name = "Customer_1";
    }

    public override string ToString()
    {
      return $"{Name} has {Orders.Count} Orders so far";
    }



  }
}