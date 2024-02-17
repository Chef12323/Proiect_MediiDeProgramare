using maciuca.Model;
namespace maciuca;

public partial class CharacterPage : ContentPage
{
    maciuca anc;
	public CharacterPage(maciuca maciucac)
	{
		InitializeComponent();
        anc = maciucac;
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var character = (Character)BindingContext;
        await App.Database.SaveCharacterAsync(character);
        CharacterlistView.ItemsSource = await App.Database.GetCharacterAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var character = (Character)BindingContext;
        await App.Database.DeleteCharacterAsync(character);
        CharacterlistView.ItemsSource = await App.Database.GetCharacterAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CharacterlistView.ItemsSource = await App.Database.GetCharacterAsync();
    }


    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Character p;
        if (CharacterlistView.SelectedItem != null)
        {
            p = CharacterlistView.SelectedItem as Character;
            var lp = new ListCharacter()
            {
                maciucaId = anc.Id,
                CharacterId = p.Id
            };
            await App.Database.SaveListCharacterAsync(lp);
            p.ListCharacters = new List<ListCharacter> { lp };
            await Navigation.PopAsync();
        }

    }
}