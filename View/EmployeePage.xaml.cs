using Module02Exercise01.ViewModel;
namespace Module02Exercise01.View;

public partial class EmployeePage : ContentPage
{
	public EmployeePage()
	{
		InitializeComponent();
        BindingContext = new EmployeeViewModel();
    }
    private async void OnAddEmployeeClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddEmployee());
    }
}