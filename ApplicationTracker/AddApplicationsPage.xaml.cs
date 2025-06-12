namespace ApplicationTracker;
using ApplicationTracker.Data;

public partial class AddApplicationsPage : ContentPage
{
    DatabaseHelper database;

    public AddApplicationsPage()
    {
        InitializeComponent();
        
    }

    // 2. Make the event handler async so we can use 'await'.
    private async void AddApplicationButtonPressed(object sender, EventArgs e)
    {
  
        database = new DatabaseHelper();

        // Basic validation to prevent crashing on empty entries
        if (string.IsNullOrWhiteSpace(companyName.Text) ||
            string.IsNullOrWhiteSpace(role.Text))
        {
            await DisplayAlert("Error", "Company Name and Role are required.", "OK");
            return;
        }

        JobApplication jobApplication = new JobApplication
        {
            CompanyName = companyName.Text,
            Salary = salary.Text,
            Location = location.Text,
            Role = role.Text,
            Status = 0 //default for newly applied
        };

        await database.AddJobApplicationAsync(jobApplication);

        // Give user feedback and clear the form
        await DisplayAlert("Success", "Application Saved!", "OK");

        companyName.Text = string.Empty;
        salary.Text = string.Empty;
        location.Text = string.Empty;
        role.Text = string.Empty;
    }
}