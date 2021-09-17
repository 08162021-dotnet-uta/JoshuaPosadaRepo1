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

			List<Product> productss = await _context.Products.FromSqlRaw<Product>($"Select Products.ProductId, ProductName,ProductDescription,ProductPrice,ProductQuantity,ProductPicture from Products Join StoresProduct on Products.ProductId = StoresProduct.ProductId WHERE StoreId={ c1.StoreId}").ToListAsync();
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

			List<Product> productss = await _context.Products.FromSqlRaw<Product>($"Select ProductName, ProductDescription, ProductPrice, ProductQuantity, Customers.FirstName FROM ItemizedOrders Join StoresProduct on ItemizedOrders.ProductId = StoresProduct.ProductId JOIN Stores on Stores.StoreId = StoresProduct.StoreId JOIN Customers on ItemizedOrders.CustomerId=Customers.CustomerId JOIN Products on Products.ProductId=ItemizedOrders.ProductId Where Stores.StoreId= StoresProduct.StoreId AND Stores.StoreId=${vmcS.StoreId} AND Customers.CustomerId=${vmcC.CustomerId}").ToListAsync();
			List<ViewModelProduct> vmc = new List<ViewModelProduct>();
			foreach (Product c in productss)
			{

				vmc.Add(ModelMapper.ProductToViewModelProduct(c));
			}

			return vmc;
		}



	


	}// EoC
}// EoN
