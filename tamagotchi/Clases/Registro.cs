namespace tamagochi.Clases
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
            Fecha = RelojInterno.FechaActual;
            Accion = accion;
            Hambre = hambre;
            Sueno = sueno;
            Estres = estres;
            Deuda = deuda;
        }
    }
}