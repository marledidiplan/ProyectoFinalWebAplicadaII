using BLL;
using Entidades;
using ProyectoFinalWeb.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb.Consulta
{
    public partial class cArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void BuscarBotton_Click(object sender, EventArgs e)
        {
            Expression<Func<Articulos, bool>> filtro = m => true;
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            DateTime Desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime Hasta = Convert.ToDateTime(HastaTextBox.Text);

            int id;
           
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0:

                    repositorio.GetList(c => true);
                    break;
                case 1:
                    id = Util.ToInt(CriterioTextBox.Text);
                    filtro = c => c.ArticuloId == id;
                    break;
                case 2:
                    filtro = c => c.Fecha >= Desde && c.Fecha <= Hasta;
                    break;
                case 3:
                    filtro = p => p.Descripcion.Contains(CriterioTextBox.Text) && p.Fecha >= Desde && p.Fecha <= Hasta;
                    break;
            }

            ArticuloGridView.DataSource = repositorio.GetList(filtro);
            ArticuloGridView.DataBind();
        }
    }
}