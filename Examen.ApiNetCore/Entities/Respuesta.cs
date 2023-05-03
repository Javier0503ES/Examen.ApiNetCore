namespace Examen.ApiNetCore.Entities
{
    public class Respuesta
    {
        public int Id { get; set; }
        public int IdPregunta { get; set; }
        public string Descripcion { get; set; }
        public bool? EsCorrecta { get; set; }
        public bool? Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
