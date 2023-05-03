namespace Examen.ApiNetCore.Entities
{
    public class Usuario
    {
        /// <summary>
        /// Id >> Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Apellido paterno
        /// </summary>
        public string ApPaterno { get; set; }
        /// <summary>
        /// Apellido Materno
        /// </summary>
        public string ApMaterno { get; set; }
        /// <summary>
        /// usuario login
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Contraseña
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Usuario Activo
        /// </summary>
        public bool Activo { get; set; }
    }
}
