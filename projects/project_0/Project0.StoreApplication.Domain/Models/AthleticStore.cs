using System;
using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Domain.Models
{
  public class AthleticStore : Store
  {
    public AthleticStore()
    {
      Name = "Athletic Store";
    }
    //public string Name { get; set; }

    // public override string ToString()
    // {
    //   return Name ?? DateTime.Now.ToLongDateString();
    // }
  }
}