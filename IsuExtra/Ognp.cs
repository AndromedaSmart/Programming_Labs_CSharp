using System.Collections.Generic;

namespace IsuExtra
{
    public class Ognp
    {
        public string Faculty { get; set; }
        public Course FirstDiscipline { get; set; }
        public Course SecondDiscipline { get; set; }
        public List<Student> Students { get; } = new ();
    }
}