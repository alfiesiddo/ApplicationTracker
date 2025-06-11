namespace ApplicationTracker;
using ApplicationTracker.Data;

public partial class AddApplicationsPage : ContentPage
{
	DatabaseHelper Database = new DatabaseHelper();
	public AddApplicationsPage()
	{
		InitializeComponent();
	}
    private  void AddApplicationButtonPressed(object sender, EventArgs e)
    {
        JobApplication jobApplication = new JobApplication();
        jobApplication.CompanyName = companyName.Text;
        jobApplication.Salary = salary.Text;
        jobApplication.Location = location.Text;
        jobApplication.Role = role.Text;
        jobApplication.Status = 0; //default for newly applied

        Database.AddJobApplicationAsync(jobApplication);

    }
}
