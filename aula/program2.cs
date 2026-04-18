/*Programa principal.*/
var repo = new EstudanteRepository();
repo.Adicionar(new Estudante { Nome = "João", Idade = 20 });
var lista = repo.Listar();
foreach (var e in lista)
{
Console.WriteLine($"{e.Id} - {e.Nome} - {e.Idade}");
}