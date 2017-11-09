namespace PracticalTasks
{
    using Generics;
    using Generics.ExtensionMethods;
    using System;
    using XmlParserProject;

    public class Program
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            int value = int.Parse(Console.ReadLine());

            Variable variable1 = new Variable().Set(name, value);
            Variable variable2 = new Variable().Set(name, value);
            Variable variable3 = new Variable().Set(name + "1", value + 1);

            int n = variable1 * variable2;

            Console.WriteLine(n);

            Variable variable4 = variable1 + variable2;

            if (variable1 == variable2)
            {
                Console.WriteLine($"{variable1.Name} is equal to {variable2.Name}");
            }

            if (variable1 != variable3)
            {
                Console.WriteLine($"{variable1.Name} is not equal to {variable3.Name}");
            }
            else
            {
                Console.WriteLine("there is no else");
            }

            Console.WriteLine(new string('=',20));

            variable1.Print();
        }
    }
}
