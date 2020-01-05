namespace EventsProject
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        
        public delegate void NameChanged(object sender, NameChangedArgs args);
                
        public event NameChanged FirstNameChanged; 
        public event NameChanged LastNameChanged;
        
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (FirstNameChanged != null)
                {
                    NameChangedArgs changeArgs = new NameChangedArgs(value,
                        NameChangedArgs.NameChangingType.FirstName
                    );
                    
                    FirstNameChanged(this, changeArgs);
                    
                    if (changeArgs.Canceled) return;

                    this.firstName = value;
                }
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (LastNameChanged != null)
                {
                    NameChangedArgs changeArgs = new NameChangedArgs(value,
                        NameChangedArgs.NameChangingType.LastName
                    );
                    
                    LastNameChanged(this, changeArgs);
                    
                    if (changeArgs.Canceled) return;

                    this.lastName = value;
                }
            }
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
