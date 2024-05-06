using BurgerMobile.Models;

namespace BurgerMobile.Pages;

public partial class PageNewCombo : ContentPage
{
	public PageNewCombo()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		if (BTitle.Text != null)
		{
			BurgerCombo burgerCombo = new BurgerCombo();
			burgerCombo.Title = BTitle.Text;

		}
		else
		{
			DisplayAlert("Ошибка", "Заполните все поля!", "Ок");
		}
    }
}