using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioUsuario : RepositorioBase<Usuarios>
    {
        public bool Authentic(string nombreUsuario, string clave)
        {
            Expression<Func<Usuarios, bool>> filtrar = f => true;
            bool paso = false;
            filtrar = m => m.NombreUsuario.Equals(nombreUsuario) && m.Contrasena.Equals(clave);
            if (this.GetList(filtrar).Count() != 0)
            {
                paso = true;
            }
      
            return paso;
        }
    }
}
