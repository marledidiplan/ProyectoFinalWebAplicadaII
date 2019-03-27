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
    public partial class cCompra : System.Web.UI.Page
    {
        Expression<Func<Compra, bool>> filtrar = m => true;
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
            Expression<Func<Compra, bool>> filtro = m => true;
            RepositorioBase<Compra> repositorio = new RepositorioBase<Compra>();
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
                    filtro = c => c.CompraId == id;
                    break;
                case 2:
                    filtro = c => c.Fecha >= Desde && c.Fecha <= Hasta;
                    break;
               
            }

            CompraGridView.DataSource = repositorio.GetList(filtro);
            CompraGridView.DataBind();




        }
        public void LLenaReportes()
        {

            CompraReportViewer.ProcessingMode = ProcessingMode.Local;
            CompraReportViewer.Reset();
            CompraReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoArticulo.rdlc");
            CompraReportViewer.LocalReport.DataSources.Clear();
            CompraReportViewer.LocalReport.DataSources.Add(new ReportDataSource("CompraR", ListCompra(filtrar)));
            CompraReportViewer.LocalReport.Refresh();
        }
        public static List<Compra> ListCompra(Expression<Func<Compra, bool>> filtro)
        {
            filtro = p => true;
            RepositorioBase<Compra> repositorio = new RepositorioBase<Compra>();
            List<Compra> CompraList = new List<Compra>();

            CompraList = repositorio.GetList(filtro);

            return CompraList;
        }
    }
}