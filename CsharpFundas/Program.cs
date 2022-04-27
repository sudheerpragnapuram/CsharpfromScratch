using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFundas
{
    class Program : Prograom4
    {
        String name;
        String firstname;
        String lastname;
        // Creating constructor
        public Program(String name)
        {

            this.name = name;
        }
        public Program(String firstname, String lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public void getName()
        {
Console.WriteLine("My name is"+ this.name);
            Console.WriteLine("firstname"+this.firstname);
            Console.WriteLine("lastname"+this.lastname);
        }
        public void getData()
        {
            Console.WriteLine("I am inside the class");

        }

       
        static void Main(string[] args)
        {

            Program p = new Program("Apple");
            Program p1 = new Program("sun", "moon");
            p.getData();
            p.SetData();
            p.getName();
            p1.getName();
            Console.WriteLine("first program");

            int a = 4;
            Console.WriteLine("Number is "+a);
            String name = "sudheer";
            Console.WriteLine("Name is " + name);
            Console.WriteLine($"Name is {name}");

            var age = 23;
            Console.WriteLine("Age is "+ age);

            dynamic height = 13.2;
            Console.WriteLine($"Height is {height}");
            height = "hello";
            Console.WriteLine($"height is {height}");
        }
    }
}
