using System.Collections.Generic;
// using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Storage.Adapters;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Project0.StoreApplication.Storage.Repositories
{

  public class CustomerRepository : IRepository<Customer>
  {
    //private const string _path = @"/home/joshua/revature/fred_repo/data/customers.xml";
    private const string _path=@"C:\Users\joshu\source\repos\08162021-dotnet-uta\JoshuaPosadaRepo1\data\customers.xml";
    private static readonly FileAdapter _fileAdapter = new FileAdapter();
        DataAdapter dataAdapter = new DataAdapter();
        public CustomerRepository()
    {
      if (_fileAdapter.ReadFromFile<Customer>(_path) == null)
      {
        _fileAdapter.WriteToFile<Customer>(_path, dataAdapter.Customers.FromSqlRaw("select * from Customer.Customer").ToList()); //new List<Customer>());
      }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Insert(Customer entry)
    {
     _fileAdapter.WriteToFile<Customer>(_path, new List<Customer> { entry });
   
       
            
  
      return true;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>

    public List<Customer> Select()
    {
                                 //   _da.Customers.FromSqlRaw("select * from Customer.Customer").ToList();
            //return dataAdapter.Customers.FromSqlRaw("select * from Customer.Customer").ToList();
   /*         foreach (var x in hi)
            {
                System.Console.WriteLine(x);
            }*/
            //return dataAdapter.Customers.FromSqlRaw("select Name from Customer.Customer").ToList();
            return _fileAdapter.ReadFromFile<Customer>(_path);
           
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Customer Update()
    {
      throw new System.NotImplementedException();
    }
  }
}