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
    public class Employee
    {
        // Employee data
        public int EmployeeID;
        public string FirstName;
        public string LastName;
        public double HourlyWage;
        public double HoursWorked;
        public double TotalPayroll;



        // Strings and ints to create random records
        public static int EmployeeIDPrefix = -1;
        public static string[] FirstNamePrefix = { "a", "b", "c" };
        public static string[] LastNamePrefix = { "a", "b", "c" };
        public static System.Random r = new System.Random(1);

        // Create an Employee
        public static Employee createEmployee()
        {
            Employee e = new Employee();
            e.EmployeeID = ++EmployeeIDPrefix;
            e.FirstName = FirstNamePrefix[r.Next(0, FirstNamePrefix.GetUpperBound(0) + 1)] + EmployeeIDPrefix.ToString();
            e.LastName = LastNamePrefix[r.Next(0, LastNamePrefix.GetUpperBound(0) + 1)] + EmployeeIDPrefix.ToString();
            e.HourlyWage = r.NextDouble() * (180.00 - 9.00) + 9.00;
            e.HoursWorked = r.NextDouble() * (100.00 - 0) + 0;
            e.TotalPayroll = e.HourlyWage * e.HoursWorked;

            return e;
        }
        public int GetID()
        {
            return this.EmployeeID;
        }


    }
}