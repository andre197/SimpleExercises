namespace Generics.ExtensionMethods
{
    using System;

    public static class VariableExtensions
    {
        public static Variable Set(this Variable var,string name, int value) 
            => new Variable()
                    {
                        Name = name, Value = value
                    };

        public static void Print(this Variable variable)
        {
            Console.WriteLine($"{variable.Name} -- {variable.Value}");
        }
    }
}
