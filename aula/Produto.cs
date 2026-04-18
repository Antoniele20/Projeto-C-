using System;
using System.Collections.Generic;
using System.Linq;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
}

public class ProdutoService
{
    private List<Produto> produtos = new List<Produto>();
    private int proximoId = 1;

    public void AdicionarProduto(string nome, double preco)
    {
        produtos.Add(new Produto
        {
            Id = proximoId++,
            Nome = nome,
            Preco = preco
        });
    }

    public List<Produto> ListarProdutos()
    {
        return produtos;
    }

    public void AtualizarProduto(int id, string novoNome, double novoPreco)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);

        if (produto != null)
        {
            produto.Nome = novoNome;
            produto.Preco = novoPreco;
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }

    // DELETE
    public void RemoverProduto(int id)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);

        if (produto != null)
        {
            produtos.Remove(produto);
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }
    public List<Produto> ListarPorPrecoMinimo(double valorMinimo)
    {
        return produtos.Where(p => p.Preco >= valorMinimo).ToList();
    }
}

class Program
{
    static void Main()
    {
        ProdutoService service = new ProdutoService();

        service.AdicionarProduto("Mouse", 50.0);
        service.AdicionarProduto("Teclado", 120.0);
        service.AdicionarProduto("Monitor", 900.0);

        Console.WriteLine("=== LISTA DE PRODUTOS ===");
        foreach (var p in service.ListarProdutos())
        {
            Console.WriteLine($"ID: {p.Id} | Nome: {p.Nome} | Preço: {p.Preco}");
        }

        service.AtualizarProduto(1, "Mouse Gamer", 80.0);

        service.RemoverProduto(2);

        Console.WriteLine("\n=== APÓS UPDATE E DELETE ===");
        foreach (var p in service.ListarProdutos())
        {
            Console.WriteLine($"ID: {p.Id} | Nome: {p.Nome} | Preço: {p.Preco}");
        }

        Console.WriteLine("\n=== PRODUTOS ACIMA DE 100 ===");
        var filtrados = service.ListarPorPrecoMinimo(100);

        foreach (var p in filtrados)
        {
            Console.WriteLine($"ID: {p.Id} | Nome: {p.Nome} | Preço: {p.Preco}");
        }
    }
}