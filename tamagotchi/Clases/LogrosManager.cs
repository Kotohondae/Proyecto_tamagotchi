namespace tamagochi.Clases
{
public static class LogrosManager
    {
        public static readonly List<string> logros = new List<string>();

        public static void VerificarLogros(Universitario u)
        {
            if (u.NivelEstudio >= 70 && !logros.Contains("🧠 Estudioso"))
            {
                logros.Add("🧠 Estudioso");
                Console.WriteLine("🎉 Logro desbloqueado: 🧠 Estudioso (Nivel de estudio >= 70)");
            }

            if (u.Deuda <= 0 && !logros.Contains("💰 Sin Deudas"))
            {
                logros.Add("💰 Sin Deudas");
                Console.WriteLine("🎉 Logro desbloqueado: 💰 Sin Deudas (Has saldado tu deuda)");
            }

            if (u.ConsultarHistorial(r => r.Estres >= 90).Any() && !logros.Contains("😵 Al Límite"))
            {
                logros.Add("😵 Al Límite");
                Console.WriteLine("🎉 Logro desbloqueado: 😵 Al Límite (Estrés ≥ 90)");
            }
        }

        public static void VerificarLogroMinijuego(string id)
        {
            switch (id)
            {
                case "TRIVIA":
                    if (!logros.Contains("🧠 Maestro de Trivia"))
                    {
                        logros.Add("🧠 Maestro de Trivia");
                        Console.WriteLine("🎉 Logro desbloqueado: 🧠 Maestro de Trivia (Respondiste bien una trivia)");
                    }
                    break;
                case "MEMORIA":
                    if (!logros.Contains("🧩 Memoria de Acero"))
                    {
                        logros.Add("🧩 Memoria de Acero");
                        Console.WriteLine("🎉 Logro desbloqueado: 🧩 Memoria de Acero (Recordaste la secuencia)");
                    }
                    break;
                case "DECISION":
                    if (!logros.Contains("🎯 Decisión Sabia"))
                    {
                        logros.Add("🎯 Decisión Sabia");
                        Console.WriteLine("🎉 Logro desbloqueado: 🎯 Decisión Sabia (Elegiste estudiar en lugar de la fiesta)");
                    }
                    break;
            }
        }

        public static void MostrarLogros()
        {
            Console.WriteLine("\n🏅 Logros desbloqueados:");
            foreach (var logro in logros)
            {
                Console.WriteLine("- " + logro);
            }
            if (logros.Count == 0)
                Console.WriteLine("Aún no has desbloqueado ningún logro.");
        }
    }     
}