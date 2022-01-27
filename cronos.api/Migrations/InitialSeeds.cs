using cronos.entity.Entity;
using FluentMigrator;

namespace cronos.api.Migrations
{
    [Migration(2)]
    public class InitialSeeds : Migration
    {
        public override void Down()
        {
            Delete.FromTable("Administrator");
            Delete.FromTable("Department");
            Delete.FromTable("Employee");
            Delete.FromTable("Post");
        }

        public override void Up()
        {
            Insert.IntoTable("Administrator")
                .Row(new Administrator("paulo@test.it", "password123"));

            Insert.IntoTable("Department")
                .Row(new Department(1, "Development"));

            Insert.IntoTable("Employee")
                .Row(new Employee(1, "paulo", "paulo@test.it"));

            Insert.IntoTable("Post")
                .Row(new Post(1, "title", "description bla bla"));
        }
    }
}
