namespace CNPMNC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTinhTrang : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Phongs", "TinhTrang", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Phongs", "TinhTrang", c => c.String(nullable: false));
        }
    }
}
