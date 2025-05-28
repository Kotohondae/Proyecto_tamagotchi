namespace tamagochi.Clases
{
    public class Minijuegos
    {
        private readonly Universitario jugador;

        public Minijuegos(Universitario jugador)
        {
            this.jugador = jugador;
        }

        public void Ejecutar(string tipo)
        {
            switch (tipo.ToUpper())
            {
                case "TRIVIA":
                    JugarTrivia();
                    break;
                case "MEMORIA":
                    JugarMemoria();
                    break;
                case "DECISION":
                    JugarDecision();
                    break;
                default:
                    Console.WriteLine(" Minijuego no encontrado.");
                    break;
            }
        }

        private void JugarTrivia()
        {
            Console.WriteLine("¿Qué lenguaje se usa para Unity?");
            Console.WriteLine("A) Java\nB) C#\nC) Python\nD) C++");
            string respuesta = Console.ReadLine().ToUpper();

            if (respuesta == "B")
            {
                Console.WriteLine(" ¡Correcto! +10 estudio");
                jugador.ActualizarEstado(0, 0, 0, 0, "Trivia", 10);
                LogrosManager.VerificarLogroMinijuego("TRIVIA");
            }
            else
            {
                Console.WriteLine(" Incorrecto. +5 estrés");
                jugador.ActualizarEstado(0, 0, 5, 0, "Trivia");
            }
        }

        private void JugarMemoria()
        {
            List<string> coloresDisponibles = new List<string> { "rojo", "azul", "verde" };
            List<string> secuencia = new List<string> { "rojo", "azul", "verde" };
            Random rnd = new Random();

            while (true)
            {
                Console.WriteLine("Memoriza esta secuencia:");
                Console.WriteLine(string.Join(" ", secuencia));

                Thread.Sleep(3000);
                Console.Clear();

                Console.Write("Escribe la secuencia: ");
                string entrada = Console.ReadLine().Trim().ToLower();

                string secuenciaString = string.Join(" ", secuencia);

                if (entrada == secuenciaString)
                {
                    Console.WriteLine(" ¡Correcto! -5 estrés");
                    jugador.ActualizarEstado(0, 0, -5, 0, "Memoria");
                    LogrosManager.VerificarLogroMinijuego("MEMORIA");

                    if (secuencia.Count == 10)
                    {
                        Console.WriteLine(" ¡Ganaste! Has memorizado la secuencia máxima.");
                        break;
                    }

                    // Agregar un nuevo color al final al azar
                    string nuevoColor = coloresDisponibles[rnd.Next(coloresDisponibles.Count)];
                    secuencia.Add(nuevoColor);

                    Console.WriteLine("Prepárate para la siguiente ronda...");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine(" Fallaste. +5 estrés");
                    jugador.ActualizarEstado(0, 0, 5, 0, "Memoria");
                    Console.WriteLine($"La secuencia correcta era: {secuenciaString}");
                    break;
                }
            }
        }


        private void JugarDecision()
        {
            Console.WriteLine("Te invitan a una fiesta antes de un examen...");
            Console.WriteLine("¿Qué haces?");
            Console.WriteLine("A) Ir a la fiesta\nB) Estudiar\nC) Dormir");

            string eleccion = Console.ReadLine().ToUpper();
            switch (eleccion)
            {
                case "A":
                    jugador.ActualizarEstado(-5, 0, -10, 0, "Fiesta");
                    Console.WriteLine("Te divertiste, pero no estudiaste.");
                    break;
                case "B":
                    jugador.ActualizarEstado(0, 0, 10, 0, "Estudio", 10);
                    Console.WriteLine("Estudiaste, pero te estresaste.");
                    LogrosManager.VerificarLogroMinijuego("DECISION");
                    break;
                case "C":
                    jugador.ActualizarEstado(0, -10, -5, 0, "Dormir");
                    Console.WriteLine("Recuperaste energía.");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }     
}