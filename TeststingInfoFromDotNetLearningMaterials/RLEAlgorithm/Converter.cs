namespace RLEAlgorithm
{
    using Contracts;
    using ReadAndWriteOnFile;
    using ReadAndWriteOnTheConsole;
    using System.Text;

    public class Converter
    {
        private string converted;
        private IReader reader;
        private IWriter writer;

        public void FromString()
        {
            this.reader = new ConsoleReader();

            string input = this.reader.ReadLine();

            char reminder = input[0];
            int cnt = 0;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (reminder == input[i])
                {
                    cnt++;
                }
                else
                {
                    sb.Append($"{cnt}{reminder}");
                    cnt = 1;
                }

                reminder = input[i];
            }

            sb.Append($"{cnt}{reminder}");

            this.writer = new ConsoleWriter();

            this.converted = sb.ToString();
            this.writer.WriteLine(sb.ToString());
        }

        public void FromCode()
        {
            this.reader = new ConsoleReader();

            string input = this.reader.ReadLine();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i += 2)
            {
                string result = new string(input[i + 1], int.Parse(input[i].ToString()));

                sb.Append(result);
            }

            this.writer = new ConsoleWriter();

            this.converted = sb.ToString();
            this.writer.WriteLine(sb.ToString());
        }

        public void Insert()
        {
            this.reader = new ConsoleReader();

            int position = int.Parse(this.reader.ReadLine());
            string str = this.reader.ReadLine();

            this.converted = this.converted.Insert(position, str);

            this.writer = new ConsoleWriter();
            this.writer.WriteLine(converted);
        }

        public void Remove()
        {
            this.reader = new ConsoleReader();

            int start = int.Parse(this.reader.ReadLine());
            int end = int.Parse(this.reader.ReadLine());

            this.converted = this.converted.Remove(start, (end - start));

            this.writer = new ConsoleWriter();
            this.writer.WriteLine(converted);
        }
    }
}
