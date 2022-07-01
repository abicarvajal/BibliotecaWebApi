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
    public class EditorialRepositorio : IEditorialRepositorio
    {
        private readonly BibliotecaDbContexto context;

        public EditorialRepositorio(BibliotecaDbContexto context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Editorial editorial)
        {
            await context.AddAsync(editorial);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Editorial editorial)
        {
            context.Remove(editorial);
            await context.SaveChangesAsync();
        }

        public IQueryable<Editorial> GetAll()
        {
            return context.Editoriales.AsQueryable();
        }

        public async Task UpdateAsync(Editorial editorial)
        {
            context.Update(editorial);
            await context.SaveChangesAsync();
        }
    }
}
