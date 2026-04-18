using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}

public class ClienteService
{
    private List<Cliente> clientes = new List<Cliente>();
    private int proximoId = 1;
    private bool EmailValido(string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;

        string padrao = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, padrao);
    }
    public void AdicionarCliente(string nome, string email)
    {
        if (!EmailValido(email))
        {
            Console.WriteLine("Email inválido!");
            return;
        }

        clientes.Add(new Cliente
        {
            Id = proximoId++,
            Nome = nome,
            Email = email
        });
    }
    public List<Cliente> ListarClientes()
    {
        return clientes;
    }
    public void AtualizarCliente(int id, string novoNome, string novoEmail)
    {
        var cliente = clientes.FirstOrDefault(c => c.Id == id);

        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado.");
            return;
        }

        if (!EmailValido(novoEmail))
        {
            Console.WriteLine("Email inválido!");
            return;
        }

        cliente.Nome = novoNome;
        cliente.Email = novoEmail;
    }
    public void RemoverCliente(int id)
    {
        var cliente = clientes.FirstOrDefault(c => c.Id == id);

        if (cliente != null)
        {
            clientes.Remove(cliente);
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.");
        }
    }
    public Cliente BuscarPorEmail(string email)
    {
        return clientes.FirstOrDefault(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }
}

class Program
{
    static void Main()
    {
        ClienteService service = new ClienteService();
        service.AdicionarCliente("João", "joao@email.com");
        service.AdicionarCliente("Maria", "maria@email.com");
        service.AdicionarCliente("Teste", "email_invalido");

        Console.WriteLine("=== LISTA DE CLIENTES ===");
        foreach (var c in service.ListarClientes())
        {
            Console.WriteLine($"ID: {c.Id} | Nome: {c.Nome} | Email: {c.Email}");
        }
        Console.WriteLine("\n=== BUSCA POR EMAIL ===");
        var cliente = service.BuscarPorEmail("maria@email.com");

        if (cliente != null)
        {
            Console.WriteLine($"Encontrado: {cliente.Nome}");
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.");
        }
    }
}