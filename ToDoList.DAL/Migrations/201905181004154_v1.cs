namespace ToDoList.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ToDoes", newName: "ToDoTable");
            DropPrimaryKey("dbo.ToDoTable");
            AddColumn("dbo.ToDoTable", "ToDoId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.ToDoTable", "ToDoId");
            DropColumn("dbo.ToDoTable", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ToDoTable", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ToDoTable");
            DropColumn("dbo.ToDoTable", "ToDoId");
            AddPrimaryKey("dbo.ToDoTable", "Id");
            RenameTable(name: "dbo.ToDoTable", newName: "ToDoes");
        }
    }
}
