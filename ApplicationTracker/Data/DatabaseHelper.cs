using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ApplicationTracker.Data;

namespace ApplicationTracker.Data
{
    public class DatabaseHelper
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseHelper()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "JobApplications.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<JobApplication>().Wait();
        }

        //ADD
        public Task<int> AddJobApplicationAsync(JobApplication job)
        {
            return _database.InsertAsync(job);
        }

        // READ ALL
        public Task<List<JobApplication>> GetJobApplicationsAsync()
        {
            return _database.Table<JobApplication>().ToListAsync();
        }

        // READ ONE
        public Task<JobApplication> GetJobApplicationByIdAsync(int id)
        {
            return _database.Table<JobApplication>().Where(j => j.ID == id).FirstOrDefaultAsync();
        }

        // UPDATE
        public Task<int> UpdateJobApplicationAsync(JobApplication job)
        {
            return _database.UpdateAsync(job);
        }

        // DELETE
        public Task<int> DeleteJobApplicationAsync(JobApplication job)
        {
            return _database.DeleteAsync(job);
        }
    }
}