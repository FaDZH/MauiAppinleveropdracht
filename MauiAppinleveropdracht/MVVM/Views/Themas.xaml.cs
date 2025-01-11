namespace MauiAppinleveropdracht;

public partial class Themas : ContentPage
{
    public TaskCompletionSource<string> ThemeSelectionTask { get; private set; } = new TaskCompletionSource<string>();

    public Themas()
    {
        InitializeComponent();
    }

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        // hier krijgt die de tekst van eengeklikte blokje waar in het thema staat
        var button = sender as Button;
        string selectedTheme = button?.Text ?? "Geen thema";

        // stelt het waarde in op het taskcompletionsource
        ThemeSelectionTask.SetResult(selectedTheme);

        await Navigation.PopAsync();
    }
}
