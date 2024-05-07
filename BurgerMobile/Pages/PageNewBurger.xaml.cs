using BurgerMobile.Models;
using System.IO;

namespace BurgerMobile.Pages;

public partial class PageNewBurger : ContentPage
{
	Burger contextBurger;
	SQLiteDbContext db;
    public PageNewBurger(Burger burger)
	{
		InitializeComponent();
		db = new SQLiteDbContext();
        if (burger != null)
        {
            contextBurger = burger;
            BTitle.Text = contextBurger.Title;
            BSum.Text = contextBurger.Sum;
            BDescription.Text = contextBurger.Description;
            BPhoto.Source = contextBurger.BPhoto;
            Del.IsVisible = true;
        }
        else
        {
            contextBurger = new Burger();
            Del.IsVisible = false;
        }
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		if (BTitle.Text != null && BDescription.Text != null && BSum.Text != null && contextBurger.Photo != null)
		{
            contextBurger.Title = BTitle.Text;
            contextBurger.Description = BDescription.Text;
            contextBurger.Sum = BSum.Text;
            await db.AddBurgersAsyns(contextBurger);
			await Navigation.PopAsync();
		}
		else
		{
			DisplayAlert("Ошибка", "Заполните все поля!", "Ок");
		}
    }

    private async void GotPhoto_Clicked(object sender, EventArgs e)
    {
        var mediaFile = await MediaPicker.PickPhotoAsync();

        if (mediaFile != null)
        {
            using (var stream = await mediaFile.OpenReadAsync())
            {
                using (var memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    contextBurger.Photo = imageBytes;
                    BPhoto.Source = contextBurger.BPhoto;
                }
            }
        }
    }
    private async void Back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void Del_Clicked(object sender, EventArgs e)
    {
        foreach(var item in (await db.GetAllComboAndBurgers()).Where(x => x.BurgerId == contextBurger.Id))
        {
            await db.DeleteComboAndBurger(item);
        }
        await db.DeleteBurgerAsyns(contextBurger);
        await Navigation.PopAsync();
    }
}