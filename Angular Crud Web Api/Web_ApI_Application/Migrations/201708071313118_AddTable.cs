namespace Web_ApI_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemId = c.Int(nullable: false, identity: true),
                        MemberName = c.String(),
                        MemberEmail = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.MemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
