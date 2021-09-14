//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DemoStoreDbContext;
//using DemoStoreDbContext.Models;
//using Microsoft.EntityFrameworkCore;

//namespace _08162021batchDemoStore
//{
//    public partial class Customerm
//    {
//        public Customerm()
//        {
//            using (Demo_08162021batchContext context = new Demo_08162021batchContext())
//            {
//                ItemizedOrders = context.ItemizedOrders.FromSqlRaw<ItemizedOrder>("SELECT * FROM ItemizedOrder").ToList();
//            }
//            //ItemizedOrders = new HashSet<ItemizedOrder>();
//        }

//        public int CustomerId { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public string Email { get; set; }
//        public string PasswordH { get; set; }

//        public virtual ICollection<ItemizedOrder> ItemizedOrders
//        {
//            get;
//            set;
//        }

//    }
//}


