using MauiApp1.Controllers;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace MauiApp1.Views;

public partial class Main : ContentPage
{
	public Main()
	{
		InitializeComponent();
        loaddata();

    }

	async void loaddata()
	{
        loading.IsRunning = true;
        var source = new List<Article>();
        var result = await NewsController.Get().ConfigureAwait(true);
        if (result != null)
        {
            foreach (var item in result)
            {
                try
                {
                    source.Add(item);
                }
                catch
                {}
            }
        }
        coll.ItemsSource = source;
        loading.IsRunning = false;
    }

    void CollectionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		var data = e.CurrentSelection.FirstOrDefault() as Article;
		Navigation.PushAsync(new Details(data));
}
}