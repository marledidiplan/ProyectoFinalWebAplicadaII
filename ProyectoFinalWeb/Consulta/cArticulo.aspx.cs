using BLL;
using Entidades;
using Microsoft.Reporting.WebForms;
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
                LLenaReportes();
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
                    filtro = p => p.Descripcion.Contains(CriterioTextBox.Text) && p.Fecha >= Desde && p.Fecha <= Hasta;
                    break;
                case 3:
                    filtro = p => p.Precio.Equals(CriterioTextBox.Text) && p.Fecha >= Desde && p.Fecha <= Hasta;
                    break;
                case 4:
                    filtro = p => p.Costo.Equals(CriterioTextBox.Text) && p.Fecha >= Desde && p.Fecha <= Hasta;
                    break;
                case 5:
                    filtro = p=> p.Ganancia.Equals(CriterioTextBox.Text) && p.Fecha >= Desde && p.Fecha <= Hasta;
                    break;
                case 6: 
                    filtro = p=> p.Inventario.Equals(CriterioTextBox.Text) && p.Fecha >= Desde && p.Fecha <= Hasta;
                    break;
                case 7:
                    filtro = c => c.Fecha >= Desde && c.Fecha <= Hasta;
                    break;
            }

            ArticuloGridView.DataSource = repositorio.GetList(filtro);
            ArticuloGridView.DataBind();
        }

        public void LLenaReportes()
        {

            Expression<Func<Articulos, bool>> filtrar = m => true;
            ArticuloReportViewer.ProcessingMode = ProcessingMode.Local;
            ArticuloReportViewer.Reset();
            ArticuloReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoArticulo.rdlc");
            ArticuloReportViewer.LocalReport.DataSources.Clear();
            ArticuloReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ArticuloR", ListArti(filtrar)));
            ArticuloReportViewer.LocalReport.Refresh();
        }
        public static List<Articulos> ListArti(Expression<Func<Articulos, bool>> filtro)
        {
            filtro = p => true;
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            List<Articulos> ArticuloList = new List<Articulos>();

            ArticuloList = repositorio.GetList(filtro);

            return ArticuloList;
        }
    }
}