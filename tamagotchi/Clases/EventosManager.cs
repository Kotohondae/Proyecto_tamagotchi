namespace tamagochi.Clases
{
    public static class EventosManager
    {
        private static readonly Random rnd = new Random();
        private static DateTime ultimaFechaEvento = RelojInterno.FechaActual;


        public static List<EventoAleatorio> ListaEventos = new List<EventoAleatorio>
        {
            new EventoAleatorio("Fiesta sorpresa", "Fuiste invitado a una fiesta inesperada.",
                u => u.ActualizarEstado(0, +10, +15, 0, "Evento: Fiesta sorpresa")),

            new EventoAleatorio("Examen sorpresa", "¡Examen sorpresa! No estabas preparado.",
                u => u.ActualizarEstado(0, 0, +20, 0, "Evento: Examen sorpresa")),

            new EventoAleatorio("Ayuda inesperada", "Un amigo te prestó dinero.",
                u => u.ActualizarEstado(0, 0, -5, -300, "Evento: Ayuda inesperada")),

            new EventoAleatorio("Virus", "Tu computadora se infectó con un virus y perdiste progreso.",
                u => u.ActualizarEstado(0, 0, +10, 0, "Evento: Virus informático")),
        };

    public static void IntentarDispararEvento(Universitario u)
        {
            if (rnd.NextDouble() < 1) // 25% de probabilidad
            {
                var evento = ListaEventos[rnd.Next(ListaEventos.Count)];
                evento.Ejecutar(u);
            }
        }

        public static void VerificarEventoCada3Dias(Universitario u)
        {
            var diasDesdeUltimoEvento = (RelojInterno.FechaActual - ultimaFechaEvento).TotalDays;

            if (diasDesdeUltimoEvento >= 3)
            {
                IntentarDispararEvento(u);
                ultimaFechaEvento = RelojInterno.FechaActual;
            }
        }
    }     
}