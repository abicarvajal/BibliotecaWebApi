using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServiciosDefinicion;
using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.RepositorioDefinicion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.Servicios
{
    public class LibroServicio : ILibroServicio
    {
        private readonly ILibroRepositorio libroRepositorio;

        public LibroServicio(ILibroRepositorio libroRepositorio)
        {
            this.libroRepositorio = libroRepositorio;
        }

        public async Task<bool> CreateAsync(CrearLibroDto libro)
        {
            var entidad = new Libro
            {
                Titulo = libro.Titulo,
                ISBN = libro.ISBN,
                AutorId = libro.AutorId,
                EditorialId = libro.EditorialId,
            };
            await libroRepositorio.CreateAsync(entidad);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = libroRepositorio.GetAll();
            consulta = consulta.Where(x => x.Id == id);
            var libro = consulta.SingleOrDefault();

            await libroRepositorio.DeleteAsync(libro);
            return true;
        }

        public async Task<ICollection<LibroDto>> GetAllAsync()
        {
            var consulta = libroRepositorio.GetAll();
            var listaCliente = await consulta.Select(x => new LibroDto
            {
                Id = x.Id,
                Titulo = x.Titulo,
                ISBN = x.ISBN,
                AutorId = x.Autor.Id,
                EditorialId =x.EditorialId
            }).ToListAsync();

            return listaCliente;
        }

        public async Task<LibroDto> GetByIdAsync(int id)
        {
            var consulta = libroRepositorio.GetAll();
            var libro = await consulta.Where(c => c.Id == id).Select(x => new LibroDto
            {
                Id = x.Id,
                Titulo = x.Titulo,
                ISBN = x.ISBN,
                AutorId = x.Autor.Id,
                EditorialId = x.EditorialId
            }).SingleOrDefaultAsync();

            return libro;
        }

        public async Task<bool> UpdateAsync(int id, CrearLibroDto libroDto)
        {
            var consulta = libroRepositorio.GetAll();
            consulta = consulta.Where(x => x.Id == id);
            var libro = consulta.SingleOrDefault();

            libro.Titulo = libroDto.Titulo;
            libro.ISBN = libroDto.ISBN;
            libro.AutorId = libroDto.AutorId;
            libro.EditorialId = libroDto.EditorialId;

            await libroRepositorio.UpdateAsync(libro);

            return true;
        }

    }
}
