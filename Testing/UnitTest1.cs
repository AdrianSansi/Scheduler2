using FluentAssertions;
using Xunit;
using System;
using Scheduler2;


namespace Testing
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Schedule schedule = new Schedule();
            schedule.timeDate = new DateTime(2022,5,1);
            schedule.endDate = new DateTime(2022,5,31);
            schedule.monday = true; schedule.tuesday = false; schedule.wednesday = true; schedule.thursday = false;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.timePeriod = 2; // every 2 hours
            schedule.startTime = new DateTime(1900,1,1,10,30,0);
            schedule.endTime = new DateTime(1900,1,1,14,30,0);
            schedule.weekPeriod = 2;

            DateTime expectedValue = new DateTime(2022, 5, 1, 10, 30, 0);
            schedule.nextDate();
            DateTime actualValue = schedule.timeDate;
           
            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void Test2()
        {
            Schedule schedule = new Schedule();
            schedule.timeDate = new DateTime(2022, 5, 1);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = false; schedule.wednesday = true; schedule.thursday = false;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.timePeriod = 2; // every 2 hours
            schedule.startTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 14, 30, 0);
            schedule.weekPeriod = 2;

            DateTime expectedValue = new DateTime(2022, 5, 2, 12, 30, 0);
            int i = 0;
            while(i < 5)
            {
                schedule.nextDate();
                i++;
            }

            DateTime actualValue = schedule.timeDate;

            actualValue.Should().Be(expectedValue);
        }
        [Fact]
        public void Test3()
        {
            Schedule schedule = new Schedule();
            schedule.timeDate = new DateTime(2022, 5, 1);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = false; schedule.wednesday = true; schedule.thursday = false;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.timePeriod = 2; // every 2 hours
            schedule.startTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.weekPeriod = 2;

            DateTime expectedValue = new DateTime(2022, 5, 18, 10, 30, 0);
            int i = 0;
            while (i < 8)
            {
                schedule.nextDate();
                i++;
            }

            DateTime actualValue = schedule.timeDate;

            actualValue.Should().Be(expectedValue);
        }
        [Fact]
        public void Test4()
        {
            Schedule schedule = new Schedule();
            schedule.timeDate = new DateTime(2022, 5, 1);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = false; schedule.tuesday = false; schedule.wednesday = false; schedule.thursday = false;
            schedule.friday = false; schedule.saturday = false; schedule.sunday = false;
            schedule.timePeriod = 2; // every 2 hours
            schedule.startTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.weekPeriod = 2;

            DateTime expectedValue = new DateTime(2022, 5, 1, 10, 30, 0);
            int i = 0;
            while (i < 2)
            {
                schedule.nextDate();
                i++;
            }

            DateTime actualValue = schedule.timeDate;

            actualValue.Should().Be(expectedValue);
        }
        [Fact]
        public void TestStartTimeBiggerThanEndTime()
        {
            Schedule schedule = new Schedule();
            schedule.timeDate = new DateTime(2022, 5, 1);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = false; schedule.wednesday = true; schedule.thursday = false;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.timePeriod = 2; // every 2 hours
            schedule.startTime = new DateTime(1900, 1, 1, 11, 30, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.weekPeriod = 2;

            DateTime expectedValue = new DateTime(2022, 5, 18, 11, 30, 0);
            int i = 0;
            while (i < 8)
            {
                schedule.nextDate();
                i++;
            }

            DateTime actualValue = schedule.timeDate;

            actualValue.Should().Be(expectedValue);
        }
    }
}