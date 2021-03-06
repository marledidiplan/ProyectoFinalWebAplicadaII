﻿using BLL;
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
    public partial class cPagoCompra : System.Web.UI.Page
    {
        Expression<Func<PagoCompra, bool>> filtrar = m => true;
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

            Expression<Func<PagoCompra, bool>> filtro = m => true;
            RepositorioBase<PagoCompra> repositorio = new RepositorioBase<PagoCompra>();
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
                    filtro = c => c.PagoCompraId == id;
                    break;
                case 2:
                    filtro = c => c.Fecha >= Desde && c.Fecha <= Hasta;
                    break;


            }

            PagoGridView.DataSource = repositorio.GetList(filtro);
            PagoGridView.DataBind();


        }

        public void LLenaReportes()
        {
            PagoReportViewer.ProcessingMode = ProcessingMode.Local;
            PagoReportViewer.Reset();
            PagoReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoPagoCompra.rdlc");
            PagoReportViewer.LocalReport.DataSources.Clear();
            PagoReportViewer.LocalReport.DataSources.Add(new ReportDataSource("PagoR", ListPago(filtrar)));
            PagoReportViewer.LocalReport.Refresh();
        }
        public static List<PagoCompra> ListPago(Expression<Func<PagoCompra, bool>> filtro)
        {
            filtro = p => true;
            RepositorioBase<PagoCompra> repositorio = new RepositorioBase<PagoCompra>();
            List<PagoCompra> pagoList = new List<PagoCompra>();

            pagoList = repositorio.GetList(filtro);

            return pagoList;
        }
    }
}