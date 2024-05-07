using BurgerMobile.Models;

namespace BurgerMobile.Pages;

public partial class PageNewOtzav : ContentPage
{
    SQLiteDbContext db;
    int contextButton;
	public PageNewOtzav()
	{
		InitializeComponent();
        db = new SQLiteDbContext();
        contextButton = 0;
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        
        if (BText.Text != null && contextButton != 0)
        {
            Otzav otzav = new Otzav();
            otzav.Text = BText.Text;
            otzav.Kol = contextButton;
            await db.AddOtzav(otzav);
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Ошибка", "Заполните все поля!", "Ок");
        }
    }

    private async void Back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void ButtonOne_Clicked(object sender, EventArgs e)
    {
        contextButton = 1;
        Refresh();
    }

    private void Refresh()
    {
        if (contextButton >= 1)
        {
            ButtonOne.Source = "zvezdayes.png";
        }
        else
        {
            ButtonOne.Source = "zvezdano.png";
        }
        if (contextButton >= 2)
        {
            ButtonTwo.Source = "zvezdayes.png";
        }
        else
        {
            ButtonTwo.Source = "zvezdano.png";
        }
        if (contextButton >= 3)
        {
            ButtonTree.Source = "zvezdayes.png";
        }
        else
        {
            ButtonTree.Source = "zvezdano.png";
        }
        if (contextButton >= 4)
        {
            ButtonFour.Source = "zvezdayes.png";
        }
        else
        {
            ButtonFour.Source = "zvezdano.png";
        }
        if (contextButton >= 5)
        {
            ButtonFive.Source = "zvezdayes.png";
        }
        else
        {
            ButtonFive.Source = "zvezdano.png";
        }
    }

    private void ButtonTwo_Clicked(object sender, EventArgs e)
    {
        contextButton = 2;
        Refresh();
    }

    private void ButtonTree_Clicked(object sender, EventArgs e)
    {
        contextButton = 3;
        Refresh();
    }

    private void ButtonFour_Clicked(object sender, EventArgs e)
    {
        contextButton = 4;
        Refresh();
    }

    private void ButtonFive_Clicked(object sender, EventArgs e)
    {
        contextButton = 5;
        Refresh();
    }
}