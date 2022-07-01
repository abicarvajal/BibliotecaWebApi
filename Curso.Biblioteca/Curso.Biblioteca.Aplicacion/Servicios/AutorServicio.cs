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
    public class AutorServicio : IAutorServicio
    {
        private readonly IAutorRepositorio autorRepositorio;

        public AutorServicio(IAutorRepositorio autorRepositorio)
        {
            this.autorRepositorio = autorRepositorio;
        }

        public async Task<bool> CreateAsync(CrearAutorDto autor)
        {
            var entidad = new Autor
            {
                Nombre = autor.Nombre,
                Apellido = autor.Apellido
            };
            await autorRepositorio.CreateAsync(entidad);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = autorRepositorio.GetAll();
            consulta = consulta.Where(x => x.Id == id);
            var autor = consulta.SingleOrDefault();

            await autorRepositorio.DeleteAsync(autor);
            return true;
        }

        public async Task<ICollection<AutorDto>> GetAllAsync()
        {
            var consulta = autorRepositorio.GetAll();
            var listaCliente = await consulta.Select(x => new AutorDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            }).ToListAsync();

            return listaCliente;
        }

        public async Task<AutorDto> GetByIdAsync(int id)
        {
            var consulta = autorRepositorio.GetAll();
            var autor = await consulta.Where(c => c.Id == id).Select(x => new AutorDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            }).SingleOrDefaultAsync();

            return autor;
        }

        public async Task<bool> UpdateAsync(int id, CrearAutorDto autorDto)
        {
            var consulta = autorRepositorio.GetAll();
            consulta = consulta.Where(x => x.Id == id);
            var autor = consulta.SingleOrDefault();

            autor.Nombre = autorDto.Nombre;
            autor.Apellido = autorDto.Apellido;

            await autorRepositorio.UpdateAsync(autor);

            return true;
        }
    }
}
