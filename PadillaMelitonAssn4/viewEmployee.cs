using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PadillaMelitonAssn4
{
    [Activity(Label = "viewEmployee")]
    public class viewEmployee : Activity
    {
        private SortedList<int, Employee> EmployeeListID = new SortedList<int, Employee>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.viewEmployeeLayout);

            // Connet text views
            TextView editSortedEmployeeID = (TextView)FindViewById(Resource.Id.editSortedEmployeeID);
            TextView editSortedFirstName = (TextView)FindViewById(Resource.Id.editSortedFirstName);
            TextView editSortedLastName = (TextView)FindViewById(Resource.Id.editSortedLastName);
            TextView editSortedHourlyWage = (TextView)FindViewById(Resource.Id.editSortedHourlyWage);
            TextView editSortedHoursWorked = (TextView)FindViewById(Resource.Id.editSortedHoursWorked);
            TextView editSortedTotalPayroll = (TextView)FindViewById(Resource.Id.editSortedTotalPayroll);
            Button btnSelectOtherEmployee = (Button)FindViewById(Resource.Id.btnSelectOtherEmployee);

            // Create method
            btnSelectOtherEmployee.Click += btnSelectOtherEmployee_Click;

            // Grab data and display 
            string txtFromActivity = Intent.GetStringExtra("EmployeeSortedList");
            EmployeeListID = Newtonsoft.Json.JsonConvert.DeserializeObject<SortedList<int, Employee>>(txtFromActivity);

            // Display data on activity
            int position = 0;
            Employee e;
            KeyValuePair<int, Employee> keyPair;
            keyPair = EmployeeListID.ElementAt(position);
            e = EmployeeListID[keyPair.Key];

            editSortedEmployeeID.Text = e.EmployeeID.ToString();
            editSortedFirstName.Text = e.FirstName;
            editSortedLastName.Text = e.LastName;
            editSortedHourlyWage.Text = e.HourlyWage.ToString();
            editSortedHoursWorked.Text = e.HoursWorked.ToString();
            editSortedTotalPayroll.Text = e.TotalPayroll.ToString();

        }

        private void btnSelectOtherEmployee_Click(object sender, EventArgs args)
        {
            Intent activityIntent = new Intent(this, typeof(MainActivity));
            // Start next activity
            StartActivity(activityIntent);
        }
    }
}