using System;
using System.Collections.Generic;
using NUnit.Framework;
using Backups;

namespace Backups.Tests
{
    [TestFixture]
    public class BackupsTest
    {
        [Test]
        public void AddFacility()
        {
            var job1 = new BackupJob("split", "path");
            var jobObject = new JobObject("C:\\Andromeda\\NewFile.png", "NewFile");
            job1.FacilityCreator(jobObject);

        }

        public void CreateNewRestorePoint()
        {
            var jobs = new List<JobObject>();
            var list = new List<RestorePoint>();

            var point = new RestorePoint(jobs, "path", "split", list);
            point.CreateRestorePoint();
        }
    }
}