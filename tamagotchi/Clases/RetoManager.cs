namespace tamagochi.Clases
{
    public class RetosManager
    {
        private readonly Random random = new Random();
        public List<Action> RetosAlimentacion { get; protected set; } = new List<Action>();
        public List<Action> RetosDormir { get; protected set; } = new List<Action>();
        public List<Action> RetosEstudio { get; protected set; } = new List<Action>();
        public List<Action> RetosTrabajo { get; protected set; } = new List<Action>();



        public RetosManager()
        {
            InicializarRetosComunes();
        }

        private void InicializarRetosComunes()
        {
            RetosAlimentacion = new List<Action>
            {
                RetoEscribirPalabraInvertida("hambre", "erbmah"),
                RetoContarLetras("nutrición", 9),
                RetoEscribirPalabraInvertida("saludable", "elbadulas")
            };

            RetosDormir = new List<Action>
            {
                RetoContarNumeros(20, 30),
                RetoContarLetras("descanso", 8),
                RetoRespiracionControlada()
            };

            RetosEstudio = new List<Action>();
            RetosTrabajo = new List<Action>();
        }

        public Action RetoEscribirPalabraInvertida(string palabra, string solucion) => () =>
        {
            Console.Write($"[Reto] Escribe '{palabra}' al revés: ");
            bool correcto = Console.ReadLine()?.Trim().Equals(solucion, StringComparison.OrdinalIgnoreCase) ?? false;
            Console.WriteLine(correcto ? "¡Correcto!" : "Error. La forma correcta era: " + solucion);
        };

        public Action RetoContarLetras(string palabra, int cantidad) => () =>
        {
            Console.Write($"[Reto] ¿Cuántas letras tiene '{palabra}'? ");
            bool correcto = int.TryParse(Console.ReadLine(), out int respuesta) && respuesta == cantidad;
            Console.WriteLine(correcto ? "¡Bien calculado!" : $"Incorrecto. Tiene {cantidad} letras.");
        };

        public Action RetoContarNumeros(int min, int max) => () =>
        {
            int meta = random.Next(min, max + 1);
            Console.WriteLine($"[Reto] Cuenta desde 1 hasta {meta} (presiona ENTER para continuar)");
            Console.ReadLine();
            Console.WriteLine("¿Lograste completarlo?");
        };

        public Action RetoRespiracionControlada() => () =>
        {
            Console.WriteLine("[Reto] Sigue el ritmo de respiración... (presiona ENTER 3 veces)");
            for (int i = 0; i < 3; i++) Console.ReadLine();
            Console.WriteLine("¡Ritmo controlado!");
        };

        public void EjecutarRetoAleatorio(List<Action> retos)
        {
            if (retos.Count == 0)
            {
                Console.WriteLine("[RetosManager] No hay retos disponibles.");
                return;
            }
            retos[random.Next(retos.Count)]();
        }
    }
}
