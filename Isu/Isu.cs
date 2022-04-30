using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Services;
using Isu.Tools;

namespace Isu
{
    public class Isu : IIsuService
    {
        private int id;
        private int studentsInGroup;
        private List<Group> groups;
        private List<Student> students;

        public Isu()
        {
            id = 0;
            studentsInGroup = 30;
            groups = new List<Group>();
            students = new List<Student>();
        }

        public void ListOfGroups()
        {
            Console.WriteLine("Available groups");

            for (int i = 0; i < groups.Count; i++)
            {
                Console.WriteLine($"{groups[i].GroupName}\n");
            }
        }

        public void ListOfStudents()
        {
            Console.WriteLine("Student's list");

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{students[i].Name}\n");
            }
        }

        public Student AddStudent(Group group, string name)
        {
            var makeNewStudent = new Student()
            {
                Id = id,
                Name = name,
                Group = group,
            };

            foreach (Student student in students)
            {
                if (name == student.Name)
                {
                    throw new IsuException("Can't add student!");
                }
            }

            foreach (Group group1 in groups)
            {
                if (group1.ToString() == group.Students.ToString())
                {
                    foreach (Student student in students)
                    {
                        if (!string.IsNullOrEmpty(name = student.Name))
                        {
                            throw new IsuException("Can't add student!");
                        }
                    }
                }
            }

            if (group.Students.Count >= studentsInGroup)
            {
                throw new IsuException("Can't add student!");
            }

            group.Students.Add(makeNewStudent);
            students.Add(makeNewStudent);

            return makeNewStudent;
        }

        public bool ValidationOfGroupName(GroupName groupName)
        {
            if ((groupName.NumberOfCourse > 0) && (groupName.NumberOfCourse < 5))
            {
                return true;
            }

            if ((groupName.NumberOfCourse > 0) && (groupName.NumberOfCourse < 13))
            {
                return true;
            }
            else
            {
                return false;
            }
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
                    throw new IsuException("Can't add group!");
                }
            }

            if (!ValidationOfGroupName(name))
            {
                throw new IsuException("Invalid groupname!");
            }

            groups.Add(new Group() { GroupName = name, Students = new List<Student>() });

            return groups.Last();
        }

        public int GetStudentsCount(Group group)
        {
            return group.Students.Count;
        }

        public Student GetStudent(int studentId)
        {
            foreach (Student student in students)
            {
                if (studentId == student.Id)
                {
                    return student;
                }
                else
                {
                    throw new IsuException("Can't find student!");
                }
            }

            return null;
        }

        public Student FindStudent(string name)
        {
            foreach (Student student in students)
            {
                if (!string.IsNullOrEmpty(name = student.Name))
                {
                    return student;
                }
                else
                {
                    throw new IsuException("Can't find student!");
                }
            }

            return null;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            if ((courseNumber.Number > 0) && (courseNumber.Number < 5))
            {
                foreach (Student student in students)
                {
                    if (courseNumber.Number == student.Group.GroupName.NumberOfCourse)
                    {
                        return students;
                    }
                    else
                    {
                        throw new Exception("Can't find students!");
                    }
                }
            }

            return null;
        }

        public List<Student> FindStudents(GroupName groupName)
        {
            foreach (Group group in groups)
            {
                if (groupName.ToString() != group.ToString())
                {
                    throw new IsuException("Can't find students!");
                }
            }

            return FindGroup(groupName).Students;
        }

        public Group FindGroup(GroupName groupName)
        {
            foreach (Group group in groups)
            {
                if (groupName.ToString() != group.ToString())
                {
                    foreach (Group group1 in groups)
                    {
                        if (groupName.ToString() == groups.ToString())
                        {
                            return group1;
                        }
                    }
                }
                else
                {
                    throw new IsuException("Invalid groupname!");
                }
            }

            return null;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            foreach (Group groupCount in groups)
            {
                if (courseNumber.Number != groupCount.GroupName.NumberOfCourse)
                {
                    return groups.ToList();
                }
                else
                {
                    throw new IsuException("Invalid coursenumber!");
                }
            }

            return null;
        }

        public void ChangeStudentGroup(Student student, Group changedGroup)
        {
            foreach (Student student1 in students)
            {
                if (student1.ToString() != students.ToString())
                {
                    throw new IsuException("Can't find student!");
                }
            }

            student.Group.Students.Remove(student);
            student.Group.GroupName = changedGroup.GroupName;
            changedGroup.Students.Add(student);
        }
    }
}
