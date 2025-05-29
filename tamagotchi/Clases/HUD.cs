namespace tamagochi.Clases
{  
    public static class HUD
    {
        public static void MostrarEstado(Universitario u)
        {
            Console.WriteLine("═════════════════════════════════════");
        Console.WriteLine($"   ESTADO DEL UNIVERSITARIO {u.CaritaEstado}"); 
        Console.WriteLine("═════════════════════════════════════");
        ImprimirBarra("Hambre", u.Hambre);
        ImprimirBarra("Sueño", u.Sueno);
        ImprimirBarra("Estres", u.Estres);
        ImprimirBarra("Estudio", u.NivelEstudio);
        Console.WriteLine($"Deuda: ${u.Deuda}"); 
        Console.WriteLine("═════════════════════════════════════");
        }

        private static void ImprimirBarra(string nombre, int valor)
        {
            int total = 20;
            int cantidad = valor * total / 100;
            string barra = new string('█', cantidad) + new string('░', total - cantidad);
            Console.WriteLine($"{nombre,-10}: [{barra}] {valor}%");
        }
    }
}