using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer { Id = 1,FirstName="Ömer Faruk",LastName="Gül",City="Sakarya" };
        

            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Nuri";
            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);

            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public abstract Person Clone();
    }
    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
    public class Employee : Person
    {
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}