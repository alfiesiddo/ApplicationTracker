using ApplicationTracker.Data;
using System.Collections.ObjectModel; // Important for dynamic UI updates

namespace ApplicationTracker
{
    public partial class MainPage : ContentPage
    {
        // Use an ObservableCollection. It automatically notifies the UI when items are added/removed.
        public ObservableCollection<JobApplication> JobApplications { get; set; } = new();

        DatabaseHelper database;

        public MainPage()
        {
            InitializeComponent();
            database = new DatabaseHelper();

            // Set the BindingContext so the XAML can find our "JobApplications" property.
            this.BindingContext = this;
        }

        // Use OnAppearing to refresh data every time the page is shown.
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadApplications();
        }

        private async Task LoadApplications()
        {
            var applicationsFromDb = await database.GetJobApplicationsAsync();

            // Clear the existing list and add the new ones.
            JobApplications.Clear();
            foreach (var app in applicationsFromDb)
            {
                JobApplications.Add(app);
            }
        }
    }
}