﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08162021batchDemoStore;
using Project1.ModelsLayer.EfModels;

namespace DemoStoreBusinessLayer.Interfaces
{
	public interface IModelMapper
	{
		ViewModelCustomer CustomerToViewModelCustomer(Customer c) { throw new NotImplementedException(); }
		Customer ViewModelCustomerToCustomer(ViewModelCustomer c) { throw new NotImplementedException(); }
		Product ViewModelProductToProduct(ViewModelProduct c) { throw new NotImplementedException(); }
		Store ViewModelStoreToStore (ViewModelsStore c) { throw new NotImplementedException(); }
		ViewModelProduct ProductToViewModelProduct(Product c) { throw new NotImplementedException(); }
	}
}
