using NewsAPI.Models;

namespace MauiApp1.Views;

public partial class Details : ContentPage
{
    Article current;

    public Details(Article content)
	{
		InitializeComponent();
        current = content;
        BindingContext = content;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new Web(current.Url));
    }
}