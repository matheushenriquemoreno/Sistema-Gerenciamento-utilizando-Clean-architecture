using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

#nullable disable

namespace CleanArchMVC.Infra.Data.Migrations
{
    public partial class populandoProdutos : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, Estoque, Image, IdCategoria) values" +
                "('Caderno 10 Materias', 'Caderno Com 10 materias', 20.50, 10, 'Caderno.jpg', 1)");

            mb.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, Estoque, Image, IdCategoria) values" +
             "('Processador Intel i7', 'Processador Core Intel i7 10 nucleos 20 threads', 2850.00, 200, 'Processador.jpg', 2)");


            mb.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, Estoque, Image, IdCategoria) values" +
              "('Mouse logitech G503', 'Mouse Logitech 25 mil DPI', 189.99, 30, 'Mouse.jpg', 3)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Produtos");
        }
    }
}
