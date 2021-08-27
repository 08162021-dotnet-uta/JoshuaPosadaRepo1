using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Storage.Repositories;
using Project0.StoreApplication.Domain.Models;
using Serilog;
using Project0.StoreApplication.Client.Singletons;


namespace Project0.StoreApplication.Client
{
  /// <summary>
  /// Defines the Program Class
  /// </summary>
  internal class Program
  {
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
    private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly ProductSingleton _productSingleton = ProductSingleton.Instance;
    static List<string> MainMenu = new List<string>() { "Pick a Store", "View Cart", "Add", "Delete", "Purchase", "View Past Orders", "Logout" };
    private const string _logfilePath = @"/home/joshua/revature/fred_repo/data/logs.xml";

    /// <summary>
    /// Defines the Main Method
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      Log.Logger = new LoggerConfiguration().WriteTo.File(_logfilePath).CreateLogger();
      Run(); 
    }
    private static void Run()
    {
      //customers
      if (_customerSingleton.Customers.Count == 0)
      {
        _customerSingleton.Add(new Customer());
      }
      // Output<Customer>(_customerSingleton.Customers);
      var customer = _customerSingleton.Customers[Capture<Customer>(_customerSingleton.Customers)];
      int menu_choice;
      bool notLoggedout = true;
      Order singleOrder = new Order();
      //Purchases bye = new Purchases();

      while (notLoggedout)
      {
        menu_choice = Capture<string>(MainMenu);

        switch (menu_choice)
        {
          case 0:
            //stores
            var store = _storeSingleton.Stores[Capture<Store>(_storeSingleton.Stores)];
            //Output<Store>(_storeSingleton.Stores);
            //products
            if (_productSingleton.allProducts.Count == 0)
            {
              _productSingleton.Add(new Product());
            }
            _productSingleton.setStore(store);
            //Output<Product>(_productSingleton.Products);// has to get the list of products in collection
            var product = _productSingleton.Products[Capture<Product>(_productSingleton.Products)];
            singleOrder.Customer = customer;
            singleOrder.Product = product;
            singleOrder.Store = store;

            _orderSingleton.Add(singleOrder);

            // customer.Orders.Add(singleOrder); // these are not updating with orders right now
            // store.Orders.Add(singleOrder); //

            Console.WriteLine(singleOrder.Customer);
            //Console.WriteLine(hi.Product);
            // Console.WriteLine(hi.Store);
            break;

          case 1:
            Console.WriteLine("***CART***");
            Output<Order>(_orderSingleton.Orders);
            Console.WriteLine("***END CART***");
            break;

          case 2:
            Console.WriteLine("Add");
            _orderSingleton.Add(_orderSingleton.Orders[Capture<Order>(_orderSingleton.Orders)]);


            break;

          case 3:
            Console.WriteLine("Delete");
            List<Order> hello = new List<Order>();
            _orderSingleton.Orders.Remove(_orderSingleton.Orders[Capture<Order>(_orderSingleton.Orders)]);
            hello = _orderSingleton.Orders;
             Output<Order>(_orderSingleton.Orders);
             _orderSingleton.Orders.Clear(); //Delete
           // Output<Order>(_orderSingleton.Orders);
            //Capture<Order>(hello);
            int t = 0;
            foreach (var x in hello)
            {
              _orderSingleton.Orders.Insert(t++, x);
            }
            break;

          case 4:
            Console.WriteLine("Purchase");
            double cost = 0;
            //Show price
            foreach (var x in _orderSingleton.Orders)
            {
              cost += x.Product.Price;
               Console.WriteLine(x.Product +" " +x.Product.Price);
            }
            //Store data as purchase 

            //delete all occurences of order
            Console.WriteLine($"Thanks for purchasing! Your cost is $ {cost}");
            _orderSingleton.Orders.Clear();//RemoveAll();


            //  notLoggedout = false;
            break;

          case 5:
            Console.WriteLine("View Past Purchases");
            notLoggedout = false;
            break;

                      case 6:
            Console.WriteLine("Logout Successful!");
            notLoggedout = false;
            break;

          default:

            Console.WriteLine($"Please select a valid Menu Item. {menu_choice + 1} is not an option");
            break;
        }

      }
      //Console.WriteLine(customer); 
      Log.Information("method: Run()");
      // CaptureOutput();
    }



       private static void Output<T>(List<T> data) where T : class
    {
      // verbose
      // debug
      // info
      // warn
      // error
      // fatal

      Log.Information($"method: Output <{typeof(T)}>"); //string interpolation

      var index = 0;
      foreach (var item in data)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }
    //    private static int Capture()
    private static int Capture<T>(List<T> data) where T : class
    {
      Log.Information("method Capture()");

      //Output<Store>(_storeRepository.Stores);
      // Output<Customer>(_customerSingleton.Customers);
      Output<T>(data);

      Console.WriteLine("Make Selection: ");

      int selected = int.Parse(Console.ReadLine());

      return selected - 1;
    }

  }

}
