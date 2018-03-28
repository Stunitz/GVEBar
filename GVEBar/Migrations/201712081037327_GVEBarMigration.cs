namespace GVEBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GVEBarMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        CpfFuncionario = c.String(nullable: false, maxLength: 128),
                        NomeFuncionario = c.String(),
                        CargoFuncionario = c.String(),
                        Salario = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CpfFuncionario);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        CodigoDeBarras = c.String(nullable: false, maxLength: 128),
                        NomeProduto = c.String(),
                        ValorDeCompra = c.Double(nullable: false),
                        ValorDeVenda = c.Double(nullable: false),
                        Validade = c.DateTime(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoDeBarras);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        CpfUsuario = c.String(nullable: false, maxLength: 128),
                        Senha = c.String(),
                        CargoUsuario = c.String(),
                    })
                .PrimaryKey(t => t.CpfUsuario);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        idVenda = c.Int(nullable: false, identity: true),
                        CpfCliente = c.String(),
                        DataVenda = c.DateTime(nullable: false),
                        QuantProdVendido = c.Int(nullable: false),
                        ValorVenda = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.idVenda);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Produtos");
            DropTable("dbo.Funcionarios");
        }
    }
}
