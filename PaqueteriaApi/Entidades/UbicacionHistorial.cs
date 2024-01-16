namespace PaqueteriaApi.Entidades
{
    public class UbicacionHistorial
    {
        public int id_ubicacion_historial { get; set; }
        public int id_vehiculo { get; set; }
        public string ubicacion { get; set; }
        public DateTime fecha { get; set; }
    }
}
