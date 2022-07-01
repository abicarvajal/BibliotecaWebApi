using Curso.Biblioteca.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.Contexto
{
    public class BibliotecaDbContexto : DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Libro> Libros { get; set; }

        public BibliotecaDbContexto(DbContextOptions<BibliotecaDbContexto> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            var cadenaConexion = @"Server=(localdb)\mssqllocaldb;Database=Biblioteca;Trusted_Connection=True";
            dbContextOptionsBuilder.UseSqlServer(cadenaConexion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
