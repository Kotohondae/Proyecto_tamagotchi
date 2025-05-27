namespace tamagochi.Clases
{
    public class Medico : Universitario
    {
        public override void Dormir()
        {
            base.ActualizarEstado(0, -40, -5, 0, "Dormir (Médico)");
            RelojInterno.AvanzarDia();
            EventosManager.VerificarEventoCada3Dias(this);
        }
        public override string Carrera => "Medicina";
        public override void Estudiar() => base.ActualizarEstado(+10, +15, +25, -80, "Estudiar (Médico)", +18);
        public override void DormirSiesta() => base.ActualizarEstado(0, -10, -2, 0, "Siesta breve (Médico)");
        public override void Socializar() => base.ActualizarEstado(-10, +5, -10, -50, "Socializar (Médico)");
        public override void TrabajoEspecial() => base.ActualizarEstado(+5, +2, +10, -400, "Cirugia de emergencia", +10);

        protected override List<string> ComentariosBajos => new List<string> {
            "Mis pacientes mueren más que mi motivación",
            "¿Curación? Ni yo me puedo curar..."
        };

        protected override List<string> ComentariosMedios => new List<string> {
            "Diagnóstico: cansancio extremo",
            "Sobreviviendo a base de café y cortisol"
        };

        protected override List<string> ComentariosAltos => new List<string> {
            "¡Salvando vidas y rompiendo records!",
            "Escalpelos son mis mejores amigos"
        };

        protected override string SocializarDescripcion1 => "Guardia con compañeros";
        protected override string SocializarDescripcion2 => "Congreso médico exprés";

        public Medico()
        {
            Retos.RetosEstudio.Add(RetoAnatomia("huesos del cuerpo humano", 206));
            Retos.RetosEstudio.Add(RetoCalculoDosis(50, 2));
            Retos.RetosEstudio.Add(RetoEmergenciaMedica());

            Retos.RetosTrabajo.Add(RetoPresionArterial(120, 80));
            Retos.RetosTrabajo.Add(RetoInterpretarAnalisis("glucosa", 100));
            Retos.RetosTrabajo.Add(RetoEmergenciaMedica());
        }

        private Action RetoAnatomia(string pregunta, int respuesta) => () =>
        {
            Console.Write($"[Reto] ¿Cuántos {pregunta}? ");
            bool correcto = int.TryParse(Console.ReadLine(), out int res) && res == respuesta;
            Console.WriteLine(correcto ? "¡Anatomía correcta!" : $"Error. Respuesta: {respuesta}");
        };

        private Action RetoCalculoDosis(int peso, int mgKg) => () =>
        {
            int dosis = peso * mgKg;
            Console.Write($"[Reto] Dosis para {peso}kg ({mgKg}mg/kg): ");
            bool correcto = int.TryParse(Console.ReadLine(), out int res) && res == dosis;
            Console.WriteLine(correcto ? "¡Cálculo exacto!" : $"Error. Dosis: {dosis}mg");
        };

        private Action RetoDiagnostico(string sintomas, string diagnostico) => () =>
        {
            Console.Write($"[Reto] Diagnóstico para {sintomas}: ");
            bool correcto = Console.ReadLine()?.Equals(diagnostico, StringComparison.OrdinalIgnoreCase) ?? false;
            Console.WriteLine(correcto ? "¡Diagnóstico correcto!" : $"Error. Era {diagnostico}");
        };

        private Action RetoPresionArterial(int sistolica, int diastolica) => () =>
        {
            Console.Write($"[Reto] Clasifica PA: {sistolica}/{diastolica} (normal/alta): ");
            bool correcto = Console.ReadLine()?.ToLower() == "normal";
            Console.WriteLine(correcto ? "¡Clasificación correcta!" : "¡Es presión normal!");
        };

        private Action RetoInterpretarAnalisis(string parametro, int valor) => () =>
        {
            Console.Write($"[Reto] {parametro} en {valor} es (normal/alto): ");
            bool correcto = Console.ReadLine()?.ToLower() == (valor > 90 ? "alto" : "normal");
            Console.WriteLine(correcto ? "¡Interpretación correcta!" : "¡Nivel alterado!");
        };

        private Action RetoEmergenciaMedica() => () =>
        {
            Console.WriteLine("[Reto] ¡Paciente inconsciente! (presiona ENTER 5 veces para RCP)");
            for (int i = 0; i < 5; i++) Console.ReadLine();
            Console.WriteLine("¡Paciente estabilizado!");
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