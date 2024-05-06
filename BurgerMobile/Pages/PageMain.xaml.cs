using BurgerMobile.Models;

namespace BurgerMobile.Pages;

public partial class PageMain : ContentPage
{
	SQLiteDbContext db;
	public PageMain()
	{
		InitializeComponent();
		db = new SQLiteDbContext();

    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
		Burger burger = (await db.GetAllBurgers()).FirstOrDefault();

        if (burger != null)
		{
			BindingContext = burger;
		}
    }
}