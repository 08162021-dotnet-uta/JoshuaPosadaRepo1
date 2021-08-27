using Project0.StoreApplication.Domain.Abstracts;
using System.Collections.Generic;
namespace Project0.StoreApplication.Domain.Models

{
  public class Purchases
  {
    public Customer Customer { get; set; }
    public Product Product { get; set; }
    public Store Store { get; set; }




    public override string ToString()
    {
      return $"{Store}- {Product.Name}";
    }

  }
}