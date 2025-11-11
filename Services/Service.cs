using BattleFight.Models;
using System.Data.Entity;

namespace BattleFight.Services
{
    public class Service : DbContext
    {
       
        public DbSet<Usuario> usuarios { get; set; }

        public DbSet<Equipo> equipos { get; set; }

        public DbSet<Torneo> torneos { get; set; }

        public Service() : base("BattleFight") { }



        #region Métodos de Usuario


        //Método de mostrar
        public List<Usuario> mostrarUsuarios()
        {
            return usuarios.ToList();
        }

        //Método de agregar
        public void agregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
            SaveChanges();
        }

        public Usuario buscarUsuario(int id)
        {
            var usuarioBuscado = usuarios.FirstOrDefault(x => x.Id == id);
            if (usuarioBuscado != null)
                return usuarioBuscado;
            else throw new Exception("Este usuario no está registrado");
        }
        //Método de eliminar
        public void eliminarUsuario(Usuario usuario)
        {
            usuarios.Remove(usuario);
            SaveChanges();
        }

        //Método de actualizar
        public void actualizarUsuario(Usuario usuarioActualizado)
        {
            var usuarioAntiguo = usuarios.FirstOrDefault(x => x.Id == usuarioActualizado.Id);
            if (usuarioAntiguo != null)
            {
                usuarioAntiguo.Nombre = usuarioActualizado.Nombre;
                usuarioAntiguo.Apellido1 = usuarioActualizado.Apellido1;
                usuarioAntiguo.Apellido2 = usuarioActualizado.Apellido2;
                usuarioAntiguo.Genero = usuarioActualizado.Genero;
                usuarioAntiguo.FechaRegistro = usuarioActualizado.FechaRegistro;
                usuarioAntiguo.Estado = usuarioActualizado.Estado;
                usuarioAntiguo.User = usuarioActualizado.User;
                usuarioAntiguo.Pass = usuarioActualizado.Pass;
                SaveChanges();
            }
            else throw new Exception("Este usuario no está registrado");
        }


        // Método de validación de contraseñas
        public bool ValidarContrasenas(Usuario usuario)
        {
            // Verifica si las contraseñas coinciden
            if (usuario.Pass != usuario.ConfirmPassword)
            {
                throw new Exception("Las contraseñas no coinciden, por favor intente nuevamente.");
            }

            return true;
        }

        public Usuario ValidarInicioSesion(string user, string pass)
        {
            // Buscar al usuario por nombre de usuario
            var usuario = usuarios.FirstOrDefault(u => u.User == user);

            // Validar si el usuario existe
            if (usuario == null)
            {
                throw new Exception("Usuario no registrado. Por favor, regístrese.");
            }

            // Validar si el usuario está activo
            if (usuario.Estado != "Activo")
            {
                throw new Exception("El usuario está inactivo. Por favor, contacte al administrador.");
            }

            // Validar credenciales
            if (usuario.Pass != pass)
            {
                throw new Exception("Credenciales incorrectas. Intente nuevamente.");
            }

            // Si todo es válido, retorna el usuario
            return usuario;
        }



        #endregion

        #region Métodos de Equipo


        //Método de mostrar

        public List<Equipo> mostrarEquipo()
        {
            return equipos.ToList();

        }

        //Método de agregar

        public void agregarEquipo(Equipo equipo)
        {
            equipos.Add(equipo);
            SaveChanges();
        }

        //Método de eliminar
        public void eliminarEquipo(Equipo equipo)
        {
            equipos.Remove(equipo);
            SaveChanges();
        }

        //Método de actualizar
        public void actualizarEquipo(Equipo equipoActualizado)
        {
            var equipoAntiguo = equipos.FirstOrDefault(x => x.EquipoId == equipoActualizado.EquipoId);
            if (equipoAntiguo != null)
            {
                equipoAntiguo.NombreEquipo = equipoActualizado.NombreEquipo;
                equipoAntiguo.Alias1 = equipoActualizado.Alias1;
                equipoAntiguo.Alias2 = equipoActualizado.Alias2;
                equipoAntiguo.Alias3 = equipoActualizado.Alias3;
                equipoAntiguo.Alias4 = equipoActualizado.Alias4;
                equipoAntiguo.Puntaje = equipoActualizado.Puntaje;
                equipoAntiguo.Categoria = equipoActualizado.Categoria;
                SaveChanges();
            }
            else throw new Exception("Este equipo no está registrado");
        }

        // Método de filtro por categoria

        public List<Equipo> filtroEquipo(string categoria)
        {
            var equiposFiltrados = equipos.Where(x => x.Categoria == categoria).ToList();
            if (equiposFiltrados != null)
                return (List<Equipo>)equiposFiltrados;
            else throw new Exception("No existen equipos en esa categoria");

        }

        // Método de buscar

        public Equipo buscarEquipo(int equipoid)
        {
            var equipoBuscado = equipos.FirstOrDefault(x => x.EquipoId == equipoid);
            if (equipoBuscado != null)
                return equipoBuscado;
            else throw new Exception("Este equipo no está registrado");
        }

        //Método para mostrar equipos por categorias
        public List<Equipo> mostrarEquiposPorCategoria(string categoria)
        {
            return equipos.Where(x => x.Categoria == categoria).ToList();
        }

        // Método para obtener equipos por el id
        public List<Equipo> obtenerEquiposPorIds(List<int> equipoids)
        {
            return equipos.Where(x => equipoids.Contains(x.EquipoId)).ToList();
        }

        // Método para el ganador 
        public Equipo determinarGanador(List<Equipo> equiposSeleccionados)
        {
            if (equiposSeleccionados.Count != 2)
                throw new Exception("Debe seleccionar exactamente 2 equipos.");

            return equiposSeleccionados.OrderByDescending(e => e.Puntaje).First();
        }


        #endregion

        #region Métodos de Torneo

        //Método de agregar
        public void agregarTorneo(Torneo torneo)
        {
            torneos.Add(torneo);
            SaveChanges();
        }


        //Método de mostrar
        public List<Torneo> mostrarTorneo()
        {
            return torneos.ToList();
        }

        public Torneo buscarTorneo(int torneoid)
        {
            var torneoBuscado = torneos.FirstOrDefault(x => x.TorneoId == torneoid);
            if (torneoBuscado != null)
                return torneoBuscado;
            else throw new Exception("Este producto no está registrado");
        }

        //Método de eliminar
        public void eliminarTorneo(Torneo torneo)
        {
            torneos.Remove(torneo);
            SaveChanges();
        }

        //Método de actualizar
        public void actualizarTorneo(Torneo torneoActualizado)
        {
            var torneoAntiguo = torneos.FirstOrDefault(x => x.TorneoId == torneoActualizado.TorneoId);
            if (torneoAntiguo != null)
            {
                torneoAntiguo.CodigoNumerico = torneoActualizado.CodigoNumerico;
                torneoAntiguo.FechaTorneo = torneoActualizado.FechaTorneo;
                torneoAntiguo.PremioDolares = torneoActualizado.PremioDolares;
                torneoAntiguo.CategoriaEnfrentar = torneoActualizado.CategoriaEnfrentar;
                SaveChanges();
            }
            else throw new Exception("Este torneo no está registrado");
        }


        #endregion


    }
}
