namespace tamagochi.Clases
{
    public static class Animaciones
    {
        public static void EsperarConPuntos(string mensaje, int pasos = 3, int delayMs = 500)
        {
            Console.Write(mensaje);
            for (int i = 0; i < pasos; i++)
            {
                Thread.Sleep(delayMs);
                Console.Write(".");
            }
            Console.WriteLine();
        }
    }
}