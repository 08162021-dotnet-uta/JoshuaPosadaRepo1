using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08162021batchDemoStore;
using DemoStoreBusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Project1.ModelsLayer.EfModels;
using Project1.StoreApplication.Storage.Models;

namespace DemoStoreBusinessLayer
{
	public class CustomerRepository : ICustomerRepository
	{
		// Step1 of DI - create  privatre instance of the dependency
		private readonly Demo_08162021batchContext _context;

		// step 2 of DI - call for an in stance from the DI system in your constructor.
		public CustomerRepository(Demo_08162021batchContext context)
		{
			_context = context;
		}

		/// <summary>
		/// This method will take a ViewModelVustomer object and return the ViewModelCustomer
		/// if found in the Db.
		/// Null if not found.
		/// </summary>
		/// <returns></returns>
		public async Task<ViewModelCustomer> LoginCustomerAsync(ViewModelCustomer vmc)
		{
			Customer c1 = ModelMapper.ViewModelCustomerToCustomer(vmc);

			Customer c2 = await _context.Customers.FromSqlRaw<Customer>("SELECT * FROM Customers WHERE FirstName = {0} and LastName = {1}", c1.FirstName, c1.LastName).FirstOrDefaultAsync();// default is NULL

			if (c2 == null) return null;

			ViewModelCustomer c3 = ModelMapper.CustomerToViewModelCustomer(c2);
			return c3;
		}

		public async Task<ViewModelCustomer> RegisterCustomerAsync(ViewModelCustomer vmc)
		{
			Customer c1 = ModelMapper.ViewModelCustomerToCustomer(vmc);
			

			int c2 = await _context.Database.ExecuteSqlRawAsync("INSERT INTO Customers (FirstName, LastName, Email) VALUES ({0},{1},{2})", c1.FirstName, c1.LastName, c1.Email);// default is NULL

			if (c2 != 1) return null;

			//Customer c3 = _context.Customers.FromSqlRaw<Customer>("SELECT * FROM Customers WHERE FirstName = {0} and LastName = {1}", c1.FirstName, c1.LastName).FirstOrDefault();// default is NULL

			//if (c2 == null) return null;

			//ViewModelCustomer c4 = ModelMapper.CustomerToViewModelCustomer(c3);
			//return c4;

			return await LoginCustomerAsync(vmc);
		}


		public async Task<ViewModelStoreProduct> addtoStoreCartAsync(ViewModelStoreProduct vmc)
		{
			StoresProduct c1 = ModelMapper.ViewModelStoreProductToProduct(vmc);


			int c2 = await _context.Database.ExecuteSqlRawAsync("INSERT INTO StoresProduct(StoreguidId,StoreId,ProductId) VALUES ({0},{1},{2})", Guid.NewGuid(), c1.StoreId, c1.ProductId);// default is NULL

			if (c2 != 1) return null;


			StoresProduct c3 = await _context.StoresProducts.FromSqlRaw<StoresProduct>("SELECT * FROM  StoresProduct WHERE StoreId = {0} and ProductId = {1}", c1.StoreId, c1.StoreProductId).FirstOrDefaultAsync();// default is NULL

			if (c3 == null) return null;

			ViewModelStoreProduct c4 = ModelMapper.ProducttoViewModelStoreProduct(c3);
			return c4;
		}

		public async Task<ViewModelItemizedOrder> addtoItemizedOrderCartAsync(ViewModelItemizedOrder vmc)
		{
			ItemizedOrder c1 = ModelMapper.ViewItemizedOrdertoItemizedOrder(vmc);
			StoresProduct sp = await _context.StoresProducts.FromSqlRaw<StoresProduct>("SELECT MAX(StoreProductId) FROM  StoresProduct ").FirstOrDefaultAsync();// default is NULL

			Guid obj = Guid.NewGuid();
			int c2 = await _context.Database.ExecuteSqlRawAsync("INSERT INTO ItemizedOrders(OrderId, CustomerId, StoreProductId, ProductId, OrderDate) VALUES({ 0}, { 1}, { 2}, { 3}, { 4},{ 5})", obj, c1.CustomerId,sp.StoreProductId,c1.ProductId, c1.OrderDate);// default is NULL


			if (c2 != 1) return null;


			ItemizedOrder c3 = await _context.ItemizedOrders.FromSqlRaw<ItemizedOrder>("SELECT * FROM  ItemizedOrders WHERE CustomerId = {0} and StoreProductId = {1} and OrderId= {2}", c1.CustomerId, c1.StoreProductId, obj).FirstOrDefaultAsync();// default is NULL

			if (c3 == null) return null;

			ViewModelItemizedOrder c4 = ModelMapper.itemizedOrdertoViewmodelItemizedOrder(c3);
			return c4;
		}

		/// <summary>
		/// This method getss a list of all the products or a single product given an arg.
		/// </summary>
		/// <returns></returns>
		public async Task<List<ViewModelProduct>> ProductsAsync(int prodId = -1)
		{
			List<ViewModelProduct> viewmodelproducts = new List<ViewModelProduct>();
			// get all the products
			if (prodId == -1)
			{
				List<Product> products = await _context.Products.FromSqlRaw<Product>("Select * FROM Products").ToListAsync();
				// convert to ViewMOdelProduct
				foreach (Product p in products)
				{
					viewmodelproducts.Add(ModelMapper.ProductToViewModelProduct(p));
				}
				return viewmodelproducts;
			}
			else
			{
				List<Product> products = await _context.Products.FromSqlRaw<Product>($"Select TOP 1 FROM Products WHERE ProductId = {prodId}").ToListAsync();
				// convert to ViewMOdelProduct
				foreach (Product p in products)
				{
					viewmodelproducts.Add(ModelMapper.ProductToViewModelProduct(p));
				}
				return viewmodelproducts;
			}
		}

		public async Task<List<ViewModelCustomer>> CustomerListAsync()
		{
			List<Customer> customers = await _context.Customers.FromSqlRaw<Customer>("Select * FROM Customers").ToListAsync();
			List<ViewModelCustomer> vmc = new List<ViewModelCustomer>();
			foreach (Customer c in customers)
			{
				vmc.Add(ModelMapper.CustomerToViewModelCustomer(c));
			}
			return vmc;
		}
		public async Task<List<ViewModelsStore>> StoreListAsync()
		{
			List<Store> storess = await _context.Stores.FromSqlRaw<Store>("Select * FROM Stores").ToListAsync();
			List<ViewModelsStore> vmc = new List<ViewModelsStore>();
			foreach (Store c in storess)
			{
				vmc.Add(ModelMapper.StoreToViewModelStore(c));
			}

			return vmc;
		}

        public async Task<List<ViewModelProduct>> StoreProductListAsync(ViewModelsStore vmc2)
        {
			Store c1 = ModelMapper.ViewModelsStoreToStore(vmc2);

			List<Product> productss = await _context.Products.FromSqlRaw<Product>($"Select Products.ProductId, ProductName,ProductDescription,ProductPrice,ProductQuantity,ProductPicture from Products Join StoresProduct on Products.ProductId = StoresProduct.ProductId WHERE StoreId={ c1.StoreId}").ToListAsync();///* AND StoreguidId = {Guid.Parse("2F472542-41C7-4F87-A5B3-717AFE821305")

			List<ViewModelProduct> vmc = new List<ViewModelProduct>();
            foreach (Product c in productss)
            {

				vmc.Add(ModelMapper.ProductToViewModelProduct(c));
            }

            return vmc;
        }
		public async Task<List<ViewModelProduct>> getPastOrdersAsync(ViewModelCustomer vmcC,ViewModelsStore vmcS)
		{
			Store c1 = ModelMapper.ViewModelsStoreToStore(vmcS);
			Customer c2 = ModelMapper.ViewModelCustomerToCustomer(vmcC);

			List<Product> productss = await _context.Products.FromSqlRaw<Product>($"Select Products.ProductName, Products.ProductDescription, Products.ProductPrice, Products.ProductQuantity,Products.ProductPicture,Products.ProductId FROM ItemizedOrders Join StoresProduct on ItemizedOrders.ProductId = StoresProduct.ProductId JOIN Stores on Stores.StoreId = StoresProduct.StoreId JOIN Customers on ItemizedOrders.CustomerId=Customers.CustomerId JOIN Products on Products.ProductId=ItemizedOrders.ProductId Where Stores.StoreId= StoresProduct.StoreId AND Stores.StoreId=${vmcS.StoreId} AND Customers.CustomerId=${vmcC.CustomerId}").ToListAsync();
			List<ViewModelProduct> vmc = new List<ViewModelProduct>();
			foreach (Product c in productss)
			{

				vmc.Add(ModelMapper.ProductToViewModelProduct(c));
			}

			return vmc;
		}

		public async Task<List<ViewModelProduct>> getPastOrdersStoreAsync( ViewModelsStore vmcS)
		{
			Store c1 = ModelMapper.ViewModelsStoreToStore(vmcS);
	
			List<Product> productss = await _context.Products.FromSqlRaw<Product>($"Select Products.ProductName, Products.ProductDescription, Products.ProductPrice, Products.ProductQuantity,Products.ProductPicture,Products.ProductId FROM ItemizedOrders Join StoresProduct on ItemizedOrders.ProductId = StoresProduct.ProductId JOIN Stores on Stores.StoreId = StoresProduct.StoreId JOIN Customers on ItemizedOrders.CustomerId=Customers.CustomerId JOIN Products on Products.ProductId=ItemizedOrders.ProductId Where Stores.StoreId= StoresProduct.StoreId AND Stores.StoreId=${vmcS.StoreId}").ToListAsync();
			List<ViewModelProduct> vmc = new List<ViewModelProduct>();
			foreach (Product c in productss)
			{

				vmc.Add(ModelMapper.ProductToViewModelProduct(c));
			}

			return vmc;
		}




	}// EoC
}// EoN
