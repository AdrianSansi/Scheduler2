namespace Scheduler2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Settings", "MonthSettingsId", "dbo.MonthSettings");
            DropForeignKey("dbo.Settings", "WeekSettingsId", "dbo.WeekSettings");
            DropIndex("dbo.Settings", new[] { "WeekSettingsId" });
            DropIndex("dbo.Settings", new[] { "MonthSettingsId" });
            AddColumn("dbo.Settings", "WeekSettings_Monday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Settings", "WeekSettings_Tuesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Settings", "WeekSettings_Wednesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Settings", "WeekSettings_Thursday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Settings", "WeekSettings_Friday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Settings", "WeekSettings_Saturday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Settings", "WeekSettings_Sunday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Settings", "MonthSettings_MonthyFormat", c => c.Int(nullable: false));
            AddColumn("dbo.Settings", "MonthSettings_MonthDays", c => c.Int(nullable: false));
            AddColumn("dbo.Settings", "MonthSettings_MonthyFrequency", c => c.Int(nullable: false));
            AddColumn("dbo.Settings", "MonthSettings_DayNum", c => c.Int(nullable: false));
            AddColumn("dbo.Settings", "MonthSettings_MonthNum", c => c.Int(nullable: false));
            DropTable("dbo.MonthSettings");
            DropTable("dbo.WeekSettings");
        }
        
        public override void Down()
        {
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
            
            DropColumn("dbo.Settings", "MonthSettings_MonthNum");
            DropColumn("dbo.Settings", "MonthSettings_DayNum");
            DropColumn("dbo.Settings", "MonthSettings_MonthyFrequency");
            DropColumn("dbo.Settings", "MonthSettings_MonthDays");
            DropColumn("dbo.Settings", "MonthSettings_MonthyFormat");
            DropColumn("dbo.Settings", "WeekSettings_Sunday");
            DropColumn("dbo.Settings", "WeekSettings_Saturday");
            DropColumn("dbo.Settings", "WeekSettings_Friday");
            DropColumn("dbo.Settings", "WeekSettings_Thursday");
            DropColumn("dbo.Settings", "WeekSettings_Wednesday");
            DropColumn("dbo.Settings", "WeekSettings_Tuesday");
            DropColumn("dbo.Settings", "WeekSettings_Monday");
            CreateIndex("dbo.Settings", "MonthSettingsId");
            CreateIndex("dbo.Settings", "WeekSettingsId");
            AddForeignKey("dbo.Settings", "WeekSettingsId", "dbo.WeekSettings", "WeekSettingsId");
            AddForeignKey("dbo.Settings", "MonthSettingsId", "dbo.MonthSettings", "MonthSettingsId");
        }
    }
}
