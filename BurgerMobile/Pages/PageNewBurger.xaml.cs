using BurgerMobile.Models;

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
        }
        else
        {
            contextBurger = new Burger();
        }
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		if (BTitle.Text != null && BDescription.Text != null && BSum.Text != null)
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
                    //await stream.CopyToAsync(memoryStream);
                    //byte[] imageBytes = memoryStream.ToArray();
                    //burger.BPhoto = ImageSource.FromStream(() => new MemoryStream(imageBytes));
                    //burger.Photo = imageBytes.ToString();
                    //BPhoto.Source = burger.BPhoto;
                }
            }
        }
    }
    private async void Back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}