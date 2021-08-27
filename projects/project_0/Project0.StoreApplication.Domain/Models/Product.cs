//using System.String;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
namespace Project0.StoreApplication.Domain.Models
{
  public class Product
  {
    public string Name { get; set; }
    public double Price { get; set; }
    public Store Store { get; set; }
    //List<string> ProductName { get; set; }

    public Product()
    {
      //Name = "Customer";
    }

    public override string ToString()
    {
      return $"{Name} (${Price} {Store})";
    }
  }
}