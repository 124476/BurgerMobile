using BurgerMobile.Models;

namespace BurgerMobile.Pages;

public partial class PageNewBurger : ContentPage
{
	public PageNewBurger()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		if (BTitle.Text != null && BDescription.Text != null)
		{
			Burger burger = new Burger();
			burger.Title = BTitle.Text;
			burger.Description = BDescription.Text;
			//burger.Photo = ImageSource.FromFile()
			await Navigation.PopAsync();
		}
		else
		{
			DisplayAlert("Ошибка", "Заполните все поля!", "Ок");
		}
    }
}