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
    public class EditorialServicio : IEditorialServicio
    {
        private readonly IEditorialRepositorio editorialRepositorio;

        public EditorialServicio(IEditorialRepositorio editorialRepositorio)
        {
            this.editorialRepositorio = editorialRepositorio;
        }

        public async Task<bool> CreateAsync(CrearEditorialDto editorial)
        {
            var entidad = new Editorial
            {
                Nombre = editorial.Nombre,
                Direccion = editorial.Direccion
            };
            await editorialRepositorio.CreateAsync(entidad);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = editorialRepositorio.GetAll();
            consulta = consulta.Where(x => x.Id == id);
            var editorial = consulta.SingleOrDefault();

            await editorialRepositorio.DeleteAsync(editorial);
            return true;
        }

        public async Task<ICollection<EditorialDto>> GetAllAsync()
        {
            var consulta = editorialRepositorio.GetAll();
            var listaCliente = await consulta.Select(x => new EditorialDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Direccion = x.Direccion
            }).ToListAsync();

            return listaCliente;
        }

        public async Task<EditorialDto> GetByIdAsync(int id)
        {
            var consulta = editorialRepositorio.GetAll();
            var editorial = await consulta.Where(c => c.Id == id).Select(x => new EditorialDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Direccion = x.Direccion
            }).SingleOrDefaultAsync();

            return editorial;
        }

        public async Task<bool> UpdateAsync(int id, CrearEditorialDto editorialDto)
        {
            var consulta = editorialRepositorio.GetAll();
            consulta = consulta.Where(x => x.Id == id);
            var editorial = consulta.SingleOrDefault();

            editorial.Nombre = editorialDto.Nombre;
            editorial.Direccion = editorialDto.Direccion;

            await editorialRepositorio.UpdateAsync(editorial);

            return true;
        }
    }
}
