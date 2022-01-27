using FluentMigrator;

namespace cronos.api
{
    [Migration(1)]
    public class InitialTables : Migration
    {
        public override void Down()
        {
            Delete.Table("Administrator");
            Delete.Table("Department");
            Delete.Table("Employee");
            Delete.Table("Post");
        }

        public override void Up()
        {
            Create.Table("Administrator")
                .WithColumn("id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("email").AsString(100).NotNullable().Unique()
                .WithColumn("password").AsString(100).NotNullable()
                .WithColumn("created").AsDateTime().NotNullable()
                .WithColumn("updated").AsDateTime().Nullable();

            Create.Table("Department")
                .WithColumn("id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("name").AsString(100).NotNullable()
                .WithColumn("created").AsDateTime().NotNullable()
                .WithColumn("updated").AsDateTime().Nullable();

            Create.Table("Employee")
                .WithColumn("id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("name").AsString(100).NotNullable()
                .WithColumn("email").AsString(100).NotNullable()
                .WithColumn("created").AsDateTime().NotNullable()
                .WithColumn("updated").AsDateTime().Nullable();

            Create.Table("Post")
                .WithColumn("id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("title").AsString(100).NotNullable()
                .WithColumn("description").AsString(500).NotNullable()
                .WithColumn("created").AsDateTime().NotNullable()
                .WithColumn("updated").AsDateTime().Nullable();
        }
    }
}
