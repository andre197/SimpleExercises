namespace BitwiseComplement
{
    using System;
    using System.Linq;

    public class Converter
    {
        public int ConvertToReversedNumber(int numberToBeConverted)
        {
            string convertedToBinary = Convert.ToString(numberToBeConverted, 2);

            convertedToBinary = ConvertTheNumber(convertedToBinary);
            

            int converted = Convert.ToInt32(convertedToBinary, 2);

            return converted;
        }

        private string ConvertTheNumber(string convertedToBinary)
        {
            string result = string.Empty;

            for (int i = 0; i < convertedToBinary.Length; i++)
            {
                result += (convertedToBinary[i] == '0') ? "1" : "0";
            }

            return result;
        }
    }
}
