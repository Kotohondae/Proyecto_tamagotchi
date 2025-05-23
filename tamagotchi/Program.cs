﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TamagotchiUniversitario
{
    public class Registro
    {
        public DateTime Fecha { get; }
        public string Accion { get; }
        public int Hambre { get; }
        public int Sueno { get; }
        public int Estres { get; }
        public double Deuda { get; }

        public Registro(string accion, int hambre, int sueno, int estres, double deuda)
        {
            Fecha = DateTime.Now;
            Accion = accion;
            Hambre = hambre;
            Sueno = sueno;
            Estres = estres;
            Deuda = deuda;
        }
    }

    public abstract class Universitario
    {
        private int hambre = 50, sueno = 50, estres = 50, nivelEstudio = 0;
        private double deuda = 1000;
        private readonly List<Registro> historial = new List<Registro>();

        public int Hambre => hambre;
        public int Sueno => sueno;
        public int Estres => estres;
        public int NivelEstudio => nivelEstudio;
        public double Deuda => deuda;
        public IEnumerable<Registro> Historial => historial;

        protected void ActualizarEstado(int estadoHambre, int estadoSueño, int estadoEstres, double estadoDeuda, string accion, int estadoNivelEstudio = 0)
        {
            hambre = Math.Clamp(hambre + estadoHambre, 0, 100);
            sueno = Math.Clamp(sueno + estadoSueño, 0, 100);
            estres = Math.Clamp(estres + estadoEstres, 0, 100);
            deuda = Math.Max(0, deuda + estadoDeuda);
            nivelEstudio = Math.Clamp(nivelEstudio + estadoNivelEstudio, 0, 100);

            var registro = new Registro(accion, hambre, sueno, estres, deuda);
            historial.Add(registro);

            Console.WriteLine($"[{registro.Fecha:HH:mm:ss}] Acción: {registro.Accion} | H={registro.Hambre} S={registro.Sueno} E={registro.Estres} D={registro.Deuda:C} N.E={nivelEstudio}");
        }

        public virtual void ComerLigero() => ActualizarEstado(-10, 0, +2, -10, "Comida ligera");
        public virtual void ComerCompleto() => ActualizarEstado(-30, 0, +8, -50, "Comida completa");
        public virtual void Dormir() => ActualizarEstado(0, -30, -10, 0, "Dormir");
        public virtual void Estudiar() => ActualizarEstado(+10, +10, +20, -50, "Estudiar", +10);
        public virtual void EstudiarEnGrupo() => ActualizarEstado(+15, +5, +10, -30, "Estudiar en grupo", +5);
        public virtual void Trabajar() => ActualizarEstado(+5, +5, +5, -200, "Trabajo medio tiempo");
        public virtual void Socializar() => ActualizarEstado(-5, +5, -15, 0, "Socializar");

        public IEnumerable<Registro> ConsultarHistorial(Func<Registro, bool> filtro) => historial.Where(filtro);
    }

    public class Ingeniero : Universitario
    {
        public override void Estudiar() => base.ActualizarEstado(+5, +10, +30, -100, "Estudiar (Ingeniero)", +15);
        public void CrearApp() => ActualizarEstado(+10, +5, +20, -500, "Crear app", +5);
    }

    public class Filosofo : Universitario
    {
        public override void Dormir() => base.ActualizarEstado(0, -40, -5, 0, "Dormir (Filósofo)");
        public void PublicarEnsayo() => ActualizarEstado(+5, +5, +15, -300, "Publicar ensayo", +10);
    }

    public class Artista : Universitario
    {
        public override void Trabajar() => base.Trabajar();
        public void VenderCuadro() => ActualizarEstado(+2, +5, +10, -300, "Vender cuadro", +2);
    }

    public class Medico : Universitario
    {
        public override void Socializar() => base.ActualizarEstado(-10, +5, -10, -50, "Socializar (Médico)");
        public void ConsultaPrivada() => ActualizarEstado(+5, +2, +10, -400, "Consulta privada", +10);
    }

    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== Simulador de Tamagotchi Universitario ===\n");
            Universitario uni = SeleccionarCarrera();

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
                        if (tipoComida == "1") uni.ComerLigero();
                        else if (tipoComida == "2") uni.ComerCompleto();
                        else Console.WriteLine("Opción inválida.");
                        break;

                    case "2": uni.Dormir(); break;

                    case "3":
                        Console.WriteLine("1. Estudiar solo (+10 estres, -$50)");
                        Console.WriteLine("2. Estudiar en grupo (+10 estres, -$30, +sociabilidad)");
                        Console.Write("Elige tipo de estudio: ");
                        string tipoEstudio = Console.ReadLine() ?? "";
                        if (tipoEstudio == "1") uni.Estudiar();
                        else if (tipoEstudio == "2") uni.EstudiarEnGrupo();
                        else Console.WriteLine("Opción inválida.");
                        break;

                    case "4":
                        Console.WriteLine("1. Trabajo medio tiempo");
                        Console.WriteLine("2. Trabajo especial de tu carrera");
                        Console.Write("Elige opción de trabajo: ");
                        string tipoTrabajo = Console.ReadLine() ?? "";
                        if (tipoTrabajo == "1") uni.Trabajar();
                        else if (tipoTrabajo == "2")
                        {
                            switch (uni)
                            {
                                case Artista a: a.VenderCuadro(); break;
                                case Ingeniero i: i.CrearApp(); break;
                                case Filosofo f: f.PublicarEnsayo(); break;
                                case Medico m: m.ConsultaPrivada(); break;
                                default: Console.WriteLine("Trabajo especial no disponible."); break;
                            }
                        }
                        else Console.WriteLine("Opción inválida.");
                        break;

                    case "5": uni.Socializar(); break;
                    case "6": MostrarHistorial(uni); break;
                    case "7": MostrarPicosEstres(uni); break;
                    case "0": salir = true; break;
                    default: Console.WriteLine("Opción inválida."); break;
                }

                VerificarEventos(uni);
                Console.WriteLine();
            }

            Console.WriteLine("Simulación finalizada. ¡Hasta la próxima!");
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
            Console.WriteLine("--- Menú de Acciones ---");
            Console.WriteLine("1. Alimentar");
            Console.WriteLine("2. Dormir");
            Console.WriteLine("3. Estudiar");
            Console.WriteLine("4. Trabajar");
            Console.WriteLine("5. Socializar");
            Console.WriteLine("6. Ver historial completo");
            Console.WriteLine("7. Ver picos de estrés (>= 70)");
            Console.WriteLine("0. Salir");
        }

        private static void MostrarHistorial(Universitario u)
        {
            Console.WriteLine("--- Historial de acciones ---");
            foreach (var r in u.Historial)
            {
                Console.WriteLine($"{r.Fecha:dd/MM/yyyy HH:mm} - {r.Accion} (H={r.Hambre}, S={r.Sueno}, E={r.Estres}, D={r.Deuda:C})");
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
                    Console.WriteLine($"{r.Fecha:dd/MM/yyyy HH:mm} - {r.Accion}: Estrés={r.Estres}");
        }

        private static void VerificarEventos(Universitario u)
        {
            var fecha = DateTime.Now.Date;

            if (fecha == new DateTime(2025, 6, 15))
            {
                Console.WriteLine("¡Hoy tienes una entrega final importante!");
                if (u.NivelEstudio >= 50)
                    Console.WriteLine("¡Lo superaste con éxito!");
                else
                    Console.WriteLine("Fallaste la entrega por bajo nivel de estudio.");
            }
        }
    }
}