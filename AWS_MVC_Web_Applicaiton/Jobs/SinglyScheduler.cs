using System;
using Quartz;
using Quartz.Impl;

namespace AWS_MVC_Web_Applicaiton.Jobs
{
    public class SinglyScheduler
    {
        private static readonly ISchedulerFactory SchedulerFactory;
        private static readonly IScheduler Scheduler;

        static SinglyScheduler()
        {
            SchedulerFactory = new StdSchedulerFactory();
            Scheduler = SchedulerFactory.GetScheduler();
        }
        
        public static IScheduler GetScheduler()
        {
            if (Scheduler.IsStarted == false)
                Scheduler.Start();
            return Scheduler;
        }
      
        public static void FireOffSchedules()
        {
            var sched = GetScheduler();
            
            var jobDetail =
                new JobDetail("myJob", null, typeof(StatusTrackerJob));

            var trigger = TriggerUtils.MakeSecondlyTrigger(5);
            trigger.StartTimeUtc = DateTime.UtcNow;
            trigger.Name = "myTrigger";
            sched.ScheduleJob(jobDetail, trigger);
        }
    }
}