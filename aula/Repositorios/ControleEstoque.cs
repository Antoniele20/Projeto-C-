using System;
using System.Collections.Generic;
using System.Linq;

public class ItemEstoque
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
}

public class EstoqueService
{
    private List<ItemEstoque> itens = new List<ItemEstoque>();
    private int proximoId = 1;

    public void AdicionarItem(string nome, int quantidade)
    {
        if (quantidade < 0)
        {
            Console.WriteLine("Quantidade inicial não pode ser negativa.");
            return;
        }

        itens.Add(new ItemEstoque
        {
            Id = proximoId++,
            Nome = nome,
            Quantidade = quantidade
        });
    }

    public List<ItemEstoque> ListarItens()
    {
        return itens;
    }

    public void DarBaixa(int id, int quantidade)
    {
        var item = itens.FirstOrDefault(i => i.Id == id);

        if (item == null)
        {
            Console.WriteLine("Item não encontrado.");
            return;
        }

        if (quantidade <= 0)
        {
            Console.WriteLine("Quantidade inválida.");
            return;
        }
        if (item.Quantidade < quantidade)
        {
            Console.WriteLine("Estoque insuficiente! Operação cancelada.");
            return;
        }

        item.Quantidade -= quantidade;
    }

    public List<ItemEstoque> ListarEstoqueBaixo(int limite)
    {
        return itens.Where(i => i.Quantidade <= limite).ToList();
    }
}

class Program
{
    static void Main()
    {
        EstoqueService service = new EstoqueService();

        service.AdicionarItem("Mouse", 15);
        service.AdicionarItem("Teclado", 8);
        service.AdicionarItem("Monitor", 5);

        Console.WriteLine("=== ESTOQUE INICIAL ===");
        foreach (var i in service.ListarItens())
        {
            Console.WriteLine($"ID: {i.Id} | Nome: {i.Nome} | Qtd: {i.Quantidade}");
        }

        Console.WriteLine("\n=== BAIXA DE ESTOQUE ===");
        service.DarBaixa(1, 5);   // válido
        service.DarBaixa(3, 10);  // inválido (bloqueado)

        Console.WriteLine("\n=== ESTOQUE ATUAL ===");
        foreach (var i in service.ListarItens())
        {
            Console.WriteLine($"ID: {i.Id} | Nome: {i.Nome} | Qtd: {i.Quantidade}");
        }

        Console.WriteLine("\n=== ESTOQUE BAIXO (<= 10) ===");
        var baixos = service.ListarEstoqueBaixo(10);

        foreach (var i in baixos)
        {
            Console.WriteLine($"{i.Nome} - {i.Quantidade} unidades");
        }
    }
}