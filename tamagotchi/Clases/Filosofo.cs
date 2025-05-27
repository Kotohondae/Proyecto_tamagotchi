namespace tamagochi.Clases
{
    public class Filosofo : Universitario
    {

        public override string Carrera => "Filosofo";
        public override void Dormir()
        {
            base.ActualizarEstado(0, -40, -5, 0, "Dormir (Filósofo)");
            RelojInterno.AvanzarDia();
            EventosManager.VerificarEventoCada3Dias(this);
        }

        public override void Estudiar() => base.ActualizarEstado(+10, +10, +15, -30, "Estudiar (Filósofo)", +10);
        public override void DormirSiesta() => base.ActualizarEstado(0, -20, -3, 0, "Siesta reflexiva (Filósofo)");
        public override void Socializar() => base.ActualizarEstado(-5, +10, -20, 0, "Socializar (Filósofo)");
        public override void TrabajoEspecial() => base.ActualizarEstado(+5, +5, +15, -300, "Tratado metafisico", +10);

        protected override List<string> ComentariosBajos => new List<string> {
            "¿Existir? Quizás mejor no...",
            "Mis ideas mueren antes que yo"
        };
       
        protected override List<string> ComentariosMedios => new List<string> {
            "Pienso luego sufro",
            "La dialéctica es mi único consuelo"
        };
       
        protected override List<string> ComentariosAltos => new List<string> {
            "¡Soy el Sócrates moderno!",
            "Mi mente trasciende lo terrenal"
        };
 
        protected override string SocializarDescripcion1 => "Debate existencial";
        protected override string SocializarDescripcion2 => "Café nihilista";
 
        public Filosofo()
        {
            Retos.RetosEstudio.Add(RetoCitaFilosofica("Pienso luego existo", "Descartes"));
            Retos.RetosEstudio.Add(RetoParadoja("¿Puede Dios crear una piedra que no pueda levantar?"));
            Retos.RetosEstudio.Add(RetoEtica("dilema del tranvía"));

            Retos.RetosTrabajo.Add(RetoArgumento("¿Libre albedrío?"));
            Retos.RetosTrabajo.Add(RetoFilosofoContemporaneo());
            Retos.RetosTrabajo.Add(RetoLogicaAristotelica());
        }
 
        private Action RetoCitaFilosofica(string cita, string autor) => () => {
            Console.Write($"[Reto] ¿Quién dijo '{cita}'? ");
            bool correcto = Console.ReadLine()?.Equals(autor, StringComparison.OrdinalIgnoreCase) ?? false;
            Console.WriteLine(correcto ? "¡Filósofo correcto!" : $"Error. Era {autor}");
        };
 
        private Action RetoParadoja(string pregunta) => () => {
            Console.WriteLine($"[Reto] {pregunta} (presiona ENTER para continuar)");
            Console.ReadLine();
            Console.WriteLine("¡Paradoja aceptada!");
        };
 
        private Action RetoEtica(string tema) => () => {
            Console.Write($"[Reto] Escribe un argumento sobre {tema}: ");
            Console.ReadLine();
            Console.WriteLine("¡Argumento registrado!");
        };
 
        private Action RetoArgumento(string tema) => () => {
            Console.Write($"[Reto] Construye un silogismo sobre {tema}: ");
            Console.ReadLine();
            Console.WriteLine("¡Lógica aplicada!");
        };
 
        private Action RetoFilosofoContemporaneo() => () => {
            Console.WriteLine("[Reto] Nombra 3 filósofos del siglo XX (presiona ENTER)");
            Console.ReadLine();
            Console.WriteLine("¡Erudición demostrada!");
        };

        private Action RetoLogicaAristotelica() => () =>
        {
            Console.WriteLine("[Reto] A es B, B es C, luego A es C. ¿Válido? (s/n)");
            bool correcto = Console.ReadLine()?.ToLower() == "s";
            Console.WriteLine(correcto ? "¡Silogismo válido!" : "¡Error lógico!");
        };
 
        public override void SocializarOpcion1()
        {
            ProcesarAccion(SocializarDescripcion1, retos.RetosTrabajo);
        }
 
        public override void SocializarOpcion2()
        {
            ProcesarAccion(SocializarDescripcion2, retos.RetosTrabajo);
        }
    }
}