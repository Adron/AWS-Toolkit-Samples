﻿using AWS_MVC_Web_Applicaiton.Models;
using Quartz;

namespace AWS_MVC_Web_Applicaiton.Jobs
{
    public class StatusTrackerJob : IJob
    {
        readonly PilesOfDataEntities db;

        public StatusTrackerJob()
        {
            db = new PilesOfDataEntities();
        }

        public void Execute(JobExecutionContext context)
        {
            //var quartzlog =
            //    new QuartzLog
            //        {
            //            Id = Guid.NewGuid(),
            //            Message = "Pulse: " + DateTime.Now.ToShortTimeString() + " Currently all systems are operational.",
            //            Stamp = DateTime.Now
            //        };

            //db.QuartzLogs.AddObject(quartzlog);
            db.SaveChanges();
        }
    }
}