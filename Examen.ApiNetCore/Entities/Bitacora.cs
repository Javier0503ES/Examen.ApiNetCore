using Examen.ApiNetCore.Entities.Enum;
using System.Runtime.Serialization;

namespace Examen.ApiNetCore.Entities
{
	[DataContract]
	public class Bitacora
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public int IdUsuario { get; set; }
		[DataMember]
		public AcctionType IdAccion { get; set; }
		[DataMember]
		public string Observacion { get; set; }
		[IgnoreDataMember]
		public DateTime FechaRegistro { get; set; }
	}
}
