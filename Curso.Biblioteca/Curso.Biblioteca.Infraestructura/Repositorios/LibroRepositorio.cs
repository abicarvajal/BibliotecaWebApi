using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.RepositorioDefinicion;
using Curso.Biblioteca.Infraestructura.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.Repositorios
{
    public class LibroRepositorio : ILibroRepositorio
    {
        private readonly BibliotecaDbContexto context;

        public LibroRepositorio(BibliotecaDbContexto context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Libro libro)
        {
            await context.AddAsync(libro);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Libro libro)
        {
            context.Remove(libro);
            await context.SaveChangesAsync();
        }

        public IQueryable<Libro> GetAll()
        {
            return context.Libros.AsQueryable();
        }

        public async Task UpdateAsync(Libro libro)
        {
            context.Update(libro);
            await context.SaveChangesAsync();
        }
    }
}
