using System;
using System.Collections.Generic;
using System.Linq;

namespace tamagochi.Clases
{

    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== Simulador de Tamagotchi Universitario ===\n");
            Universitario uni = SeleccionarCarrera();
            Minijuegos minijuegos = new Minijuegos(uni);

            bool salir = false;
            while (!salir)
            {
                MostrarMenu();
                Console.Write("Selecciona opción: ");
                string opcion = Console.ReadLine() ?? "";
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("1. Comida ligera (-10 hambre, +2 estrés, $10)");
                        Console.WriteLine("2. Comida completa (-30 hambre, +8 estrés, $50)");
                        Console.Write("Elige tipo de comida: ");
                        string tipoComida = Console.ReadLine() ?? "";
                        if (tipoComida == "1")
                        {
                            uni.ComerLigero();
                            uni.ProcesarAccion("Alimentación", uni.Retos.RetosAlimentacion);
                        }
                        else if (tipoComida == "2") uni.ComerCompleto();
                        else Console.WriteLine("Opción inválida.");
                        break;

                    case "2":
                        Console.WriteLine("1. Dormir siesta");
                        Console.WriteLine("2. Dormir completo");
                        Console.Write("Elige tipo de descanso: ");
                        string tipoSueño = Console.ReadLine() ?? "";
                        if (tipoSueño == "1") uni.DormirSiesta();
                        else if (tipoSueño == "2")
                        {
                            uni.Dormir();
                            uni.ProcesarAccion("Dormir", uni.Retos.RetosDormir);
                        }
                        else Console.WriteLine("Opción inválida.");
                        break;


                    case "3":
                        Console.WriteLine("1. Estudiar solo (+10 estres, -$50)");
                        Console.WriteLine("2. Estudiar en grupo (+10 estres, -$30, +sociabilidad)");
                        Console.Write("Elige tipo de estudio: ");
                        string tipoEstudio = Console.ReadLine() ?? "";
                        if (tipoEstudio == "1") 
                        {
                            uni.Estudiar();
                            uni.ProcesarAccion("Estudiar", uni.Retos.RetosEstudio);
                        }
                        else if (tipoEstudio == "2") uni.EstudiarEnGrupo();
                        else Console.WriteLine("Opción inválida.");
                        break;

                    case "4":
                        Console.WriteLine("1. Trabajo medio tiempo");
                        Console.WriteLine("2. Trabajo especial de tu carrera");
                        Console.Write("Elige opción de trabajo: ");
                        string tipoTrabajo = Console.ReadLine() ?? "";
                        if (tipoTrabajo == "1")
                        {
                            uni.Trabajar();
                            uni.ProcesarAccion("Trabajar", uni.Retos.RetosTrabajo);
                        }
                        else if (tipoTrabajo == "2") uni.TrabajoEspecial();
                                else Console.WriteLine("Opción inválida.");
                        break;

                    case "5": uni.Socializar(); break;
                    case "6": MostrarHistorial(uni); break;
                    case "7": MostrarPicosEstres(uni); break;
                    case "8":
                        Console.WriteLine("Minijuegos disponibles:");
                        Console.WriteLine("1. Trivia");
                        Console.WriteLine("2. Memoria");
                        Console.WriteLine("3. Decisión");

                        Console.Write("Elige minijuego: ");
                        string juego = Console.ReadLine() ?? "";
                        switch (juego)
                        {
                            case "1": minijuegos.Ejecutar("TRIVIA"); break;
                            case "2": minijuegos.Ejecutar("MEMORIA"); break;
                            case "3": minijuegos.Ejecutar("DECISION"); break;
                            default: Console.WriteLine("Minijuego inválido."); break;
                        }
                        break;

                    case "9":
                        LogrosManager.MostrarLogros();
                        break;
                    case "0":
                        salir = true;
                        MostrarResumenFinal(uni); break;
                }

                HUD.MostrarEstado(uni);
                Console.WriteLine();
            }
        }

        private static Universitario SeleccionarCarrera()
        {
            Console.WriteLine("Elige tu carrera:");
            Console.WriteLine("1. Ingeniero");
            Console.WriteLine("2. Filósofo");
            Console.WriteLine("3. Artista");
            Console.WriteLine("4. Médico");
            Console.Write("Opción: ");
            string opt = Console.ReadLine() ?? "";
            Console.WriteLine();

            return opt switch
            {
                "1" => new Ingeniero(),
                "2" => new Filosofo(),
                "3" => new Artista(),
                "4" => new Medico(),
                _ => new Ingeniero()
            };
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine($" Tamagochi universitario");
            Console.WriteLine("==============================\n");
            Console.WriteLine("--- Menú de Acciones ---");
            Console.WriteLine("1. Alimentar");
            Console.WriteLine("2. Dormir");
            Console.WriteLine("3. Estudiar");
            Console.WriteLine("4. Trabajar");
            Console.WriteLine("5. Socializar");
            Console.WriteLine("6. Ver historial completo");
            Console.WriteLine("7. Ver picos de estrés (>= 70)");
            Console.WriteLine("8. Jugar minijuego");
            Console.WriteLine("9. Ver logros");
            Console.WriteLine("0. Salir");
        }

        private static void MostrarHistorial(Universitario u)
        {
            Console.WriteLine("--- Historial de acciones ---");
            foreach (var r in u.Historial)
            {
                Console.WriteLine($"{r.Fecha:dd/MM/yyyy} - {r.Accion} (H={r.Hambre}, S={r.Sueno}, E={r.Estres}, D={r.Deuda:C})");
            }
        }

        private static void MostrarPicosEstres(Universitario u)
        {
            Console.WriteLine("--- Picos de estrés (>= 70) ---");
            var picos = u.ConsultarHistorial(r => r.Estres >= 70);
            if (!picos.Any())
                Console.WriteLine("No hay picos de estrés registrados.");
            else
                foreach (var r in picos)
                    Console.WriteLine($"{r.Fecha:dd/MM/yyyy} - {r.Accion}: Estrés={r.Estres}");
        }

        static void MostrarResumenFinal(Universitario u)
        {
            Console.Clear();
            Console.WriteLine(" FIN DEL JUEGO ");
            Console.WriteLine("----------------------------");

            Console.WriteLine($" Carrera: {u.Carrera}");
            Console.WriteLine($" Días jugados: {RelojInterno.DiaActual}");

            Console.WriteLine($"\n Nivel de estudio: {u.NivelEstudio}/100");
            Console.WriteLine($" Nivel de estrés: {u.Estres}/100");
            Console.WriteLine($" Deuda restante: ${u.Deuda}");

            List<string> logros = LogrosManager.logros;
            Console.WriteLine(" Logros desbloqueados:");
            if (logros.Any())
            {
                foreach (string logro in logros)
                    Console.WriteLine($"   - {logro}");
            }
            else
            {
                Console.WriteLine("   (Ninguno)");
            }

            Console.WriteLine("\n Resultado Final:");
            if (u.NivelEstudio >= 80 && u.Estres <= 30)
                Console.WriteLine(" ¡Felicidades! Te graduaste con honores.");
            else if (u.NivelEstudio >= 60)
                Console.WriteLine(" Aprobaste con esfuerzo. ¡Buen trabajo!");
            else if (u.NivelEstudio >= 40)
                Console.WriteLine(" Aprobaste raspando... pero lo lograste.");
            else
                Console.WriteLine(" No alcanzaste el nivel necesario. Tendrás que repetir el semestre.");

            Console.WriteLine("\nGracias por jugar. Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}