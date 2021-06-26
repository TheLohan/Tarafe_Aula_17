using System;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;

class MainClass {

  public static void Cadastrar(){
    Console.WriteLine("\n\nCadastro de Produto");
    Console.Write("Nome: ");
    string nome = Console.ReadLine();
    Console.Write("Preço: ");
    double preco = Convert.ToDouble(Console.ReadLine());
    Produto p = new Produto(nome, preco);
    p.Persistir();
  }

  public static void Listar()
  {
    Console.WriteLine("\n");
    List<Produto> produtos = Produto.ConsultarProdutos();
    foreach(var produto in produtos)
    {
      produto.Imprimir();
    }
  }
  public static void Consultar()
  {
    Console.WriteLine("\n");
    Console.WriteLine("Entre com a palavra chave do produto para a consulta");
    string produtoEscolhido=Console.ReadLine();
    List<Produto> produtos = Produto.ConsultarProdutos("%"+produtoEscolhido+"%");
    foreach(var produto in produtos)
    {
      produto.Imprimir();
    }
  }

  public static void Menu(){
    char opcao;
    do {
      Console.WriteLine("\n Opções: [C]adastrar [L]istar [P]esquisar [S]air");
      opcao = Char.ToLower(Console.ReadKey().KeyChar);
      switch (opcao)
      {
        case 'c':
          Cadastrar();
          break;

        case 'l':
          Listar();
          break;

        case 'p':
          Consultar();
          break;

        case 's':
          break;

        default:
          Console.WriteLine("Opção Inválida!");
          break;
      } 
    } while (opcao != 's');
  }
  public static void Main (string[] args) {
    Console.WriteLine("Seja bem vindo ao cadastro de produtos!\n");
    Menu();
    Console.WriteLine("\nAté breve!");
  }
}