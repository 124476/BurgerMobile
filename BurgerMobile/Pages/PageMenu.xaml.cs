using BurgerMobile.Models;

namespace BurgerMobile.Pages;

public partial class PageMenu : ContentPage
{
    SQLiteDbContext db;
	public PageMenu()
	{
		InitializeComponent();
        db = new SQLiteDbContext();
    }

    private async void NewBurger_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new PageNewBurger(null));
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        Refresh();
    }

    private async void Refresh()
    {
        ListBurgers.ItemsSource = await db.GetAllBurgers();
    }

    private async void ListBurgers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ListBurgers.SelectedItem != null)
        {
            await Navigation.PushAsync(new PageNewBurger(ListBurgers.SelectedItem as Burger));
        }
    }
}