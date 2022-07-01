using Curso.Biblioteca.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServiciosDefinicion
{
    public interface IEditorialServicio
    {
        Task<ICollection<EditorialDto>> GetAllAsync();

        Task<EditorialDto> GetByIdAsync(int id);

        Task<bool> CreateAsync(CrearEditorialDto editorial);

        Task<bool> UpdateAsync(int id, CrearEditorialDto editorial);

        Task<bool> DeleteAsync(int id);
    }
}
