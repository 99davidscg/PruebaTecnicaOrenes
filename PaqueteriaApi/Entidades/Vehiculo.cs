namespace PaqueteriaApi.Entidades
{
    public class Vehiculo
    {
        public int id { get; set; }
        public string matricula { get; set; }
        public string abicacion_actual { get; set; }
        public List<UbicacionHistorial> lst_historial_ubicaciones { get; set; }
    }
}
