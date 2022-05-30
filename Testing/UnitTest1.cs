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

        [Fact]
        public void TestNextMinute()
        {
            Schedule schedule = new Schedule();
            schedule.timeDate = new DateTime(2022, 5, 30);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = true; schedule.wednesday = true; schedule.thursday = true;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.periodType = 1; //minutes
            schedule.timePeriod = 5; // every 5 minutes
            schedule.startTime = new DateTime(1900, 1, 1, 10, 00, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.weekPeriod = 1;

            DateTime expectedValue = new DateTime(2022,5,30,10,5,0);
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
        public void TestNextMinute2()
        {
            Schedule schedule = new Schedule();
            schedule.timeDate = new DateTime(2022, 5, 30);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = true; schedule.wednesday = true; schedule.thursday = true;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.periodType = 1; //minutes
            schedule.timePeriod = 30; // every 30 minutes
            schedule.startTime = new DateTime(1900, 1, 1, 10, 00, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.weekPeriod = 1;

            DateTime expectedValue = new DateTime(2022, 5, 31, 10, 00, 0);
            int i = 0;
            while (i < 3)
            {
                schedule.nextDate();
                i++;
            }
            DateTime actualValue = schedule.timeDate;
            actualValue.Should().Be(expectedValue);

        }
        [Fact]
        public void TestNextHour()
        {
            Schedule schedule = new Schedule();
            schedule.timeDate = new DateTime(2022, 5, 30);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = true; schedule.wednesday = true; schedule.thursday = true;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.periodType = 0; //hours
            schedule.timePeriod = 1; // every 1 hour
            schedule.startTime = new DateTime(1900, 1, 1, 10, 00, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 11, 00, 0);
            schedule.weekPeriod = 1;

            DateTime expectedValue = new DateTime(2022, 5, 31, 10, 00, 0);
            int i = 0;
            while (i < 3)
            {
                schedule.nextDate();
                i++;
            }
            DateTime actualValue = schedule.timeDate;
            actualValue.Should().Be(expectedValue);

        }
        [Fact]
        public void TestNextMinute3()
        {
            Schedule schedule = new Schedule();
            schedule.timeDate = new DateTime(2022, 5, 30,10,30,0);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = true; schedule.wednesday = true; schedule.thursday = true;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.periodType = 1; //minutes
            schedule.timePeriod = 30; // every 30 minutes
            schedule.startTime = new DateTime(1900, 1, 1, 10, 00, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.weekPeriod = 1;

            DateTime expectedValue = new DateTime(2022, 5, 31, 10, 00, 0);

            schedule.createListOfDays();
            DateTime actualValue = schedule.nextMinute(schedule.timeDate);
            actualValue.Should().Be(expectedValue);

        }

        [Fact]
        public void TestNextHour2()
        {
            Schedule schedule = new Schedule();
            schedule.timeDate = new DateTime(2022, 5, 30, 10, 00, 0);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = true; schedule.wednesday = true; schedule.thursday = true;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.periodType = 0; 
            schedule.timePeriod = 2;
            schedule.startTime = new DateTime(1900, 1, 1, 10, 00, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 00, 0);
            schedule.weekPeriod = 1;

            DateTime expectedValue = new DateTime(2022, 5, 31, 10, 00, 0);

            schedule.createListOfDays();
            DateTime actualValue = schedule.nextHour(schedule.timeDate);
            
            actualValue.Should().Be(expectedValue);

        }

        [Fact]
        public void TestNextSecond()
        {
            Schedule schedule = new Schedule();
            schedule.timeDate = new DateTime(2022, 5, 30);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = true; schedule.wednesday = true; schedule.thursday = true;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.periodType = 2; //seconds
            schedule.timePeriod = 7; // every 7 seconds
            schedule.startTime = new DateTime(1900, 1, 1, 10, 00, 50);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 01, 0);
            schedule.weekPeriod = 1;

            DateTime expectedValue = new DateTime(2022, 5, 31, 10, 00, 57);
            int i = 0;
            while (i < 4)
            {
                schedule.nextDate();
                i++;
            }
            DateTime actualValue = schedule.timeDate;
            actualValue.Should().Be(expectedValue);

        }
    }
}