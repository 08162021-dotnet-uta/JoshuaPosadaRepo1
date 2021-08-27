using System;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Domain.Models
{
  public class GroceryStore : Store
  {
    public GroceryStore()
    {
      Name = "Grocery Store";
    }

    //public string Name { get; set; }

    // public override string ToString()
    // {
    //   return Name ?? DateTime.Now.ToLongDateString();
    // }
  }
}