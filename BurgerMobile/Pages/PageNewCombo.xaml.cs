using BurgerMobile.Models;

namespace BurgerMobile.Pages;

public partial class PageNewCombo : ContentPage
{
	SQLiteDbContext db;
	List<Burger> burgers;
    BCombo contextCombo;
	public PageNewCombo(BCombo burgerCombo)
	{
		InitializeComponent();
		db = new SQLiteDbContext();
        contextCombo = burgerCombo;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		if (BTitle.Text != null && BSum.Text != null)
		{
			BCombo burgerCombo = new BCombo();
            if (contextCombo != null)
            {
                burgerCombo = contextCombo;
            }
			burgerCombo.Title = BTitle.Text;
            burgerCombo.Sum = BSum.Text;
            if (contextCombo != null)
            {
                burgerCombo.Id = contextCombo.Id;
            }
            await db.AddCombo(burgerCombo);


            foreach (var item in (await db.GetAllComboAndBurgers()).Where(x => x.ComboId == burgerCombo.Id))
            {
                await db.DeleteComboAndBurger(item);
            }

            foreach (var item in burgers)
            {
                ComboAndBurger comboAndBurger = new ComboAndBurger();
                comboAndBurger.BurgerId = item.Id;
                comboAndBurger.ComboId = burgerCombo.Id;
                await db.AddComboAndBurger(comboAndBurger);
            }
			await Navigation.PopAsync();
        }
		else
		{
			DisplayAlert("Ошибка", "Заполните все поля!", "Ок");
		}
    }

    private void ListBurgers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ListBurgers.SelectedItem != null)
        {
            Burger burger = ListBurgers.SelectedItem as Burger;
            burgers.Remove(burger);
            Refresh();
        }
    }

    private void Refresh()
    {
        ListBurgers.ItemsSource = null;
        ListBurgers.ItemsSource = burgers;
        ComboBurgers.SelectedIndex = -1;
    }

    private void ComboBurgers_SelectedIndexChanged(object sender, EventArgs e)
    {
		if (ComboBurgers.SelectedIndex != -1)
        {
            Burger burger = ComboBurgers.SelectedItem as Burger;
            foreach(var item in burgers.Where(x => x.Id == burger.Id).ToList())
                burgers.Remove(item);
            burgers.Add(burger);
            Refresh();
        }
    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        burgers = new List<Burger>();
        if (contextCombo != null)
        {
            var bugIds = (await db.GetAllComboAndBurgers()).Where(x => x.ComboId == contextCombo.Id).Select(x => x.BurgerId);
            foreach (var bugId in bugIds)
            {
                burgers.Add((await db.GetAllBurgers()).FirstOrDefault(x => x.Id == bugId));
            }
            BTitle.Text = contextCombo.Title;
            BSum.Text = contextCombo.Sum;
            Refresh();
        }
        ComboBurgers.ItemsSource = await db.GetAllBurgers();
    }

    private async void Back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}