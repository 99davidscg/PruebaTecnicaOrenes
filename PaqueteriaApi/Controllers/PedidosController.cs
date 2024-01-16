using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteriaApi.Datos;
using PaqueteriaApi.Entidades;
using PaqueteriaApi.Respuestas;

namespace PaqueteriaApi.Controllers
{    
    [ApiController]
    [Route("api/pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly PaqueteriaDbContext conexionBBDD;

        public PedidosController(PaqueteriaDbContext dbContext)
        {
            conexionBBDD = dbContext;
        }

        [HttpPost("{id_vehiculo}/pedidos")]
        public ActionResult<Respuesta_Pedido> Agregar_Pedido(int id_vehiculo, Pedido obj_nuevo_pedido)
        {
            var vehiculo = conexionBBDD.Vehiculos.Where(v => v.id_vehiculo == id_vehiculo).FirstOrDefault();

            if (vehiculo != null)
            {
                // Añadir el nuevo pedido a la lista de pedidos del vehículo
                if (vehiculo.lst_pedidos == null)
                {
                    vehiculo.lst_pedidos = new List<Pedido>();
                }

                vehiculo.lst_pedidos.Add(obj_nuevo_pedido);
                conexionBBDD.SaveChanges();

                Respuesta_Pedido obj_respuesta = new Respuesta_Pedido
                {
                    id_pedido = obj_nuevo_pedido.id_pedido,
                    mensaje = "Pedido agregado con éxito"
                };

                return Ok(obj_respuesta);
            }
            else
                return NotFound("No se encuentra el vehiculo especificado");            
        }

        [HttpDelete("{id_vehiculo}/pedidos/{id_pedido}")]
        public ActionResult<Respuesta_Pedido> Eliminar_Pedido(int id_vehiculo, Pedido obj_pedido_borrar)
        {
            var vehiculo = conexionBBDD.Vehiculos.Where(v => v.id_vehiculo == id_vehiculo).FirstOrDefault();

            if (vehiculo != null)
            {
                // Añadir el nuevo pedido a la lista de pedidos del vehículo
                if (vehiculo.lst_pedidos == null)
                {
                    vehiculo.lst_pedidos = new List<Pedido>();
                }

                vehiculo.lst_pedidos.Remove(obj_pedido_borrar);
                conexionBBDD.SaveChanges();

                Respuesta_Pedido obj_respuesta = new Respuesta_Pedido
                {
                    id_pedido = obj_pedido_borrar.id_pedido,
                    mensaje = "Pedido eliminado con éxito"
                };

                return Ok(obj_respuesta);
            }
            else
                return NotFound("No se encuentra el vehiculo especificado");
        }
    }
}
