using BLL;
using Entidades;
using ProyectoFinalWeb.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb.Registros
{
    public partial class rPagoCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public PagoCompra LlenaClase()
        {
            PagoCompra pago = new PagoCompra();
            pago.PagoCompraId = Util.ToInt(PagoIdTextBox.Text);
            DateTime date;
            bool resul = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resul == true)
                pago.Fecha = date;
            pago.SuplidorId = Util.ToInt(SuplidorDropDownList.SelectedValue);
            pago.MontoPagar = Util.ToInt(PagoTextBox.Text);
            pago.Deuda = Util.ToInt(DeudaTextBox.Text);

            return pago;
        }
        private void LlenaComboBox()
        {
            RepositorioBase<Suplidores> sRepositorio = new RepositorioBase<Suplidores>();
            SuplidorDropDownList.DataSource = sRepositorio.GetList(u => true);
            SuplidorDropDownList.DataValueField = "SuplidorId";
            SuplidorDropDownList.DataTextField = "Nombre";


        }

        //private void CargarDeuda()
        //{
        //    //RepositorioBase<Suplidores> repositorio = new RepositorioBase<Suplidores>();
        //    //DeudatextBox.DataBindings.Clear();
        //    //var Suplidor = repositorio.GetList(s => true);
        //    //Binding binding = new Binding("Text", SuplidorDropDownList.DataSource, "CuentasPorPagar");
        //    //DeudaTextBox.DataBindings.Add(binding);

        //}
        public int CargarDeuda(int Id)
        {
            RepositorioBase<Suplidores> repositorio = new RepositorioBase<Suplidores>();
            Suplidores supli = new Suplidores();
            supli = repositorio.Buscar(Id);

            int Deuda = supli.CuentasPorPagar;

            return Deuda;
        }

        protected void SuplidorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Util.ToInt(SuplidorDropDownList.SelectedValue);
            int deudas = CargarDeuda(id);
            DeudaTextBox.Text = deudas.ToString();

        }
    }
}