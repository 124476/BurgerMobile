using BurgerMobile.Models;

namespace BurgerMobile.Pages;

public partial class PageCombo : ContentPage
{
    SQLiteDbContext db;
	public PageCombo()
	{
		InitializeComponent();
        db = new SQLiteDbContext();
	}

    private async void NewCombo_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PageNewCombo(null));
    }

    private async void Refresh()
    {
        var combos = await db.GetAllCombos();

        ListBurgerCombo.ItemsSource = combos;
    }

    private async void ListBurgerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ListBurgerCombo.SelectedItem != null)
        {
            await Navigation.PushAsync(new PageNewCombo(ListBurgerCombo.SelectedItem as BCombo));
        }
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        Refresh();
    }
}