namespace UniversityOfGiantBooks
{
    public class GiantBook
    {
        private int from;
        private int to;

        public GiantBook(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

        public bool IsStudentContained(int facultyNumber)
                => this.from >= facultyNumber && facultyNumber < this.to;
    }
}
