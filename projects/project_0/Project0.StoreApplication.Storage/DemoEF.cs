using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage
{
    public class DemoEF
    {
        private readonly DataAdapter _da = new DataAdapter();
        /*
        public List<Customer> GetCustomers()
        {
            return _da.Customers.FromSqlRaw("select * from Customer.Customer").ToList();

            //_da.Orders.FromSqlRaw("select * from Store.Order where CustomerId = {0}", customers[0].CustomerId);
        }

        public void SetCustomer(Customer customer)
        {
            //_da.Customers.FromSqlRaw("insert into Customer.Customer(Name) values ({0})", customer.Name);
            _da.Database.ExecuteSqlRaw("insert into Customer.Customer(Name) values ({0})", customer.Name);
        }*/
    }
}