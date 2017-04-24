using Android.App;
using System;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Views;
using Android.Content;
using System.Linq;

namespace PadillaMelitonAssn4
{
    [Activity(Label = "PadillaMelitonAssn4", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        private SortedList<int, Employee> EmployeeListID = new SortedList<int, Employee>();
        private SortedList<int, Employee> singleEmployee = new SortedList<int, Employee>();
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Generate the employees and insert into list
            for (int x = 0; x < 100; x++)
            {
                Employee e = Employee.createEmployee();
                EmployeeListID.Add(e.EmployeeID, Employee.createEmployee());
            }

            ListView.ChoiceMode = ChoiceMode.Single;

            // Bind the Adapter. Note that we are binding employees instead
            // of a list of string.
            ListAdapter = new HomeScreenAdapterComplex(this, EmployeeListID);
        }

        //
        // Override the ListActivity's OnListItemClick() event as before.
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            Employee e;
            KeyValuePair<int, Employee> keyPair;
            keyPair = EmployeeListID.ElementAt(position);
            e = EmployeeListID[keyPair.Key];

            singleEmployee.Add(e.EmployeeID, e);

            // Serialize data to pass 
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(singleEmployee);
            Intent activityIntent = new Intent(this, typeof(viewEmployee));
            activityIntent.PutExtra("EmployeeSortedList", output);
            // Start next activity
            StartActivity(activityIntent);
        }

    }

        public class HomeScreenAdapterComplex : BaseAdapter<Employee>
        {

            private SortedList<int,Employee> items;
            private Activity context;

            public HomeScreenAdapterComplex(Activity context, SortedList<int,Employee> items)
                : base()
            {
                this.context = context;
                this.items = items;
            }

            // The GetItemId method does not change.
            public override long GetItemId(int position)
            {
                return position;
            }

            public override Employee this[int position]
            {
                get
                {
                    return items[items.Keys[position]];
                }
            }

            // The Count method does not change.
            public override int Count
            {
                get
                {
                    return items.Count;
                }
            }

            // The GetView() method is changed considerably. In this example, we bind the row
            // to the predefined layout named Android.Resource.Layout.SimpleListItem2
            // instead of Android.Resource.Layout.SimpleListItem1. This layout has two
            // TextView widgets named Text1 and Text2.
            //
            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                // Items is of type Employeee
                Employee item = items[items.Keys[position]];

                View view = convertView;
                if (view == null)
                {
                    // We are still using one of the Android layout's here. This layout
                    // has two TextView widgets instead of one.
                    view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
                }

                // Because item is of type Employee, we reference the Employee properties
                // instead of the default string properties.
                view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.LastName +" "+ item.FirstName;
                view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = "Id#: " + item.EmployeeID.ToString();


            return view;
            }
     }
}

