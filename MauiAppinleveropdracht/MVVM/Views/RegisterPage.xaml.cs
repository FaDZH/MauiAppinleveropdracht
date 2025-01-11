namespace MauiAppinleveropdracht
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
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

                //hier kijkt die of user al bestaat
                var existingUser = db.Table<User>().FirstOrDefault(u => u.Username == UsernameEntry.Text);

                if (existingUser != null)
                {
                    await DisplayAlert("Fout", "Gebruikersnaam bestaat al.", "OK");
                    return;
                }

                //hier voegt die nieuwe user toe 
                var newUser = new User
                {
                    Username = UsernameEntry.Text,
                    Password = PasswordEntry.Text
                };
                db.Insert(newUser);

                await DisplayAlert("Succes", "Account aangemaakt. Je kunt nu inloggen.", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
