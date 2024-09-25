namespace Module02Exercise01.View;
using Microsoft.Maui.Controls;
using Module02Exercise01.Services;

public partial class LoginPage : ContentPage
{
    private readonly IMyService _myService;

    public LoginPage(IMyService myService)
    {
        InitializeComponent();
        _myService = myService;

        var message = _myService.GetMessage();
        MyLabel.Text = message;
    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//EmployeePage");
    }
}