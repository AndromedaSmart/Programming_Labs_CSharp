namespace IsuExtra
{
    public class Student : Isu.Student
    {
        public Student(string faculty)
        {
            Faculty = faculty;
        }

        public Student()
        {
            throw new System.NotImplementedException();
        }

        public Course Course { get; set; } = new Course();
        public new Group Group { get; set; }
        public string Faculty { get; }
    }
}
