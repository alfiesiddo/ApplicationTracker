using ApplicationTracker.Data;
using System.Collections.ObjectModel;

namespace ApplicationTracker
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<JobApplication> JobApplications { get; set; }
        DatabaseHelper database;

        public MainPage()
        {
            InitializeComponent();

            database = new DatabaseHelper();
            JobApplications = new ObservableCollection<JobApplication>();
            this.BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadApplications();

            int total = await database.GetTotalApplicationCount();
            int rejected = await database.GetTotalRejectionCount();

            TotalCountLabel.Text = total.ToString();
            RejectedCountLabel.Text = rejected.ToString();
        }

        private async Task LoadApplications()
        {
            var applicationsFromDb = await database.GetJobApplicationsAsync();
            JobApplications.Clear();
            foreach (var app in applicationsFromDb)
            {
                JobApplications.Add(app);
            }
        }

        private async void StatusPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var applicationToUpdate = (JobApplication)picker.BindingContext;
            if (applicationToUpdate != null)
            {
                await database.UpdateJobApplicationAsync(applicationToUpdate);
            }
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var applicationToDelete = (JobApplication)button.BindingContext;
            if (applicationToDelete != null)
            {
                bool confirmed = await DisplayAlert("Confirm Delete",
                    $"Are you sure you want to delete the application for {applicationToDelete.Role} at {applicationToDelete.CompanyName}?",
                    "Yes, Delete", "No");

                if (confirmed)
                {
                    await database.DeleteJobApplicationAsync(applicationToDelete);
                    JobApplications.Remove(applicationToDelete);
                }
            }
        }
    }
}