using System;

namespace EventsProject
{
    public class NameChangedArgs: EventArgs
    {
        public NameChangedArgs(string newName, NameChangingType nameType)
        {
            NewName = newName;
            NameType = nameType;
            Canceled = false;
        }

        public string NewName { get; set; }
        
        public bool Canceled { get; set; }
        
        public enum NameChangingType { FirstName, LastName }
        public NameChangingType NameType { get; set; }
    }
}
