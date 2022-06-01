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
            DateTime timeDate = new DateTime(2022, 5, 1);
            Schedule schedule = new Schedule(timeDate);
            schedule.endDate = new DateTime(2022,5,31);
            schedule.monday = true; schedule.tuesday = false; schedule.wednesday = true; schedule.thursday = false;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.timePeriod = 2; // every 2 hours
            schedule.startTime = new DateTime(1900,1,1,10,30,0);
            schedule.endTime = new DateTime(1900,1,1,14,30,0);
            schedule.weekPeriod = 2;
            schedule.format = 2;

            DateTime expectedValue = new DateTime(2022, 5, 1, 10, 30, 0);
            schedule.nextDate();
            DateTime actualValue = schedule.timeDate;
           
            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void Test2()
        {
            DateTime timeDate = new DateTime(2022, 5, 1);
            Schedule schedule = new Schedule(timeDate);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = false; schedule.wednesday = true; schedule.thursday = false;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.timePeriod = 2; // every 2 hours
            schedule.startTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 14, 30, 0);
            schedule.weekPeriod = 2;
            schedule.format = 2;

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
            DateTime timeDate = new DateTime(2022, 5, 1);
            Schedule schedule = new Schedule(timeDate);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = false; schedule.wednesday = true; schedule.thursday = false;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.timePeriod = 2; // every 2 hours
            schedule.startTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.weekPeriod = 2;
            schedule.format = 2;

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
            DateTime timeDate = new DateTime(2022, 5, 1);
            Schedule schedule = new Schedule(timeDate);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = false; schedule.tuesday = false; schedule.wednesday = false; schedule.thursday = false;
            schedule.friday = false; schedule.saturday = false; schedule.sunday = false;
            schedule.timePeriod = 2; // every 2 hours
            schedule.startTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.weekPeriod = 2;
            schedule.format = 2;

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
            DateTime timeDate = new DateTime(2022, 5, 1);
            Schedule schedule = new Schedule(timeDate);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = false; schedule.wednesday = true; schedule.thursday = false;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.timePeriod = 2; // every 2 hours
            schedule.startTime = new DateTime(1900, 1, 1, 11, 30, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.weekPeriod = 2;
            schedule.format = 2;

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
            DateTime timeDate = new DateTime(2022, 5, 30);
            Schedule schedule = new Schedule(timeDate);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = true; schedule.wednesday = true; schedule.thursday = true;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.periodType = 1; //minutes
            schedule.timePeriod = 5; // every 5 minutes
            schedule.startTime = new DateTime(1900, 1, 1, 10, 00, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.weekPeriod = 1;
            schedule.format = 2;

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
            DateTime timeDate = new DateTime(2022, 5, 30);
            Schedule schedule = new Schedule(timeDate);
            
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = true; schedule.wednesday = true; schedule.thursday = true;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.periodType = 1; //minutes
            schedule.timePeriod = 30; // every 30 minutes
            schedule.startTime = new DateTime(1900, 1, 1, 10, 00, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.weekPeriod = 1;
            schedule.format = 2;

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
            DateTime timeDate = new DateTime(2022, 5, 30);
            Schedule schedule = new Schedule(timeDate);
            
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = true; schedule.wednesday = true; schedule.thursday = true;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.periodType = 0; //hours
            schedule.timePeriod = 1; // every 1 hour
            schedule.startTime = new DateTime(1900, 1, 1, 10, 00, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 11, 00, 0);
            schedule.weekPeriod = 1;
            schedule.format = 2;

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
            DateTime timeDate = new DateTime(2022, 5, 30, 10, 30, 0);
            Schedule schedule = new Schedule(timeDate);
            
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = true; schedule.wednesday = true; schedule.thursday = true;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.periodType = 1; //minutes
            schedule.timePeriod = 30; // every 30 minutes
            schedule.startTime = new DateTime(1900, 1, 1, 10, 00, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 30, 0);
            schedule.weekPeriod = 1;
            schedule.format = 2;

            DateTime expectedValue = new DateTime(2022, 5, 31, 10, 00, 0);

            schedule.createListOfDays();
            DateTime actualValue = schedule.nextMinute(schedule.timeDate);
            actualValue.Should().Be(expectedValue);

        }

        [Fact]
        public void TestNextHour2()
        {
            DateTime timeDate = new DateTime(2022, 5, 30, 10, 00, 0);
            Schedule schedule = new Schedule(timeDate);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = true; schedule.wednesday = true; schedule.thursday = true;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.periodType = 0; 
            schedule.timePeriod = 2;
            schedule.startTime = new DateTime(1900, 1, 1, 10, 00, 0);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 00, 0);
            schedule.weekPeriod = 1;
            schedule.format = 2;

            DateTime expectedValue = new DateTime(2022, 5, 31, 10, 00, 0);

            schedule.createListOfDays();
            DateTime actualValue = schedule.nextHour(schedule.timeDate);
            
            actualValue.Should().Be(expectedValue);

        }

        [Fact]
        public void TestNextSecond()
        {
            DateTime timeDate = new DateTime(2022, 5, 30);
            Schedule schedule = new Schedule(timeDate);
            schedule.endDate = new DateTime(2022, 5, 31);
            schedule.monday = true; schedule.tuesday = true; schedule.wednesday = true; schedule.thursday = true;
            schedule.friday = true; schedule.saturday = true; schedule.sunday = true;
            schedule.periodType = 2; //seconds
            schedule.timePeriod = 7; // every 7 seconds
            schedule.startTime = new DateTime(1900, 1, 1, 10, 00, 50);
            schedule.endTime = new DateTime(1900, 1, 1, 10, 01, 0);
            schedule.weekPeriod = 1;
            schedule.format = 2;

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
        [Fact]
        public void TestFormat1_1()
        {
            DateTime timeDate = new DateTime(2022, 6, 1);
            Schedule schedule = new Schedule(timeDate);
            schedule.format = 1;
            schedule.dayPeriodType = 1;
            schedule.dayPeriod = 2;
            DateTime expectedValue = new DateTime(2022,6,7);

            int i = 0;
            while (i < 4)
            {
                schedule.nextDate();
                i++;
            }
            DateTime actualValue = schedule.timeDate;
            actualValue.Should().Be(expectedValue);


        }
        [Fact]
        public void TestFormat1_2()
        {
            DateTime timeDate = new DateTime(2022, 6, 1);
            Schedule schedule = new Schedule(timeDate);
            schedule.format = 1;
            schedule.dayPeriodType = 2;
            schedule.dayPeriod = 1;
            DateTime expectedValue = new DateTime(2022, 6, 15);

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
        public void TestFormat1_3()
        {
            DateTime timeDate = new DateTime(2022, 6, 1);
            Schedule schedule = new Schedule(timeDate);
            schedule.format = 1;
            schedule.dayPeriodType = 2;
            schedule.dayPeriod = 1;
            schedule.timePeriod = 2;
            schedule.periodType = 0;
            schedule.endTime = new DateTime(1900,1,1,2,0,0);
            DateTime expectedValue = new DateTime(2022, 6, 15);

            int i = 0;
            while (i < 5)
            {
                schedule.nextDate();
                i++;
            }
            DateTime actualValue = schedule.timeDate;
            actualValue.Should().Be(expectedValue);


        }
        [Fact]
        public void TestFormat1_4()
        {
            DateTime timeDate = new DateTime(2022, 6, 1);
            Schedule schedule = new Schedule(timeDate);
            schedule.format = 1;
            schedule.dayPeriodType = 3;
            schedule.dayPeriod = 3;
            schedule.timePeriod = 30;
            schedule.periodType = 2;
            schedule.endTime = new DateTime(1900, 1, 1, 0, 1 , 0);
            DateTime expectedValue = new DateTime(2022, 9, 1,0,0,30);

            int i = 0;
            while (i < 5)
            {
                schedule.nextDate();
                i++;
            }
            DateTime actualValue = schedule.timeDate;
            actualValue.Should().Be(expectedValue);


        }
    }
}