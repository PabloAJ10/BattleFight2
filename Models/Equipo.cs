namespace BattleFight.Models
{
    public class Equipo
    {

    //Atributos

    private int equipoid;

        private string nombreEquipo;

        private string alias1;

        private string alias2;

        private string alias3;

        private string alias4;

        private int puntaje;

        private string categoria;




        //Contructor

        public Equipo(int equipoid, string nombreEquipo, string alias1, string alias2, string alias3, string alias4, int puntaje, string categoria)

        {

            this.EquipoId = equipoid;

            this.NombreEquipo = nombreEquipo;

            this.Alias1 = alias1;

            this.Alias2 = alias2;

            this.Alias3 = alias3;

            this.Alias4 = alias4;

            this.Puntaje = puntaje;

            this.Categoria = categoria;

        }

        //Contructor vacio

        public Equipo()

        {

            this.EquipoId = 0;

            this.NombreEquipo = " ";

            this.Alias1 = " ";

            this.Alias2 = " ";

            this.Alias3 = " ";

            this.Alias4 = " ";

            this.Puntaje = 0;

            this.Categoria = " ";

        }

        //Propiedades

        public int EquipoId { get => equipoid; set => equipoid = value; }

        public string NombreEquipo { get => nombreEquipo; set => nombreEquipo = value; }

        public string Alias1 { get => alias1; set => alias1 = value; }

        public string Alias2 { get => alias2; set => alias2 = value; }

        public string Alias3 { get => alias3; set => alias3 = value; }

        public string Alias4 { get => alias4; set => alias4 = value; }

        public int Puntaje { get => puntaje; set => puntaje = value; }

        public string Categoria { get => categoria; set => categoria = value; }


        public string codigoEquipo()

        {

            string letraCategoria = "";

            if (Categoria == "Beginner")

            {

                letraCategoria = "B";

            }

            else if (Categoria == "Middle")

            {

                letraCategoria = "M";

            }

            else if (Categoria == "Expert")

            {

                letraCategoria = "E";

            }


            string ultimosDosDigitosAnio = DateTime.Now.Year.ToString().Substring(2, 2);

            Random random = new Random();

            int numerosAleatorios = random.Next(10, 99);


            return $"{letraCategoria}4{numerosAleatorios}{ultimosDosDigitosAnio}";

        }

        public string CodigoEquipo => codigoEquipo();

    }


}

