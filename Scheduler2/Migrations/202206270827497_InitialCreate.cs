namespace Scheduler2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonthSettings",
                c => new
                    {
                        MonthSettingsId = c.Int(nullable: false, identity: true),
                        MonthyFormat = c.Int(nullable: false),
                        MonthDays = c.Int(nullable: false),
                        MonthyFrequency = c.Int(nullable: false),
                        DayNum = c.Int(nullable: false),
                        MonthNum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MonthSettingsId);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WeekSettingsId = c.Int(),
                        MonthSettingsId = c.Int(),
                        Language = c.Int(nullable: false),
                        CurrentDate = c.DateTime(nullable: false),
                        TimeDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        WeekPeriod = c.Int(nullable: false),
                        TimePeriod = c.Int(nullable: false),
                        PeriodType = c.Int(nullable: false),
                        Format = c.Int(nullable: false),
                        DayPeriod = c.Int(nullable: false),
                        DaysPeriodType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MonthSettings", t => t.MonthSettingsId)
                .ForeignKey("dbo.WeekSettings", t => t.WeekSettingsId)
                .Index(t => t.WeekSettingsId)
                .Index(t => t.MonthSettingsId);
            
            CreateTable(
                "dbo.WeekSettings",
                c => new
                    {
                        WeekSettingsId = c.Int(nullable: false, identity: true),
                        Monday = c.Boolean(nullable: false),
                        Tuesday = c.Boolean(nullable: false),
                        Wednesday = c.Boolean(nullable: false),
                        Thursday = c.Boolean(nullable: false),
                        Friday = c.Boolean(nullable: false),
                        Saturday = c.Boolean(nullable: false),
                        Sunday = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WeekSettingsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Settings", "WeekSettingsId", "dbo.WeekSettings");
            DropForeignKey("dbo.Settings", "MonthSettingsId", "dbo.MonthSettings");
            DropIndex("dbo.Settings", new[] { "MonthSettingsId" });
            DropIndex("dbo.Settings", new[] { "WeekSettingsId" });
            DropTable("dbo.WeekSettings");
            DropTable("dbo.Settings");
            DropTable("dbo.MonthSettings");
        }
    }
}
