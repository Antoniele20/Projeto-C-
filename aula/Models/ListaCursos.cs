using System;
using System.Collections.Generic;
using System.Linq;

public class Curso
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int CargaHoraria { get; set; }
}

public class CursoService
{
    private List<Curso> cursos = new List<Curso>();
    private int proximoId = 1;

    public void AdicionarCurso(string nome, int cargaHoraria)
    {
        cursos.Add(new Curso
        {
            Id = proximoId++,
            Nome = nome,
            CargaHoraria = cargaHoraria
        });
    }

    public List<Curso> ListarCursos()
    {
        return cursos;
    }

    public List<Curso> FiltrarPorCargaHoraria(int cargaMinima)
    {
        return cursos.Where(c => c.CargaHoraria >= cargaMinima).ToList();
    }
    public List<Curso> OrdenarPorNome()
    {
        return cursos.OrderBy(c => c.Nome).ToList();
    }
}

class Program
{
    static void Main()
    {
        CursoService service = new CursoService();

        service.AdicionarCurso("Programação", 80);
        service.AdicionarCurso("Banco de Dados", 60);
        service.AdicionarCurso("Redes", 40);
        service.AdicionarCurso("Segurança", 70);
        service.AdicionarCurso("Algoritmos", 50);

        Console.WriteLine("=== TODOS OS CURSOS ===");
        foreach (var c in service.ListarCursos())
        {
            Console.WriteLine($"ID: {c.Id} | Nome: {c.Nome} | Carga: {c.CargaHoraria}h");
        }

        Console.WriteLine("\n=== CURSOS COM CARGA >= 60 ===");
        var filtrados = service.FiltrarPorCargaHoraria(60);

        foreach (var c in filtrados)
        {
            Console.WriteLine($"{c.Nome} - {c.CargaHoraria}h");
        }

        Console.WriteLine("\n=== CURSOS ORDENADOS POR NOME ===");
        var ordenados = service.OrdenarPorNome();

        foreach (var c in ordenados)
        {
            Console.WriteLine($"{c.Nome} - {c.CargaHoraria}h");
        }
    }
}