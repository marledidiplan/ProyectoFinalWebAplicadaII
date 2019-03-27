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
    public partial class cUsuarios : System.Web.UI.Page
    {
        Expression<Func<Usuarios, bool>> filtrar = m => true;
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
            Expression<Func<Usuarios, bool>> filtro = m => true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
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
                    filtro = c => c.UsuarioId == id;
                    break;
                case 2:
                    filtro = c => c.FechaIngreso >= Desde && c.FechaIngreso <= Hasta;
                    break;
                case 3:
                    filtro = p => p.Nombre.Contains(CriterioTextBox.Text) && p.FechaIngreso >= Desde && p.FechaIngreso <= Hasta;
                    break;

            }

            UsuariosGridView.DataSource = repositorio.GetList(filtro);
            UsuariosGridView.DataBind();

        }
        public void LLenaReportes()
        {
            UsuariosReportViewer.ProcessingMode = ProcessingMode.Local;
            UsuariosReportViewer.Reset();
            UsuariosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoUsuario.rdlc");
            UsuariosReportViewer.LocalReport.DataSources.Clear();
            UsuariosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("UsuarioR", ListUsuario(filtrar)));
            UsuariosReportViewer.LocalReport.Refresh();
        }
        public static List<Usuarios> ListUsuario(Expression<Func<Usuarios, bool>> filtro)
        {
            filtro = p => true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            List<Usuarios> UsuarioList = new List<Usuarios>();

            UsuarioList = repositorio.GetList(filtro);

            return UsuarioList;
        }
    }
}