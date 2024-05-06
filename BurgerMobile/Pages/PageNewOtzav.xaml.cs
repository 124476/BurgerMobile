using BurgerMobile.Models;

namespace BurgerMobile.Pages;

public partial class PageNewOtzav : ContentPage
{
    SQLiteDbContext db;
	public PageNewOtzav()
	{
		InitializeComponent();
        db = new SQLiteDbContext();    
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        if (BText != null)
        {
            Otzav otzav = new Otzav();
            otzav.Text = BText.Text;
            db.AddOtzav(otzav);
            await Navigation.PopAsync();
        }
        else
        {
            DisplayAlert("Ошибка", "Заполните все поля!", "Ок");
        }
    }

    private async void Back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}