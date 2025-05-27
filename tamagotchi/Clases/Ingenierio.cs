namespace tamagochi.Clases
{
    public class Ingeniero : Universitario
    {

        public override string Carrera => "Ingeniería";
        public override void Dormir()
        {
            base.ActualizarEstado(0, -40, -10, 0, "Dormir (Ingeniero)");
            RelojInterno.AvanzarDia();
            EventosManager.VerificarEventoCada3Dias(this);
        }

        public override void Estudiar() => ActualizarEstado(+5, +10, +30, -100, "Estudiar (Ingeniero)", +15);
        public override void DormirSiesta() => ActualizarEstado(0, -15, -5, 0, "Siesta rápida (Ingeniero)");
        public override void Socializar() => ActualizarEstado(-5, +10, -20, 0, "Socializar (Ingeniero)");
        public override void TrabajoEspecial() => ActualizarEstado(+10, +5, +20, -500, "Desarrollo de app revolucionaria", +5);
        protected override List<string> ComentariosBajos => new List<string> {
            "El código tiene más bugs que mi vida social...",
            "¿Compilar? Ni mi existencia compila..."
        };

        protected override List<string> ComentariosMedios => new List<string> {
            "Compila... pero a qué costo mental...",
            "Funciona, pero nadie sabe cómo"
        };

        protected override List<string> ComentariosAltos => new List<string> {
            "¡Soy el dios del código!",
            "Mis algoritmos podrían gobernar el mundo"
        };

        protected override string SocializarDescripcion1 => "Reunión técnica";
        protected override string SocializarDescripcion2 => "Hackathon nocturno";

        public Ingeniero()
        {
            Retos.RetosEstudio.Add(RetoOperacionMatematica("+", (a, b) => a + b));
            Retos.RetosEstudio.Add(RetoOperacionMatematica("×", (a, b) => a * b));
            Retos.RetosEstudio.Add(RetoSerieFibonacci());

            Retos.RetosTrabajo.Add(RetoCompletarSecuencia(2, 2));
            Retos.RetosTrabajo.Add(RetoQuitarVocales("tarea", "tr"));
            Retos.RetosTrabajo.Add(RetoExtraerDecimal(3.14m, 14));
        }

        private Action RetoOperacionMatematica(string operador, Func<int, int, int> operacion) => () =>
        {
            int a = random.Next(1, 10);
            int b = random.Next(1, 10);
            Console.Write($"[Reto] {a} {operador} {b} = ");
            bool correcto = int.TryParse(Console.ReadLine(), out int res) && res == operacion(a, b);
            Console.WriteLine(correcto ? "¡Correcto!" : $"Error. Resultado: {operacion(a, b)}");
        };

        private Action RetoSerieFibonacci() => () =>
        {
            Console.Write("[Reto] Siguiente número en 1,1,2,3,5...: ");
            bool correcto = Console.ReadLine() == "8";
            Console.WriteLine(correcto ? "¡Secuencia correcta!" : "¡Error! Era 8");
        };

        private Action RetoCompletarSecuencia(int inicio, int paso) => () =>
        {
            int num = inicio + (paso * 3);
            Console.Write($"[Reto] Completa: {inicio},{inicio + paso},{inicio + paso * 2},... ");
            bool correcto = int.TryParse(Console.ReadLine(), out int res) && res == num;
            Console.WriteLine(correcto ? "¡Patrón correcto!" : $"Error. Siguiente: {num}");
        };

        private Action RetoQuitarVocales(string palabra, string solucion) => () =>
        {
            Console.Write($"[Reto] Escribe '{palabra}' sin vocales: ");
            bool correcto = Console.ReadLine()?.ToLower() == solucion;
            Console.WriteLine(correcto ? "¡Vocales eliminadas!" : $"Error. Solución: {solucion}");
        };

        private Action RetoExtraerDecimal(decimal numero, int decimales) => () =>
        {
            Console.Write($"[Reto] Parte decimal de {numero}: ");
            bool correcto = int.TryParse(Console.ReadLine(), out int res) && res == decimales;
            Console.WriteLine(correcto ? "¡Decimales correctos!" : $"Error. Decimales: {decimales}");
        };
        
        public override void SocializarOpcion1()
        {
            ProcesarAccion(SocializarDescripcion1, Retos.RetosTrabajo);
        }
 
        public override void SocializarOpcion2()
        {
            ProcesarAccion(SocializarDescripcion2, Retos.RetosTrabajo);
        }
    }     
}