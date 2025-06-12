using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ApplicationTracker.Data
{
    public class JobApplication : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement] //saves me the hassle of having to add code to increase id num with each drink.
        public int ID { get; set; }
        public string Role { get; set; }

        public string Salary { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }

        private int _status;
        public int Status
        {
            get => _status;
            set
            {
                if (_status == value) return;
                _status = value;
                OnPropertyChanged(); // This will trigger the BackgroundColor binding to re-evaluate
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
