using BilgeCinema.MVC.Models;

namespace BilgeCinema.MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			// appsettings.json kullanýmý için : 

			var settings = builder.Configuration.GetSection("Appsettings").Get<AppSettings>();

			builder.Services.AddHttpClient();// Client nesnesine api ye json foýrmatýnda istek atmak için ihtiyacým var 

			builder.Services.AddSingleton(settings);
			// addsingleton -> yukarýdaki AppSetting class'ýný newlenip oluþturduðu nesneden tek bir kopya olacak ve hep ayný kopya (instance) kullanýlacak.

			// addscoped -> Her sitek yeni kopya.

			// burada neden addSingleton kullanýyoruz da AddScopped kullanmýyoruz? 
			// Belge almak için gerekli soru - Cevabý Öðren 




			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Movie}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
