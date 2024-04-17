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
			if (!database.Products.Any())
			{
				database.Products.Add(new Product
				{
					Name = "Krislåda",
					Description = "En fin låda som du kan plocka fram ifall det krisar.(Kan innehålla spår av nötter.)",
					Price = 2999,
					Category = "Verktyg och utrustning",
					ImagePath = "plastlåda.png"

				});
				database.Products.Add(new Product
				{
					Name = "Tält",
					Description = "Ett rymligt enmanna tält",
					Price = 3499,
					Category = "Camping",
					ImagePath = "smalltent.png"
				});

				database.Products.Add(new Product
				{
					Name = "Vattenfilter",
					Description = "Filter för att rena vatten från föroreningar.",
					Price = 299,
					Category = "Vattenrening",
					ImagePath = "water_filter.png"
				});

				database.Products.Add(new Product
				{
					Name = "Nödmatpaket (7 dagar)",
					Description = "Nödpaket med mat för en vecka.",
					Price = 899,
					Category = "Matförvaring",
					ImagePath = "emergency_food.png"
				});

				database.Products.Add(new Product
				{
					Name = "Första hjälpen-kit",
					Description = "Ett komplett första hjälpen-kit för nödsituationer.",
					Price = 199,
					Category = "Första hjälpen",
					ImagePath = "first_aid_kit.png"
				});

				database.Products.Add(new Product
				{
					Name = "Multiverktyg",
					Description = "Ett multifunktionellt verktyg för olika ändamål.",
					Price = 149,
					Category = "Verktyg och utrustning",
					ImagePath = "multi_tool.png"
				});

				database.Products.Add(new Product
				{
					Name = "Campingkök",
					Description = "Ett portabelt campingkök med gasbrännare.",
					Price = 399,
					Category = "Matlagning",
					ImagePath = "camp_stove.png"
				});

				database.Products.Add(new Product
				{
					Name = "Brandfilt",
					Description = "En brandfilt för att släcka mindre bränder.",
					Price = 79,
					Category = "Brandsäkerhet",
					ImagePath = "fire_blanket.png"
				});

				database.Products.Add(new Product
				{
					Name = "LED-ficklampa",
					Description = "En ficklampa som laddas med hjälp av en inbyggd dynamo.",
					Price = 129,
					Category = "Belysning",
					ImagePath = "dynamo_flashlight.png"
				});

				database.Products.Add(new Product
				{
					Name = "Fällkniv",
					Description = "En mångsidig kniv med vikbart blad för enkel transport.",
					Price = 249,
					Category = "Verktyg och utrustning",
					ImagePath = "folding_knife.png"
				});

				database.Products.Add(new Product
				{
					Name = "Solcellsdriven laddare",
					Description = "En bärbar laddare som drivs av solenergi.",
					Price = 199,
					Category = "Elektronik",
					ImagePath = "solar_charger.png"
				});

				database.Products.Add(new Product
				{
					Name = "Portabel toalett",
					Description = "En portabel toalett för användning utomhus",
					Price = 499,
					Category = "Hygien",
					ImagePath = "portable_toilet.png"
				});

				database.Products.Add(new Product
				{
					Name = "Handvevad radio",
					Description = "En radio som drivs av manuell vevarbete för strömförsörjning.",
					Price = 299,
					Category = "Kommunikation",
					ImagePath = "hand_crank_radio.png"
				});

				database.Products.Add(new Product
				{
					Name = "Överlevnadshandbok",
					Description = "En guidebok med överlevnadstekniker och tips för nödsituationer.",
					Price = 99,
					Category = "Utbildning och litteratur",
					ImagePath = "survival_guide.jpg"
				});

				database.Products.Add(new Product
				{
					Name = "Värmeljus",
					Description = "Värmeljus för långvarig belysning upp till 36 timmars brinntid.",
					Price = 49,
					Category = "Belysning",
					ImagePath = "long_lasting_candles.png"
				});

				database.Products.Add(new Product
				{
					Name = "Tält för nödsituationer",
					Description = "Ett lätt och portabelt tält för nödsituationer.",
					Price = 199,
					Category = "Skydd och boende",
					ImagePath = "emergency_tent.png"
				});

				database.Products.Add(new Product
				{
					Name = "Paracord (30 meter)",
					Description = "En robust och mångsidig nylontråd för olika ändamål.",
					Price = 69,
					Category = "Rep och snöre",
					ImagePath = "paracord.png"
				});

				database.Products.Add(new Product
				{
					Name = "Nödsignalvisselpipa",
					Description = "En visselpipa med hög ljudstyrka för att signalera nödsituationer.",
					Price = 29,
					Category = "Säkerhet och signalering",
					ImagePath = "emergency_whistle.png"
				});

				database.Products.Add(new Product
				{
					Name = "Solcellslampa",
					Description = "En bärbar lampa med solcellsdrift för användning vid strömavbrott.",
					Price = 149,
					Category = "Belysning",
					ImagePath = "solar_lamp.png"
				});

				database.Products.Add(new Product
				{
					Name = "Överlevnadsskovel",
					Description = "En hopfällbar skovel som kan användas för olika ändamål under nödsituationer.",
					Price = 129,
					Category = "Verktyg och utrustning",
					ImagePath = "survival_shovel.png"
				});

				database.Products.Add(new Product
				{
					Name = "Konservöppnare",
					Description = "En manuell konservöppnare för öppning av burkar under strömavbrott.",
					Price = 39,
					Category = "Matlagning",
					ImagePath = "can_opener.png"
				});

				database.Products.Add(new Product
				{
					Name = "Färdiga måltider",
					Description = "Färdiga måltider som värms upp av kemisk reaktion.",
					Price = 149,
					Category = "Matlagning",
					ImagePath = "self_heating_meals.jpg"
				});

				database.Products.Add(new Product
				{
					Name = "Myggmedel (spray)",
					Description = "En effektiv insektsrepellent för att skydda mot myggor och andra insekter.",
					Price = 59,
					Category = "Hygien",
					ImagePath = "insect_repellent.png"
				});

				database.Products.Add(new Product
				{
					Name = "Värmefilt",
					Description = "En värmande filt för att hålla värmen under kalla förhållanden.",
					Price = 199,
					Category = "Värme och isolering",
					ImagePath = "emergency_blanket.png"
				});

				database.Products.Add(new Product
				{
					Name = "Nödsignalreflektorer",
					Description = "Reflekterande signaler för att öka synligheten vid nödsituationer. 4-pack.",
					Price = 99,
					Category = "Säkerhet och signalering",
					ImagePath = "emergency_reflectors.png"
				});

				database.Products.Add(new Product
				{
					Name = "Solskyddskräm (SPF 50)",
					Description = "En högeffektiv solskyddskräm för att skydda mot solens skadliga strålar.",
					Price = 89,
					Category = "Hygien",
					ImagePath = "sunscreen.png"
				});

				database.Products.Add(new Product
				{
					Name = "Ryggsäck",
					Description = "En mångsidig väska för att bära nödvändiga tillbehör och utrustning.",
					Price = 179,
					Category = "Förvaring och transport",
					ImagePath = "multi_function_bag.png"
				});

				database.Products.Add(new Product
				{
					Name = "Räddningsfilt",
					Description = "En stor och isolerande filt för att skydda mot kyla och väder.",
					Price = 69,
					Category = "Värme och isolering",
					ImagePath = "rescue_blanket.png"
				});

				database.Products.Add(new Product
				{
					Name = "Överlevnadsväst",
					Description = "En flytväst med extra funktioner för överlevnad i vatten.",
					Price = 299,
					Category = "Personlig skyddsutrustning",
					ImagePath = "survival_vest.png"
				});

				database.Products.Add(new Product
				{
					Name = "Tändstål",
					Description = "Ett tändstål för att skapa gnistor för tändning av eld.",
					Price = 59,
					Category = "Eld och tändning",
					ImagePath = "fire_starter.png"
				});

			}
			database.SaveChanges();
		}
	}
}
