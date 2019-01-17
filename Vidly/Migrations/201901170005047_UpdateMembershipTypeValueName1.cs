namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeValueName1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MembershipTypes", "name");
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            Sql("UPDATE MembershipTypes SET Name='Pay As You Go' where ID=1");
            Sql("UPDATE MembershipTypes SET Name='Monthly' where ID=2");
            Sql("UPDATE MembershipTypes SET Name='Yearly' where ID=3");
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
