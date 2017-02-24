namespace QHC.LojaVirtual.Dominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        UltimoAcesso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Produtos",
            //    c => new
            //        {
            //            ProdutoId = c.Int(nullable: false, identity: true),
            //            Nome = c.String(nullable: false),
            //            Descricao = c.String(nullable: false),
            //            Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Categoria = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produtos");
            DropTable("dbo.Administradores");
        }
    }
}
