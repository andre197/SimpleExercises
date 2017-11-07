namespace PracticalTasks
{
    using BitwiseComplement;
    using System;

    public class Program
    {
        public static void Main()
        {
            Converter converter = new Converter();

            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(converter.ConvertToReversedNumber(number));
        }
    }
}
