namespace IsuExtra
{
    public class GroupName : Isu.GroupName
    {
        public GroupName(string facultyNumber)
        {
            FacultyNumber = facultyNumber;
        }

        private string FacultyNumber { get; set; }
        public override string ToString()
        {
            return FacultyNumber + NumberOfCourse.ToString() + NumberOfGroup.ToString();
        }
    }
}
