namespace tamagochi.Clases
{
    public abstract class Universitario
    {
        public readonly Random random = new Random();
        private readonly HashSet<int> umbralesAlcanzados = new HashSet<int>();
        private int hambre = 50, sueno = 50, estres = 50, nivelEstudio = 0;
        private double deuda = 10000;
        protected readonly RetosManager retos = new RetosManager();
        public RetosManager Retos => retos;

        private readonly List<Registro> historial = new List<Registro>();
        public abstract string Carrera { get; }
        protected abstract List<string> ComentariosBajos { get; }
        protected abstract List<string> ComentariosMedios { get; }
        protected abstract List<string> ComentariosAltos { get; }
        protected abstract string SocializarDescripcion1 { get; }
        protected abstract string SocializarDescripcion2 { get; }

        private int Bienestar => (100 - hambre + 100 - sueno + 100 - estres) / 3;
        private readonly int[] umbralesBienestar = { 5, 10, 15, 30, 60, 90, 100 };

        public int Hambre => hambre;
        public int Sueno => sueno;
        public int Estres => estres;
        public int NivelEstudio => nivelEstudio;
        public double Deuda => deuda;
        public IEnumerable<Registro> Historial => historial;

        public void ProcesarAccion(string nombreAccion, List<Action> listaRetos)
        {
            if (ValidarRestriccionCarrera(nombreAccion)) return;

            Console.WriteLine($"\n=== {nombreAccion.ToUpper()} ===");
            retos.EjecutarRetoAleatorio(listaRetos);

            historial.Add(new Registro(nombreAccion, hambre, sueno, estres, deuda));
            VerificarUmbralesBienestar();
        }

        private bool ValidarRestriccionCarrera(string accion)
        {
            if (Carrera == "Filósofo" && accion == "Dormir")
            {
                Console.WriteLine("✖ El insomnio filosófico te mantiene despierto...");
                return true;
            }

            if (Carrera == "Artista" && accion == "Alimentación")
            {
                Console.WriteLine("✖ ¿Comida orgánica? Tu billetera llora...");
                return true;
            }

            if (Carrera == "Médico" && accion == "Socializar")
            {
                Console.WriteLine("✖ Tus pacientes necesitan atención constante...");
                return true;
            }

            return false;
        }

        private void VerificarUmbralesBienestar()
        {
            foreach (int umbral in umbralesBienestar)
            {
                if (Bienestar >= umbral && !umbralesAlcanzados.Contains(umbral))
                {
                    umbralesAlcanzados.Add(umbral);
                    MostrarComentario(umbral);
                    break;
                }
            }
        }

        public void ManejarSocializacion()
        {
            if (Carrera == "Ingeniero")
                Console.WriteLine("¡¿Y quién mantendrá el código?!");

            Console.WriteLine($"1. {SocializarDescripcion1}");
            Console.WriteLine($"2. {SocializarDescripcion2}");
            Console.Write("Elige: ");

            var opcion = Console.ReadLine();
            if (opcion == "1") SocializarOpcion1();
            else if (opcion == "2") SocializarOpcion2();
        }

        public abstract void SocializarOpcion1();
        public abstract void SocializarOpcion2();
        private void MostrarComentario(int umbral)
        {
            List<string> comentarios = Bienestar switch
            {
                < 30 => ComentariosBajos,
                < 70 => ComentariosMedios,
                _ => ComentariosAltos
            };

            Console.WriteLine($"\n[{umbral}% BIENESTAR] {comentarios[random.Next(comentarios.Count)]}");
        }

        public void ActualizarEstado(int estadoHambre, int estadoSueño, int estadoEstres, double estadoDeuda, string accion, int estadoNivelEstudio = 0)
        {

            hambre = Math.Clamp(hambre + estadoHambre, 0, 100);
            sueno = Math.Clamp(sueno + estadoSueño, 0, 100);
            estres = Math.Clamp(estres + estadoEstres, 0, 100);
            deuda = Math.Max(0, deuda + estadoDeuda);
            nivelEstudio = Math.Clamp(nivelEstudio + estadoNivelEstudio, 0, 100);

            Console.WriteLine($"Acción: {accion} | H={hambre} S={sueno} E={estres} D={deuda:C} N.E={nivelEstudio}");
        }

        public virtual void ComerLigero()
        {
            ActualizarEstado(+10, 0, +2, -10, "Comida ligera");
        }
        public virtual void ComerCompleto()
        {
            ActualizarEstado(+30, 0, +8, -50, "Comida completa");
        }

        // Aquí se avanza el día cada vez que se duerme un sueño completo
        public virtual void Dormir()
        {
            ActualizarEstado(0, -30, -10, 0, "Dormir");
            RelojInterno.AvanzarDia();
            EventosManager.VerificarEventoCada3Dias(this);
        }

        public virtual void DormirSiesta()
        {
            ActualizarEstado(0, -20, -5, 0, "Siesta");
        }
        public virtual void Estudiar()
        {
            ActualizarEstado(+10, +10, +20, -50, "Estudiar", +10);
        }
        public virtual void EstudiarEnGrupo()
        {

            ActualizarEstado(+15, +5, +10, -30, "Estudio grupal", +5);
        }
        public virtual void Trabajar()
        {
            ActualizarEstado(+5, +5, +5, -200, "Trabajar");
        }
        public virtual void Socializar()
        {
            ActualizarEstado(-5, +5, -15, 0, "Socializar");
        }

        public virtual void TrabajoEspecial()
        {
            ActualizarEstado(-5, +5, -15, 0, "Trabajo especial");
        }

        public IEnumerable<Registro> ConsultarHistorial(Func<Registro, bool> filtro) => historial.Where(filtro);
        
        public string CaritaEstado 
        {
            get
            {
                int bienestar = (100 - hambre + 100 - sueno + 100 - estres) / 3;
                return bienestar switch
                {
                    < 30 => ":(",
                    < 70 => ":|",
                    _ => ":)"
                };
            }
        }
    }    
}