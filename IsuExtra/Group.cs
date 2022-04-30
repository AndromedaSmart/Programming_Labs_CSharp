using System.Collections.Generic;

namespace IsuExtra
{
    public class Group : Isu.Group
    {
        public new List<Student> Students { get; set; } = new List<Student>();
        public Dictionary<string, List<Pair>> Pairs { get; set; } = new Dictionary<string, List<Pair>>();
    }
}
