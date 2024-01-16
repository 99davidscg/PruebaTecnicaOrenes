using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteriaApi.Datos;
using PaqueteriaApi.Entidades;
using PaqueteriaApi.Respuestas;

namespace PaqueteriaApi.Controllers
{
    [ApiController]
    [Route("api/vehiculos")]
    public class VehiculosController : ControllerBase
    {
        private readonly PaqueteriaDbContext conexionBBDD;

        public VehiculosController(PaqueteriaDbContext dbContext)
        {
            conexionBBDD = dbContext;
        }


        [HttpPut("{idVehiculo}/ubicacion")]
        public ActionResult ActualizarUbicacionVehiculo(int id_vehiculo, [FromBody] string nueva_ubicacion)
        {
            // Verificar si el vehículo con idVehiculo existe
            var vehiculo = conexionBBDD.Vehiculos.Where(v => v.id_vehiculo == id_vehiculo).FirstOrDefault();

            if (vehiculo != null)
            {
                // Actualizar la ubicación del vehículo
                vehiculo.ubicacion_actual = nueva_ubicacion;

                // Guardar la nueva ubicación en el historial
                if (vehiculo.lst_historial_ubicaciones == null)
                {
                    vehiculo.lst_historial_ubicaciones = new List<UbicacionHistorial>();
                }

                UbicacionHistorial obj_nueva_ubicacion = new UbicacionHistorial
                {
                    id_vehiculo = vehiculo.id_vehiculo,
                    ubicacion = nueva_ubicacion,
                    fecha = DateTime.Now
                };
                vehiculo.lst_historial_ubicaciones.Add(obj_nueva_ubicacion);

                conexionBBDD.SaveChanges();
            }
            else
                return NotFound("El vehículo no fue encontrado");         

            return NoContent();
        }

    }
}



