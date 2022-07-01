namespace Curso.Biblioteca.Aplicacion.Dtos
{
    public class LibroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public int AutorId { get; set; }
        public int EditorialId { get; set; }

    }
}