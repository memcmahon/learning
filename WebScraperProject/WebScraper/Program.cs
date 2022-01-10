using System;

namespace WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperPerson person = new SuperPerson("Megan", "McMahon");
            person.Birthday = "June 19";
            person.SSN = "DATA";
            Console.WriteLine(person.Birthday);
            Console.WriteLine(person.FirstName);
            Console.WriteLine(person.SSN);
            Console.WriteLine(person.LastName);
            person.Eat();
            person.Sleep();
            person.Fly();
        }
    }
}
