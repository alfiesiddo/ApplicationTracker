using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ApplicationTracker.Data
{
    public class JobApplication
    {

        [PrimaryKey, AutoIncrement] //saves me the hassle of having to add code to increase id num with each drink.
        public int ID { get; set; }
        public string Role { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }

        public int Status { get; set; } = 0;
    }
}
