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
    static List<string> MainMenu = new List<string>() { "Pick a Store", "View Cart", "Add", "Delete", "Purchase", "View Past Orders", "Logout", "View Store Orders" };
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

    /// <summary>
    /// Lets User choose through a menu and performs method for each fo the following
    /// "Pick a Store", "View Cart", "Add", "Delete", "Purchase", "View Past Orders", "Logout", "View Store Orders" 
    /// </summary>
    private static void Run()
    {
      //customers
      if (_customerSingleton.Customers.Count == 0)
      {
        _customerSingleton.Add(new Customer());
      }
      var customer = _customerSingleton.Customers[Capture<Customer>(_customerSingleton.Customers)];

      //Menu Elements
      int menu_choice;
      bool notLoggedout = true;


      while (notLoggedout)
      {
        menu_choice = Capture<string>(MainMenu);

        switch (menu_choice)
        {
          case 0:
            Log.Information("switch Case Store/Product/Orders");
            //stores
            var store = _storeSingleton.Stores[Capture<Store>(_storeSingleton.Stores)];

            //products
            if (_productSingleton.allProducts.Count == 0)
            {
              _productSingleton.Add(new Product());
            }
            _productSingleton.setStore(store);
            var product = _productSingleton.Products[Capture<Product>(_productSingleton.Products)];

            //Orders
            _orderSingleton.Add(new Order() { Customer = customer, Product = product, Store = store });
            break;

          case 1:
            Log.Information("switch Case Cart");
            Console.WriteLine("***CART***");
            Output<Order>(_orderSingleton.Orders);
            Console.WriteLine("***END CART***");
            break;

          case 2:
            Log.Information("switch Case Edit:Add Item To cart");
            Console.WriteLine("Add");
            _orderSingleton.Add(_orderSingleton.Orders[Capture<Order>(_orderSingleton.Orders)]);
            break;

          case 3:
            Log.Information("switch Case Delete Item");
            Console.WriteLine("Delete");
            _orderSingleton.Orders.RemoveAt(Capture<Order>(_orderSingleton.Orders));
            break;

          case 4:
            Log.Information("switch Case Purchase");
            Console.WriteLine("Purchase");
            //Shows Price
            if (_orderSingleton.Orders.Count > 0)
              _orderSingleton.Orders[0].pastOrders(_orderSingleton.Orders);

            foreach (var x in _orderSingleton.Orders)
            {
              Log.Information("Purchase: Add Customer Order");
              customer.Orders.Add(x);
              _customerSingleton.Add(customer);

              for (int i = 0; i < _storeSingleton.Stores.Count; i++)
              {
                if (x.Store.Name.Equals(_storeSingleton.Stores[i].Name))
                {
                  Log.Information("Purchase: Add Store Order");
                  _storeSingleton.Stores[i].AddOrder(x);
                  //_storeSingleton.Add(x.Store);
                }
              }
              Console.WriteLine(x.Product);
            }
            _orderSingleton.Delete();

            break;

          case 5:
            Log.Information("switch Case View Past Purchases");
            Console.WriteLine("View Past Purchases");
            if (customer.Orders.Count > 0)
              Console.WriteLine(customer.Orders[0].pastOrders(customer.Orders));
            break;

          case 6:
            Log.Information("Logout");
            Console.WriteLine("Logout Successful!");
            notLoggedout = false;
            break;

          case 7:
            Log.Information("switch Case View Store Orders");
            Console.WriteLine("View Store Orders");
            var store2 = _storeSingleton.Stores[Capture<Store>(_storeSingleton.Stores)];
            Output<Order>(store2.Orders);
            break;

          default:
            Log.Information($"switch Case Default {menu_choice + 1} is not an option");
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
