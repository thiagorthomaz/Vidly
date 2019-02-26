namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4c875b50-d9cd-4310-8829-d6476ca93ffa', N'guest1@vidly.com', 0, N'AK5XWW1ei59YDJmHrHwKlaOntLBG+RheOEXP51e6MWhZ4M4b/SHI5V+3DD5KHYezHA==', N'1be40dd4-ca99-412f-9960-f8a6aaa566f3', NULL, 0, 0, NULL, 1, 0, N'guest1@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd8003b2b-4203-4bbe-94d1-943362d21e24', N'admin@vidly.com', 0, N'ANk0qZdKN8D3Vt8+NrdjVZF54VEuILQEi9rDbBjHxaFO6zbdJyQ9REOJq1R/w4hPAw==', N'96224967-66c7-4c90-9385-d8b97f9ddd8f', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'695e1147-3857-42fa-8b12-c9c6ed2513ab', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd8003b2b-4203-4bbe-94d1-943362d21e24', N'695e1147-3857-42fa-8b12-c9c6ed2513ab')


            ");
        }
        
        public override void Down()
        {
        }
    }
}
