namespace tamagochi.Clases
{
    public static class RelojInterno
    {
        private static readonly DateTime FechaInicio = new DateTime(2025, 5, 25);
        public static DateTime FechaActual { get; private set; } = FechaInicio;

        public static int DiaActual => (FechaActual - FechaInicio).Days + 1;

        public static void AvanzarDia()
        {
            FechaActual = FechaActual.AddDays(1);
            Console.WriteLine($"[Reloj interno] Ahora es: {FechaActual:dd/MM/yyyy}");
        }
    }
}