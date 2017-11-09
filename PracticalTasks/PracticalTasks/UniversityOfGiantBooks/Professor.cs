namespace UniversityOfGiantBooks
{
    using System.Collections.Generic;

    public class Professor
    {
        public string Name { get; set; }

        public List<int> TestedStudentsNumbers { get; set; } = new List<int>();

        public int TimeWaited { get; set; }
    }
}
