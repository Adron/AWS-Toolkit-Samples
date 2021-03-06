﻿using System;
using AWS_MVC_Web_Application.Models;
using Quartz;

namespace AWS_MVC_Web_Application.Jobs
{
    public class StatusTrackerJob : IJob
    {
        readonly NotBigDataEntities db;

        public StatusTrackerJob()
        {
            db = new NotBigDataEntities();
        }

        public void Execute(JobExecutionContext context)
        {
            var awsInstanceStatus =
                new AwsEc2Status
                    {
                        Id = Guid.NewGuid(),
                        Message = "Pulse: " + DateTime.Now.ToShortTimeString() + " Currently all systems are operational.",
                        Stamp = DateTime.Now
                    };

            db.AwsEc2Status.AddObject(awsInstanceStatus);
            db.SaveChanges();
        }
    }
}