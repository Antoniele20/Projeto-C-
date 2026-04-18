using Microsoft.EntityFrameworkCore;

public class AppDbprofessorCurso : DbContext
{
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Curso> Cursos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost;Database=FaculdadeDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Professor>()
            .HasMany(p => p.Cursos)
            .WithOne(c => c.Professor)
            .HasForeignKey(c => c.ProfessorId);
    }
}