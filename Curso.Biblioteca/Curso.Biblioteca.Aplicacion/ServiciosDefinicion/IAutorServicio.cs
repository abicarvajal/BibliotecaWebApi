using Curso.Biblioteca.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServiciosDefinicion
{
    public interface IAutorServicio
    {
        Task<ICollection<AutorDto>> GetAllAsync();

        Task<AutorDto> GetByIdAsync(int id);

        Task<bool> CreateAsync(CrearAutorDto autor);

        Task<bool> UpdateAsync(int id, CrearAutorDto autor);

        Task<bool> DeleteAsync(int id);
    }
}
