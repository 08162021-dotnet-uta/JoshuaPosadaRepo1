using Project0.StoreApplication.Domain.Models;
using System.Collections.Generic;
//using Project0.StoreApplication.Storage.Adapters;
namespace Project0.StoreApplication.Domain.Models
{
  public class Customer
  {
        public byte CustomerId { get; set; }
        public string Name { get; set; }
        //DataAdapter dataAdapter = new DataAdapter();

        public List<Order> Orders { get; set; }

    public Customer()
    {
            Name="1";
      //Name = dataAdapter.Customers.FromSqlRaw("select TOP [Name] from Customer.Customer").ToList()[0];
        }
        public Customer(string name)
        {
            Name = name;
        }
        public Customer(string name, List<Order> orders)
        {
            Name = name;
            Orders = orders;
        }

        public override string ToString()
    {
            return $"{Name} ";
        /*    if (Orders.Count>0)
                return $"{Name} has {Orders.Count} Orders so far";
            else
                return $"{Name} has 0 Orders so far";*/
        }



  }
}