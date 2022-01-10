using System;

namespace WebScraper
{
    class Person
    {
        // Fields - should remain private to the class, and are private by default.
        string _ssn;

        // Properties - getter/setter methods that should be used to reveal some/all field information.
        public string Birthday { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public string SSN {
            get {
                return _ssn;
            }
            set {
                if (value.Length < 1)
                {
                    Console.WriteLine("Invalid Input");
                }

                _ssn = value;
            }
        }

        // Constructor - allows you to set some field/property information on instanciation.
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        // Methods - behaviors
        public void Eat()
        {
            Console.WriteLine("I'm Eating");
        }

        public void Sleep()
        {
            Console.WriteLine("I'm Sleeping");
        }
    }
}