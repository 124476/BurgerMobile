namespace BurgerMobile.Pages;

public partial class PageOtzav : ContentPage
{
	SQLiteDbContext db;
	public PageOtzav()
	{
		InitializeComponent();
		db = new SQLiteDbContext();
	}

    private async void NewOtzav_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PageNewOtzav());
    }

    private async void ContentPage_Appearing(object sender, EventArgs e)
    {
        ListOtzas.ItemsSource = await db.GetAllOtzav();
    }
}