using Microsoft.Maui.Storage;

namespace MauiAppinleveropdracht;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        CheckSavedCredentials();
    }

    private async void CheckSavedCredentials()
    {
        var savedUsername = await SecureStorage.Default.GetAsync("username");
        var savedPassword = await SecureStorage.Default.GetAsync("password");

        if (!string.IsNullOrEmpty(savedUsername) && !string.IsNullOrEmpty(savedPassword))
        {
            using (var db = new SQLite.SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags))
            {
                db.CreateTable<User>();
                var user = db.Table<User>()
                             .FirstOrDefault(u => u.Username == savedUsername && u.Password == savedPassword);

                if (user != null)
                {
                    App.CurrentUserName = user.Username;

                    await Navigation.PushAsync(new Spelmenu(App.CurrentUserName));
                }
            }
        }
    }

    private async void LogInButton_Clicked(object sender, EventArgs e)
    {
        bool isUsernameEmpty = string.IsNullOrEmpty(UsernameEntry.Text);
        bool isPasswordEmpty = string.IsNullOrEmpty(PasswordEntry.Text);

        if (isUsernameEmpty || isPasswordEmpty)
        {
            await DisplayAlert("Fout", "Vul alle velden in.", "OK");
            return;
        }

        using (var db = new SQLite.SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags))
        {
            db.CreateTable<User>();
            var user = db.Table<User>()
                         .FirstOrDefault(u => u.Username == UsernameEntry.Text && u.Password == PasswordEntry.Text);

            if (user != null)
            {
                App.CurrentUserName = user.Username;

                await SecureStorage.Default.SetAsync("username", UsernameEntry.Text);
                await SecureStorage.Default.SetAsync("password", PasswordEntry.Text);

                await Navigation.PushAsync(new Spelmenu(App.CurrentUserName));
            }
            else
            {
                await DisplayAlert("Fout", "Ongeldige gebruikersnaam of wachtwoord.", "OK");
            }
        }
    }

    private async void RegisterButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
}
