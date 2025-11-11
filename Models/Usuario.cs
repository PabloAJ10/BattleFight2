namespace BattleFight.Models
{
    public class Usuario
    {
        //Atributos
        private int id;
        private string nombre;
        private string apellido1;
        private string apellido2;
        private int cedula;
        private string genero;
        private DateOnly fechaRegistro;
        private string estado;
        private string user;
        private string pass;
        private string confirmPassword;


        //Contructor
        public Usuario(int id, string nombre, string apellido1, string apellido2, int cedula, string genero, DateOnly fechaRegistro, string estado, string user, string pass, string confirmPassword)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido1 = apellido1;
            this.Apellido2 = apellido2;
            this.Cedula = cedula;
            this.Genero = genero;
            this.FechaRegistro = fechaRegistro;
            this.Estado = estado;
            this.User = user;
            this.Pass = pass;
            this.ConfirmPassword = confirmPassword;
        }


        //Contructor vacio

        public Usuario()
        {
            this.Id = 0;
            this.Nombre = " ";
            this.Apellido1 = " ";
            this.Apellido2 = " ";
            this.Cedula = 0;
            this.Genero = " ";
            this.FechaRegistro = DateOnly.FromDateTime(DateTime.Now);
            this.Estado = " ";
            this.User = " ";
            this.Pass = " ";
            this.ConfirmPassword = " ";
        }


        //Propiedades

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido1 { get => apellido1; set => apellido1 = value; }
        public string Apellido2 { get => apellido2; set => apellido2 = value; }
        public int Cedula { get => cedula; set => cedula = value; }
        public string Genero { get => genero; set => genero = value; }
        public DateOnly FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public string Estado { get => estado; set => estado = value; }
        public string User { get => user; set => user = value; }
        public string Pass { get => pass; set => pass = value; }
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }

    }
}
