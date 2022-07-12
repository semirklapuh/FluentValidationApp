
using System;
using System.Globalization;

namespace testapp
{

    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }

        public double accountBalance { get; set; }

        public DateTime date {get; set;}

        public override string ToString()
        {
            return "Id: " + id + ", name: " +name +
             " AccountBalance: " + accountBalance + " date: " + date;
        }
    }
}