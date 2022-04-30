using System.Collections.Generic;

namespace IsuExtra
{
    public class Course
    {
        public Course(object currentFlow)
        {
            CurrentFlow = currentFlow;
        }

        public Course()
        {
            throw new System.NotImplementedException();
        }

        public List<CurrentFlow> CurrentFlows { get; } = new ();
        public object CurrentFlow { get; }
    }
}
