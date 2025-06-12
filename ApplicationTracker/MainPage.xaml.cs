using ApplicationTracker.Data;
using System.Collections.ObjectModel;

namespace ApplicationTracker
{
    public partial class MainPage : ContentPage
    {
        // Use an ObservableCollection. It automatically notifies the UI when items are added/removed.
        public ObservableCollection<JobApplication> JobApplications { get; set; }

        // Reference to our database helper class.
        DatabaseHelper database;

        public MainPage()
        {
            InitializeComponent();

            // Initialize the database helper and the collection.
            database = new DatabaseHelper();
            JobApplications = new ObservableCollection<JobApplication>();

            // Set the BindingContext of the page to itself.
            // This allows the XAML <CollectionView> to find the "JobApplications" property to bind to.
            this.BindingContext = this;
        }

        /// <summary>
        /// This method is part of the MAUI Page Lifecycle and is automatically called
        /// every time the user navigates to this page. It's the perfect place to
        /// refresh data from the database.
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadApplications();
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