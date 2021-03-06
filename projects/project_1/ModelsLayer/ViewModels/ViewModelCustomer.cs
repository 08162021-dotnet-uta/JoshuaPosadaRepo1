using System.ComponentModel.DataAnnotations;

namespace _08162021batchDemoStore
{
	public class ViewModelCustomer
	{
		private string fname;

		[StringLength(20, MinimumLength = 1)]
		public string Fname
		{
			get
			{
				return this.fname;
			}
			set
			{
				if (value.Length > 50 || value.Length == 0)
				{
					this.fname = "invalid Name Input";
				}
				else
				{
					this.fname = value;
				}
			}
		}
		public string Lname { get; set; }
		public string Email { get; set; }
		public string PasswordH { get; set; }

		public int CustomerId { get; set; }


		public ViewModelCustomer() { }

		public ViewModelCustomer(string fname, string lname)
		{
			this.Fname = fname;
			this.Lname = lname;
		}

		public ViewModelCustomer(string fname, string lname,string email,string passwordh)
		{
			this.Fname = fname;
			this.Lname = lname;
			Email = email;
			PasswordH = passwordh;
		}
		public ViewModelCustomer(int customerId,string fname, string lname, string email, string passwordh)
		{
			this.CustomerId = customerId;
			this.Fname = fname;
			this.Lname = lname;
			Email = email;
			PasswordH = passwordh;
		}


	}//EoC
}//EoN