namespace Examen.ApiNetCore.Entities
{
    public class Test
    {
        public int IdUser { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public int IdExamen { get; set; }
        public int NumPreguntas { get; set; }
        public string Preguntas { get; set; }
        public string Respuesta { get; set; }
        public bool EsCorrecta { get; set; }
    }
}
