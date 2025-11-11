namespace BattleFight.Models
{
    public class Torneo
    {

        //Atributos
        private int torneoid;
        private int codigoNumerico;
        private DateOnly fechaTorneo;
        private double premioDolares;
        private string categoriaEnfrentar;
        private string ganador;

        //Constructor 
        public Torneo(int torneoid, int codigoNumerico, DateOnly fechaTorneo, double premioDolares, string categoriaEnfrentar, string ganador)
        {
            this.TorneoId = torneoid;
            this.CodigoNumerico = codigoNumerico;
            this.FechaTorneo = fechaTorneo;
            this.PremioDolares = premioDolares;
            this.CategoriaEnfrentar = categoriaEnfrentar;
            this.Ganador = ganador;
        }

        //Contructor vacio
        public Torneo()
        {
            this.TorneoId = 0;
            this.CodigoNumerico = 0;
            this.FechaTorneo = DateOnly.FromDateTime(DateTime.Now);
            this.PremioDolares = 0;
            this.CategoriaEnfrentar = "";
            this.Ganador = "";
        }

        //Propiedades

        public int TorneoId { get => torneoid; set => torneoid = value; }
        public int CodigoNumerico { get => codigoNumerico; set => codigoNumerico = value; }
        public DateOnly FechaTorneo { get => fechaTorneo; set => fechaTorneo = value; }
        public double PremioDolares { get => premioDolares; set => premioDolares = value; }
        public string CategoriaEnfrentar { get => categoriaEnfrentar; set => categoriaEnfrentar = value; }
        public string Ganador { get => ganador; set => ganador = value; }
    }


}
