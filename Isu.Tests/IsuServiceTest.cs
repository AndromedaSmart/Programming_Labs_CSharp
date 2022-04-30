using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = null;
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            
            Isu isu1 = new Isu();
            GroupName M3209 = new GroupName();
            
            
            M3209.NumberOfCourse = 1;
            M3209.NumberOfGroup = 9;

            Group group = isu1.AddGroup(M3209);
            Student student = isu1.AddStudent(group, "Васёк");

            if (isu1.GetStudentsCount(group) != 1)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Isu isu1 = new Isu();
            GroupName M3209 = new GroupName();
            
            
            M3209.NumberOfCourse = 1;
            M3209.NumberOfGroup = 9;

            Group group = isu1.AddGroup(M3209);
            
            
            Assert.Catch<IsuException>(() =>
            {
                while (true)
                {
                    isu1.AddStudent(group, "Васёк");
                }
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            
            Isu isu1 = new Isu();
            GroupName invalidName = new GroupName();
            
            invalidName.NumberOfCourse = int.MaxValue;
            invalidName.NumberOfGroup = int.MinValue;
            
            Assert.Catch<IsuException>(() =>
            {
                isu1.AddGroup(invalidName);
            });
        }
    }
}