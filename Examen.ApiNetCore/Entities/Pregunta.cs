namespace Examen.ApiNetCore.Entities
{
	public class Pregunta
	{
		public int Id { get; set; }
		public int IdExamen { get; set; }
		public string Descripcion { get; set; }
		public bool Activo { get; set; }
		public DateTime FechaRegistro { get; set; }
		public DateTime FechaActualizacion { get; set; }
	}
}
