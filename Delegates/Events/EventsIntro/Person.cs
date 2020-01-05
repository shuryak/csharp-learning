using System;

namespace EventsIntro
{
    public class Person
    {
        public event EventHandler AgeChanged;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0) throw new Exception("Age can't be negative.");

                age = value;

                if (AgeChanged != null) AgeChanged(this, new EventArgs());
            }
        }
    }
}