namespace BurgerMobile.Pages;

public partial class PageMenu : ContentPage
{
	public PageMenu()
	{
		InitializeComponent();
	}

    private async void NewBurger_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new PageNewBurger());
    }
}