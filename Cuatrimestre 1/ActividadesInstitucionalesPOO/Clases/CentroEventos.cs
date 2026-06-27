using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadesInstitucionalesPOO.Clases
{
    public class CentroEventos
    {
        public List<EventoAcademico> eventos = new();

        public void CrearEvento(EventoAcademico evento)
        {
            if (eventos.Any(e => e.Codigo == evento.Codigo))
            {
                Console.WriteLine("Ya existe un evento con el mismo codigo. Este debe ser unico...");
                return;
            }

            eventos.Add(evento);
        }

        public EventoAcademico? BuscarEvento(EventoAcademico evento) => eventos.Find(e => e.Codigo == evento.Codigo);

        public void ListarEventos()
        {
            Console.WriteLine("--- Lista de Eventos ---");
            eventos.ForEach(e =>
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine($"-> {e.Codigo} | {e.Tituilo} | {e.Participantes.Count()}/{e.CapMax} | {e.Lugar} | {e.Fecha}");
            });
            Console.WriteLine("------------------------------------------------------");

        }
    }
}
