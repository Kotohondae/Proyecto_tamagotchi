namespace tamagochi.Clases
{
    public class EventoAleatorio
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Action<Universitario> AplicarEfecto { get; set; }

        public EventoAleatorio(string nombre, string descripcion, Action<Universitario> efecto)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            AplicarEfecto = efecto;
        }

        public void Ejecutar(Universitario u)
        {
            Console.WriteLine($"\n¡Evento aleatorio! {Nombre}: {Descripcion}");
            AplicarEfecto(u);
        }
    }    
}