namespace Module02Exercise01.View;
public partial class AddEmployee : ContentPage
{
	public AddEmployee()
	{
		InitializeComponent();
	}
        private async void OnGetLocationClicked(object sender, System.EventArgs e)
    {
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.High
                });
            }

            if (location != null)
            {
                CoordinatesLabel.Text = $"Latitude: {location.Latitude}, Longtitude: {location.Longitude}";

                //Get Geocoding - Get address from latitude and longitude

                var placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);

                var placemark = placemarks?.FirstOrDefault();

                if (placemark != null)
                {
                    MunicipalityEntry.Text = $"{placemark.Locality}";
                    ProvinceEntry.Text = $"{placemark.AdminArea}";
                }
                else
                {
                    MunicipalityEntry.Text = "Unable to determine municipality";
                    ProvinceEntry.Text = "Unable to determine province";
                }
            }
            else
            {
                CoordinatesLabel.Text = $"Unable to get location";
            }
        }
        catch (Exception ex)
        {
            CoordinatesLabel.Text = $"Error:{ex.Message}";
        }
    }

    private async void OnTakePhotoClicked(object sender, EventArgs e)
    {
        try
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                //Capture a photo using MediaPicker
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo != null)
                {
                    await LoadPhotoAsync(photo);
                }
            }

            else
            {

            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occured: {ex.Message}", "OK");
        }

    }
    private async Task LoadPhotoAsync(FileResult photo)
    {
        if (photo == null)
            return;

        Stream stream = await photo.OpenReadAsync();
        CaptureImage.Source = ImageSource.FromStream(() => stream);
    }
}