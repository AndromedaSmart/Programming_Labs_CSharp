using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Isu;
using Isu.Tools;
using IsuExtra.Tools;

namespace IsuExtra
{
    public class IsuExtra
    {
        private readonly int id;
        private readonly int groupOfStudents;
        private readonly List<Group> groups;
        private readonly List<Student> students;

        public IsuExtra()
        {
            id = 0;
            groupOfStudents = 30;
            groups = new List<Group>();
            students = new List<Student>();
            Ognp = new List<Ognp>();
        }

        private List<Ognp> Ognp { get; set; }

        public Ognp AddOgnp(string faculty, Course firstDiscipline, Course secondDiscipline)
        {
            Ognp newOgnp = new Ognp
            {
                Faculty = faculty,
                FirstDiscipline = firstDiscipline,
                SecondDiscipline = secondDiscipline,
            };

            Ognp.Add(newOgnp);

            return newOgnp;
        }

        public List<CurrentFlow> ShowCurrentFlowsOfCourse(Course course)
        {
            return course.CurrentFlows;
        }

        public List<Student> ShowStudentInOgnp(Ognp ognp)
        {
            return ognp.Students;
        }

        public List<Student> ShowStudentsWithoutOgnp(Group group)
        {
            foreach (Student student in students)
            {
                if (student.Course.CurrentFlow.ToString() == false.ToString())
                {
                   return group.Students;
                }
            }

            return null;
        }

        public Student ShowStudent(int id)
        {
            foreach (Student student in students)
            {
                if (id == student.Id)
                {
                    foreach (Student student1 in students)
                    {
                        if (id == student1.Id)
                        {
                            return student;
                        }
                    }
                }
                else
                {
                    throw new IsuException($"Can't find student!");
                }
            }

            return null;
        }

        public Student FindStudent(string name)
        {
            foreach (Student student in students)
            {
                if (name == student.Name)
                {
                    return student;
                }
            }

            return null;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            if (courseNumber.Number is > 0 and < 5)
            {
                foreach (Student student in students)
                {
                    if (courseNumber.Number.ToString() == student.Group.GroupName.NumberOfCourse.ToString())
                    {
                        return students.ToList();
                    }
                }
            }
            else
            {
                throw new Exception($"Invalid coursenumber!");
            }

            return null;
        }

        public Student AddStudentInGroup(Group group, string name)
        {
            foreach (Student student in group.Students)
            {
                if (name == student.Name)
                {
                    return student;
                }
                else
                {
                    throw new IsuException($"Student is already in group!");
                }
            }

            foreach (Group group1 in groups)
            {
                foreach (Student student in group1.Students)
                {
                    if (name == student.Name)
                    {
                        return student;
                    }
                    else
                    {
                        throw new Exception($"Another group is already exist this student!");
                    }
                }
            }

            if (group.Students.Count > groupOfStudents)
            {
                throw new IsuException($"Can't add student!");
            }

            var newStudent = new Student()
            {
                Id = id,
                Name = name,
                Group = group,
            };

            group.Students.Add(newStudent);
            students.Add(newStudent);

            return newStudent;
        }

        public bool ValidationOfGroupName(GroupName groupName)
        {
            return (groupName.NumberOfCourse is > 0 and < 5) && (groupName.NumberOfGroup is < 13 and > 0);
        }

        public Group AddGroup(GroupName name)
        {
            foreach (Group group in groups)
            {
                if (name.ToString() == group.GroupName.ToString())
                {
                    return group;
                }
                else
                {
                    throw new IsuException($"Group is already added!");
                }
            }

            if (!ValidationOfGroupName(name))
            {
                throw new IsuException($"Invalid groupname!");
            }

            groups.Add(new Group()
            {
                GroupName = name,
                Students = new List<Student>(),
            });

            return groups.Last();
        }

        public Func<Predicate<Student>, int> StudentRemover(Student student, Ognp ognp)
        {
            if ((student.Course != null) && (!student.Course.CurrentFlows.Any()))
            {
                throw new IsuExtraException("Can't register student, who doesn't has chosen course");
            }

            if (student.Course != null)
            {
                foreach (CurrentFlow i in student.Course.CurrentFlows)
                {
                    i.AvailablePlaces += 1;

                    foreach (Student student1 in students)
                    {
                        if (student.Id == student1.Id)
                        {
                            return i.Students.RemoveAll;
                        }
                    }
                }

                foreach (Student student1 in students)
                {
                    if (student.Id == student1.Id)
                    {
                        return ognp.Students.RemoveAll;
                    }
                }
            }

            student.Course = null;
            return null;
        }

        public void GroupRemover(GroupName groupName)
        {
            foreach (Group group in groups)
            {
                if (groupName.ToString() == group.GroupName.ToString())
                {
                    foreach (Group group1 in groups)
                    {
                        if (groupName.ToString() == group1.GroupName.ToString())
                        {
                            groups.RemoveAll(null!);
                        }
                    }
                }
                else
                {
                    throw new IsuExtraException($"Invalid groupname!");
                }
            }
        }

        public void GroupChanger(Student student, Group newGroup)
        {
            foreach (Student student1 in students)
            {
                if (student.Name != student1.Name)
                {
                    throw new IsuException($"List of students doesn't exist this student!");
                }
            }

            foreach (Group group1 in groups)
            {
                if (group1.GroupName.ToString() != newGroup.GroupName.ToString())
                {
                    throw new IsuExtraException($"Group not found!");
                }
            }

            student.Group.Students.Remove(student);
            student.Group.GroupName = newGroup.GroupName;
            newGroup.Students.Add(student);
        }

        public Student AddStudentInOgnp(Student student, Ognp ognp)
        {
            if (student.Faculty == ognp.Faculty)
            {
                throw new IsuExtraException("Can't enter course of faculty");
            }

            CurrentFlow flowOfFstDiscipline = null;
            CurrentFlow flowOfSndDiscipline = null;

            foreach ((string i, List<Pair> pairs) in student.Group.Pairs)
            {
                foreach (Pair pair in pairs)
                {
                    flowOfFstDiscipline = ognp.FirstDiscipline.CurrentFlows.Find(currentFlow => currentFlow.Pairs[i].All(pair => pair.StartOfLecture != pair.StartOfLecture));

                    flowOfSndDiscipline = ognp.SecondDiscipline.CurrentFlows.Find(currentFlow => currentFlow.Pairs[i].All(pair => pair.StartOfLecture != pair.StartOfLecture));
                }
            }

            if ((flowOfFstDiscipline == null) || (flowOfSndDiscipline == null))
            {
                throw new IsuExtraException("Exception - shedule has intersections!");
            }

            if ((flowOfFstDiscipline.AvailablePlaces == 0) && (flowOfSndDiscipline.AvailablePlaces == 0))
            {
                throw new IsuExtraException("Nothing places to add");
            }

            return student;
        }
    }
}
