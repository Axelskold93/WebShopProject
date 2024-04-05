using WebShopProject.Models;

namespace WebShopProject.Data
{
	public class SampleData
	{
		public static void CreateAccount(AppDbContext database)
		{
			// If there are no fake accounts, add some.
			string fakeIssuer = "https://example.com";
			if (!database.Accounts.Any(a => a.OpenIDIssuer == fakeIssuer))
			{
				database.Accounts.Add(new Account
				{
					OpenIDIssuer = fakeIssuer,
					OpenIDSubject = "1111111111",
					Name = "Brad"
				});
				database.Accounts.Add(new Account
				{
					OpenIDIssuer = fakeIssuer,
					OpenIDSubject = "2222222222",
					Name = "Angelina"
				});
				database.Accounts.Add(new Account
				{
					OpenIDIssuer = fakeIssuer,
					OpenIDSubject = "3333333333",
					Name = "Will"
				});
			}

			database.SaveChanges();
		}
		public static void CreateProducts(AppDbContext database)
		{
			if(!database.Products.Any())
			{
				database.Products.Add(new Product
				{
					Name = "Krislåda",
					Description = "En fin låda som du kan plocka fram ifall det krisar.(Kan innehålla spår av nötter.)",
					Price = 2999,
					ImagePath = "plastlåda.jpg"

                });
				database.Products.Add(new Product
				{
					Name = "Tält",
					Description = "Ett rymligt enmanna tält",
					Price = 3499,
					ImagePath = "smalltent.jpg"
				});
			}
			database.SaveChanges();
		}
	}
}
