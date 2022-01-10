using System;

namespace WebScraper
{
    // SuperPerson Inherits from Person
    class SuperPerson : Person
    {
        // constructor uses the base setup of the inherited class, and could do additional constructing, if needed.
        public SuperPerson(string FirstName, string LastName) :
            base(FirstName, LastName)
        {
        }

        public void Fly()
        {
            Console.WriteLine("I'm flying!");
        }
    }
}