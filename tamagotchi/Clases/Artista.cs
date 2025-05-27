namespace tamagochi.Clases
{
    public class Artista : Universitario
    {

        public override string Carrera => "Artes";
        public override void Dormir()
        {
            base.ActualizarEstado(0, -40, -5, 0, "Dormir (Artista)");
            RelojInterno.AvanzarDia();
            EventosManager.VerificarEventoCada3Dias(this);
        }
        public override void Estudiar() => base.ActualizarEstado(+8, +8, +20, -40, "Estudiar (Artista)", +12);
        public override void DormirSiesta() => base.ActualizarEstado(0, -25, -8, 0, "Siesta creativa (Artista)");
        public override void Socializar() => base.ActualizarEstado(-10, +5, -25, 0, "Socializar (Artista)");
        public override void TrabajoEspecial() => base.ActualizarEstado(+2, +5, +10, -300, "Performance vanguardista", +2);

        protected override List<string> ComentariosBajos => new List<string> {
            "Mi arte vale menos que mi comida",
            "La inspiración murió..."
        };
       
        protected override List<string> ComentariosMedios => new List<string> {
            "Creo que entre en crisis existenciales",
            "El sufrimiento alimenta mi arte"
        };
       
        protected override List<string> ComentariosAltos => new List<string> {
            "¡Soy el próximo Picasso!",
            "La galería no me merece"
        };
 
        protected override string SocializarDescripcion1 => "Exposición callejera";
        protected override string SocializarDescripcion2 => "Bohemia nocturna";
 
        public Artista()
        {
            Retos.RetosEstudio.Add(RetoMezclaColores("rojo", "azul", "morado"));
            Retos.RetosEstudio.Add(RetoPerspectiva());
            Retos.RetosEstudio.Add(RetoHistoriaArte("Guernica", "Picasso"));

            Retos.RetosTrabajo.Add(RetoInterpretacionAbstracta());
            Retos.RetosTrabajo.Add(RetoCreacionEspontanea());
            Retos.RetosTrabajo.Add(RetoCriticaArte());
        }
 
        private Action RetoMezclaColores(string color1, string color2, string resultado) => () => {
            Console.Write($"[Reto] {color1} + {color2} = ");
            bool correcto = Console.ReadLine()?.Equals(resultado, StringComparison.OrdinalIgnoreCase) ?? false;
            Console.WriteLine(correcto ? "¡Mezcla perfecta!" : $"Error. Resultado: {resultado}");
        };
 
        private Action RetoPerspectiva() => () => {
            Console.WriteLine("[Reto] Dibuja mentalmente un cubo en perspectiva (presiona ENTER)");
            Console.ReadLine();
            Console.WriteLine("¡Perspectiva lograda!");
        };
 
        private Action RetoHistoriaArte(string obra, string autor) => () => {
            Console.Write($"[Reto] ¿Quién pintó '{obra}'? ");
            bool correcto = Console.ReadLine()?.Equals(autor, StringComparison.OrdinalIgnoreCase) ?? false;
            Console.WriteLine(correcto ? "¡Arte conocido!" : $"Error. Era {autor}");
        };
 
        private Action RetoInterpretacionAbstracta() => () => {
            Console.Write("[Reto] Interpreta esta mancha de café: ");
            Console.ReadLine();
            Console.WriteLine("¡Profundidad artística detectada!");
        };
 
        private Action RetoCreacionEspontanea() => () => {
            Console.WriteLine("[Reto] Crea una metáfora sobre el vacío existencial (presiona ENTER)");
            Console.ReadLine();
            Console.WriteLine("¡Obra maestra conceptual!");
        };
 
        private Action RetoCriticaArte() => () => {
            Console.Write("[Reto] Critica el arte moderno en una palabra: ");
            Console.ReadLine();
            Console.WriteLine("¡Crítica válida!");
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