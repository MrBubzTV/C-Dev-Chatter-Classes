using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Episode_0_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreRealData();

            //HaveFunWithFiles();

            //HaveFunWithBinary();
        }

        static void StoreRealData()
        {
            Console.WriteLine("Enter your first name!");
            var firstname =  Console.ReadLine();
            
            Console.WriteLine("Enter your last name!");
            var lastname =  Console.ReadLine();

            Console.WriteLine("Enter your age!");
            var age = int.Parse( Console.ReadLine());

            var bubz = new Person(firstname, lastname, age);

            string alltext = JsonConvert.SerializeObject(bubz);

            File.AppendAllLines("people.txt", new[] {alltext});

            var allLines = File.ReadAllLines("people.txt");

            Console.WriteLine($"\nContact List ({allLines.Length}):\n");

            foreach (var line in allLines)
            {
                var person = JsonConvert.DeserializeObject<Person>(line);
                Console.WriteLine($"{person.FirstName} {person.LastName} - {person.Age}");
            }
        }

        static void HaveFunWithFiles()
        {
            List<string> lines = new List<string>();

            lines.Add("These are some lines of text 1");
            lines.Add("These are some lines of text 2");
            lines.Add("These are some lines of text 3");
            lines.Add("These are some lines of text 4");

            var filename = "WoWArguments.Txt";
            File.WriteAllLines(filename, lines);

            string[] alltext = File.ReadAllLines(filename);

            foreach (var line in alltext)
            {
                Console.WriteLine(line);
            }
        }

        private static void HaveFunWithBinary()
        {
            Console.WriteLine ("Type in your favorite base 10 number!");
            string userInput = Console.ReadLine();
            int number = int.Parse(userInput);

            string binary = Convert.ToString(number, 2);

            Console.WriteLine(binary);

            Console.WriteLine ("Type in your favorite base 2 number!");
            userInput = Console.ReadLine();

            number = Convert.ToInt32(userInput, 2);

            Console.WriteLine(number);
        }
    }

    public class Person
    {
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

    }
}
