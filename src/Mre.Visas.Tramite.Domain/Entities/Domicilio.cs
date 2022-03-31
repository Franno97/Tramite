namespace Mre.Visas.Tramite.Domain.Entities
{
    public class Domicilio : BaseEntity
    {
        public string Ciudad { get; set; }

        public string Direccion { get; set; }

        public string Pais { get; set; }

        public string Provincia { get; set; }

        public string TelefonoCelular { get; set; }

        public string TelefonoDomicilio { get; set; }

        public string TelefonoTrabajo { get; set; }
    }
}