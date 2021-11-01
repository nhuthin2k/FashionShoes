namespace DoAnCoThanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accout",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        PassWord = c.String(nullable: false, maxLength: 20),
                        RoleID = c.String(),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accout");
        }
    }
}
