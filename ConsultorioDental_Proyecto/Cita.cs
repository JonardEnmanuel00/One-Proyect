using System;

namespace ConsultorioDental_Proyecto
{
    public class Cita
    {
        public string ID { get; set; }
        public string Paciente { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; } 
        public int Duracion { get; set; } 
        public string Dentista { get; set; }
        public string Motivo { get; set; }


        
        public string TiempoRestante
        {
            get
            {
                TimeSpan diferencia = Fecha - DateTime.Now;
                if (diferencia.TotalSeconds < 0) return "Cita pasada";
                return $"{diferencia.Days} días y {diferencia.Hours} horas";
            }
        }

  
        public string Estado
        {
            get
            {
                DateTime ahora = DateTime.Now;
                if (Fecha.Date < ahora.Date) return "Finalizado";
                if (Fecha.Date == ahora.Date) return "En proceso/Hoy";
                return "Vigente";
            }
        }
    }
}