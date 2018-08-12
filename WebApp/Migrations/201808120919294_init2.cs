namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Standard = c.String(),
                        Division = c.String(),
                        Image = c.String(),
                        birthdate = c.DateTime(nullable: false),
                        AcadmicStartDate = c.DateTime(nullable: false),
                        AcadmicEndDate = c.DateTime(nullable: false),
                        Hobby = c.String(),
                        OtherActivity = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AllForms");
        }
    }
}
